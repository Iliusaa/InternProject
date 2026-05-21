using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Intern.Bridge;

public sealed record UnityMcpBridgeConfig(
    string Host = "127.0.0.1",
    int Port = 8080,
    TimeSpan? Timeout = null,
    int RetryCount = 3,
    TimeSpan? RetryDelay = null,
    string? UnityInstance = null)
{
    public string BaseUrl => $"http://{Host}:{Port}";

    public static UnityMcpBridgeConfig FromEnvironment()
    {
        return new UnityMcpBridgeConfig(
            Host: Environment.GetEnvironmentVariable("UNITY_MCP_HOST") ?? "127.0.0.1",
            Port: ReadInt("UNITY_MCP_HTTP_PORT", 8080),
            Timeout: TimeSpan.FromSeconds(ReadDouble("UNITY_MCP_TIMEOUT", 30)),
            RetryCount: ReadInt("UNITY_MCP_RETRIES", 3),
            RetryDelay: TimeSpan.FromSeconds(ReadDouble("UNITY_MCP_RETRY_DELAY", 0.5)),
            UnityInstance: EmptyAsNull(Environment.GetEnvironmentVariable("UNITY_MCP_INSTANCE")));
    }

    private static int ReadInt(string name, int fallback)
    {
        return int.TryParse(Environment.GetEnvironmentVariable(name), out var value) ? value : fallback;
    }

    private static double ReadDouble(string name, double fallback)
    {
        return double.TryParse(Environment.GetEnvironmentVariable(name), out var value) ? value : fallback;
    }

    private static string? EmptyAsNull(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value;
    }
}

public sealed class UnityMcpBridgeException : Exception
{
    public UnityMcpBridgeException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}

public sealed class UnityMcpBridge
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    private readonly HttpClient httpClient;

    public UnityMcpBridge(UnityMcpBridgeConfig? config = null, HttpClient? httpClient = null)
    {
        Config = config ?? UnityMcpBridgeConfig.FromEnvironment();
        this.httpClient = httpClient ?? new HttpClient
        {
            Timeout = Config.Timeout ?? TimeSpan.FromSeconds(30)
        };
    }

    public UnityMcpBridgeConfig Config { get; }

    public Task<JsonNode> HealthAsync(CancellationToken cancellationToken = default)
    {
        return RequestAsync(HttpMethod.Get, "/health", null, cancellationToken);
    }

    public Task<JsonNode> ListInstancesAsync(CancellationToken cancellationToken = default)
    {
        return RequestAsync(HttpMethod.Get, "/api/instances", null, cancellationToken);
    }

    public Task<JsonNode> PingAsync(CancellationToken cancellationToken = default)
    {
        return CommandAsync("ping", new JsonObject(), cancellationToken);
    }

    public Task<JsonNode> EditorStateAsync(CancellationToken cancellationToken = default)
    {
        return CommandAsync("get_editor_state", new JsonObject(), cancellationToken);
    }

    public Task<JsonNode> ReadConsoleAsync(int count = 20, CancellationToken cancellationToken = default)
    {
        return CommandAsync("read_console", new JsonObject
        {
            ["action"] = "get",
            ["count"] = count
        }, cancellationToken);
    }

    public async Task<JsonObject> InspectSceneAsync(CancellationToken cancellationToken = default)
    {
        var active = await CommandAsync("manage_scene", new JsonObject
        {
            ["action"] = "get_active"
        }, cancellationToken);

        var hierarchy = await CommandAsync("manage_scene", new JsonObject
        {
            ["action"] = "get_hierarchy",
            ["includeTransform"] = true,
            ["pageSize"] = 100,
            ["maxNodes"] = 200
        }, cancellationToken);

        return new JsonObject
        {
            ["active_scene"] = active.DeepClone(),
            ["hierarchy"] = hierarchy.DeepClone()
        };
    }

    public Task<JsonNode> CreateGameObjectAsync(
        string name,
        string? primitiveType = null,
        double[]? position = null,
        CancellationToken cancellationToken = default)
    {
        var payload = new JsonObject
        {
            ["action"] = "create",
            ["name"] = name
        };

        if (!string.IsNullOrWhiteSpace(primitiveType))
        {
            payload["primitiveType"] = primitiveType;
        }

        if (position is { Length: 3 })
        {
            payload["position"] = new JsonArray(position[0], position[1], position[2]);
        }

        return CommandAsync("manage_gameobject", payload, cancellationToken);
    }

    public Task<JsonNode> ModifyGameObjectAsync(
        string target,
        JsonObject updates,
        CancellationToken cancellationToken = default)
    {
        var payload = new JsonObject
        {
            ["action"] = "modify",
            ["target"] = target
        };
        Merge(payload, updates);
        return CommandAsync("manage_gameobject", payload, cancellationToken);
    }

    public Task<JsonNode> DeleteGameObjectAsync(
        string target,
        string? searchMethod = null,
        CancellationToken cancellationToken = default)
    {
        var payload = new JsonObject
        {
            ["action"] = "delete",
            ["target"] = target
        };
        if (!string.IsNullOrWhiteSpace(searchMethod))
        {
            payload["searchMethod"] = searchMethod;
        }

        return CommandAsync("manage_gameobject", payload, cancellationToken);
    }

    public Task<JsonNode> ManageComponentAsync(
        string action,
        string target,
        string componentType,
        JsonObject? parameters = null,
        CancellationToken cancellationToken = default)
    {
        var payload = new JsonObject
        {
            ["action"] = action,
            ["target"] = target,
            ["componentType"] = componentType
        };
        if (parameters is not null)
        {
            Merge(payload, parameters);
        }

        return CommandAsync("manage_components", payload, cancellationToken);
    }

    public Task<JsonNode> SearchAssetsAsync(
        string path = "Assets",
        string? filterType = null,
        int pageSize = 25,
        int pageNumber = 1,
        CancellationToken cancellationToken = default)
    {
        var payload = new JsonObject
        {
            ["action"] = "search",
            ["path"] = path,
            ["pageSize"] = pageSize,
            ["pageNumber"] = pageNumber,
            ["generatePreview"] = false
        };
        if (!string.IsNullOrWhiteSpace(filterType))
        {
            payload["filterType"] = filterType;
        }

        return CommandAsync("manage_asset", payload, cancellationToken);
    }

    public Task<JsonNode> SetPlayModeAsync(bool enabled, CancellationToken cancellationToken = default)
    {
        return CommandAsync("manage_editor", new JsonObject
        {
            ["action"] = enabled ? "play" : "stop"
        }, cancellationToken);
    }

    public async Task<JsonObject> WaitUntilReadyAsync(
        TimeSpan timeout,
        CancellationToken cancellationToken = default)
    {
        var deadline = DateTimeOffset.UtcNow + timeout;
        Exception? lastError = null;

        while (DateTimeOffset.UtcNow < deadline)
        {
            try
            {
                var health = await HealthAsync(cancellationToken);
                var instances = await ListInstancesAsync(cancellationToken);
                var ping = await PingAsync(cancellationToken);
                var editorState = await EditorStateAsync(cancellationToken);

                return new JsonObject
                {
                    ["health"] = health.DeepClone(),
                    ["instances"] = instances.DeepClone(),
                    ["ping"] = ping.DeepClone(),
                    ["editor_state"] = editorState.DeepClone()
                };
            }
            catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException or UnityMcpBridgeException)
            {
                lastError = ex;
                await Task.Delay(Config.RetryDelay ?? TimeSpan.FromMilliseconds(500), cancellationToken);
            }
        }

        throw new UnityMcpBridgeException($"Unity MCP did not become ready: {lastError?.Message}");
    }

    public async Task<JsonNode> CommandAsync(
        string toolName,
        JsonObject? parameters = null,
        CancellationToken cancellationToken = default)
    {
        var payload = new JsonObject
        {
            ["type"] = toolName,
            ["params"] = parameters?.DeepClone() ?? new JsonObject()
        };
        if (!string.IsNullOrWhiteSpace(Config.UnityInstance))
        {
            payload["unity_instance"] = Config.UnityInstance;
        }

        var response = await RequestAsync(HttpMethod.Post, "/api/command", payload, cancellationToken);
        if (IsErrorResponse(response))
        {
            throw new UnityMcpBridgeException($"Unity command '{toolName}' failed: {response.ToJsonString(JsonOptions)}");
        }

        return response;
    }

    private async Task<JsonNode> RequestAsync(
        HttpMethod method,
        string path,
        JsonObject? payload,
        CancellationToken cancellationToken)
    {
        Exception? lastError = null;

        for (var attempt = 1; attempt <= Config.RetryCount; attempt++)
        {
            try
            {
                using var request = new HttpRequestMessage(method, $"{Config.BaseUrl}{path}");
                request.Headers.Accept.ParseAdd("application/json");
                if (payload is not null)
                {
                    request.Content = new StringContent(payload.ToJsonString(), Encoding.UTF8, "application/json");
                }

                using var response = await httpClient.SendAsync(request, cancellationToken);
                var text = await response.Content.ReadAsStringAsync(cancellationToken);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new UnityMcpBridgeException($"HTTP {(int)response.StatusCode} from {path}: {text}");
                }

                return JsonNode.Parse(text) ?? new JsonObject();
            }
            catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
            {
                lastError = ex;
                if (attempt < Config.RetryCount)
                {
                    var delay = Config.RetryDelay ?? TimeSpan.FromMilliseconds(500);
                    await Task.Delay(TimeSpan.FromMilliseconds(delay.TotalMilliseconds * attempt), cancellationToken);
                }
            }
        }

        throw new UnityMcpBridgeException($"Cannot reach Unity MCP at {Config.BaseUrl}{path}: {lastError?.Message}", lastError);
    }

    private static bool IsErrorResponse(JsonNode response)
    {
        if (response["status"]?.GetValue<string>() == "error")
        {
            return true;
        }

        var result = response["result"];
        if (result is null)
        {
            return false;
        }

        if (result["success"]?.GetValue<bool>() == false)
        {
            return true;
        }

        if (result["status"]?.GetValue<string>() == "error")
        {
            return true;
        }

        return FindHint(response) == "retry";
    }

    private static string? FindHint(JsonNode? node)
    {
        if (node is JsonObject obj)
        {
            if (obj["hint"] is JsonValue hintValue && hintValue.TryGetValue<string>(out var currentHint))
            {
                return currentHint;
            }

            foreach (var child in obj)
            {
                var nestedHint = FindHint(child.Value);
                if (nestedHint is not null)
                {
                    return nestedHint;
                }
            }
        }

        return null;
    }

    private static void Merge(JsonObject target, JsonObject source)
    {
        foreach (var (key, value) in source)
        {
            target[key] = value?.DeepClone();
        }
    }
}
