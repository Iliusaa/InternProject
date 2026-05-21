using System.Text.Json;
using System.Text.Json.Nodes;
using Intern.Bridge;

return await UnityBridgeCli.RunAsync(args);

internal static class UnityBridgeCli
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    public static async Task<int> RunAsync(string[] args)
    {
        if (args.Length == 0 || args[0] is "-h" or "--help")
        {
            PrintHelp();
            return args.Length == 0 ? 1 : 0;
        }

        var bridge = new UnityMcpBridge(UnityMcpBridgeConfig.FromEnvironment());

        try
        {
            JsonNode result = args[0] switch
            {
                "status" => await bridge.WaitUntilReadyAsync(TimeSpan.FromSeconds(20)),
                "instances" => await bridge.ListInstancesAsync(),
                "scene" => await bridge.InspectSceneAsync(),
                "console" => await bridge.ReadConsoleAsync(ReadInt(args, 1, 20)),
                "assets" => await bridge.SearchAssetsAsync(filterType: ReadString(args, 1)),
                "create-gameobject" => await CreateGameObjectAsync(bridge, args),
                "delete-gameobject" => await DeleteGameObjectAsync(bridge, args),
                "play-mode" => await PlayModeAsync(bridge, args),
                "call" => await CallAsync(bridge, args),
                _ => throw new ArgumentException($"Unknown command '{args[0]}'")
            };

            Console.WriteLine(result.ToJsonString(JsonOptions));
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return 1;
        }
    }

    private static Task<JsonNode> CreateGameObjectAsync(UnityMcpBridge bridge, string[] args)
    {
        if (args.Length < 2)
        {
            throw new ArgumentException("create-gameobject requires a name");
        }

        return bridge.CreateGameObjectAsync(args[1], primitiveType: ReadOption(args, "--primitive"));
    }

    private static Task<JsonNode> DeleteGameObjectAsync(UnityMcpBridge bridge, string[] args)
    {
        if (args.Length < 2)
        {
            throw new ArgumentException("delete-gameobject requires a name, path, or instance ID");
        }

        return bridge.DeleteGameObjectAsync(args[1], ReadOption(args, "--search-method"));
    }

    private static Task<JsonNode> PlayModeAsync(UnityMcpBridge bridge, string[] args)
    {
        if (args.Length < 2 || args[1] is not ("on" or "off"))
        {
            throw new ArgumentException("play-mode requires 'on' or 'off'");
        }

        return bridge.SetPlayModeAsync(args[1] == "on");
    }

    private static Task<JsonNode> CallAsync(UnityMcpBridge bridge, string[] args)
    {
        if (args.Length < 2)
        {
            throw new ArgumentException("call requires a tool name");
        }

        var paramsJson = ReadOption(args, "--params");
        var parameters = paramsJson is not null
            ? JsonNode.Parse(paramsJson) as JsonObject
                ?? throw new ArgumentException("--params must be a JSON object")
            : ReadKeyValueParameters(args.Skip(2));

        return bridge.CommandAsync(args[1], parameters);
    }

    private static JsonObject ReadKeyValueParameters(IEnumerable<string> values)
    {
        var parameters = new JsonObject();
        foreach (var value in values)
        {
            if (value.StartsWith("--", StringComparison.Ordinal))
            {
                continue;
            }

            var splitAt = value.IndexOf('=');
            if (splitAt <= 0)
            {
                continue;
            }

            var key = value[..splitAt];
            var rawValue = value[(splitAt + 1)..];
            parameters[key] = ParseValue(rawValue);
        }

        return parameters;
    }

    private static JsonNode? ParseValue(string value)
    {
        if (bool.TryParse(value, out var boolValue))
        {
            return JsonValue.Create(boolValue);
        }

        if (int.TryParse(value, out var intValue))
        {
            return JsonValue.Create(intValue);
        }

        if (double.TryParse(value, out var doubleValue))
        {
            return JsonValue.Create(doubleValue);
        }

        if ((value.StartsWith("[", StringComparison.Ordinal) && value.EndsWith("]", StringComparison.Ordinal)) ||
            (value.StartsWith("{", StringComparison.Ordinal) && value.EndsWith("}", StringComparison.Ordinal)))
        {
            return JsonNode.Parse(value);
        }

        return JsonValue.Create(value);
    }

    private static int ReadInt(string[] args, int index, int fallback)
    {
        return args.Length > index && int.TryParse(args[index], out var value) ? value : fallback;
    }

    private static string? ReadString(string[] args, int index)
    {
        return args.Length > index ? args[index] : null;
    }

    private static string? ReadOption(string[] args, string name)
    {
        for (var i = 0; i < args.Length - 1; i++)
        {
            if (args[i] == name)
            {
                return args[i + 1];
            }
        }

        return null;
    }

    private static void PrintHelp()
    {
        Console.WriteLine("""
        Unity MCP bridge

        Commands:
          status
          instances
          scene
          console [count]
          assets [filterType]
          call <tool> key=value [key=value...]
          call <tool> --params <json>
          create-gameobject <name> [--primitive Cube]
          delete-gameobject <target> [--search-method by_name]
          play-mode on|off

        Environment:
          UNITY_MCP_HOST, UNITY_MCP_HTTP_PORT, UNITY_MCP_TIMEOUT, UNITY_MCP_INSTANCE
        """);
    }
}
