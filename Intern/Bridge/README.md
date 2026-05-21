# Unity MCP Bridge

Agent-side bridge for controlling `InternUnity` through MCP for Unity without moving the agent framework into the Unity project.

## Architecture

Transport flow:

`Agent -> Intern/Bridge/UnityMcpBridge.cs -> http://127.0.0.1:8080/api/command -> MCP for Unity server -> WebSocket /hub/plugin -> Unity Editor package -> Unity Editor`

The Unity project only needs the existing `com.coplaydev.unity-mcp` package. The bridge stays in `Intern/Bridge/` and talks to the running MCP server over local HTTP. The server owns the Unity-side WebSocket and tool registry.

Primary runnable implementation in this workspace:

- `Intern/Bridge/UnityMcpBridge.cs`
- `Intern/Program.cs`

Portable Python reference:

- `Intern/Bridge/unity_mcp_bridge.py`

## Setup

1. Open `InternUnity` in Unity.
2. Open `Window > MCP For Unity`.
3. Click `Auto-Setup` if needed.
4. Start the bridge/server if it is stopped.
5. Confirm the local server is reachable:

```powershell
dotnet run --project Intern/Intern.csproj -- status
```

Environment overrides:

```powershell
$env:UNITY_MCP_HOST = "127.0.0.1"
$env:UNITY_MCP_HTTP_PORT = "8080"
$env:UNITY_MCP_TIMEOUT = "30"
$env:UNITY_MCP_INSTANCE = "InternUnity@<project-hash>"
```

`UNITY_MCP_INSTANCE` is only needed when more than one Unity project is connected.

## Minimal Commands

Read status:

```powershell
dotnet run --project Intern/Intern.csproj -- status
```

List connected Unity editors:

```powershell
dotnet run --project Intern/Intern.csproj -- instances
```

Inspect active scene and hierarchy:

```powershell
dotnet run --project Intern/Intern.csproj -- scene
```

Call a raw MCP for Unity tool:

```powershell
dotnet run --project Intern/Intern.csproj -- call manage_scene action=get_active
dotnet run --project Intern/Intern.csproj -- call read_console action=get count=10
dotnet run --project Intern/Intern.csproj -- call manage_asset action=search path=Assets filterType=Scene pageSize=10 pageNumber=1 generatePreview=false
```

Mutating examples:

```powershell
dotnet run --project Intern/Intern.csproj -- create-gameobject AgentBridgeProbe --primitive Cube
dotnet run --project Intern/Intern.csproj -- delete-gameobject AgentBridgeProbe --search-method by_name
```

C# use:

```csharp
using Intern.Bridge;

var unity = new UnityMcpBridge();
await unity.WaitUntilReadyAsync(TimeSpan.FromSeconds(20));
await unity.InspectSceneAsync();
await unity.CreateGameObjectAsync("AgentBridgeProbe", primitiveType: "Cube");
await unity.DeleteGameObjectAsync("AgentBridgeProbe", searchMethod: "by_name");
```

## Supported Surface

- Scene inspection: `InspectSceneAsync()`, `manage_scene`
- GameObject creation/modification/deletion: `CreateGameObjectAsync()`, `ModifyGameObjectAsync()`, `DeleteGameObjectAsync()`, `manage_gameobject`
- Component access/control: `ManageComponentAsync()`, `manage_components`
- Play mode: `SetPlayModeAsync(true/false)`, `manage_editor`
- Asset/database queries: `SearchAssetsAsync()`, `manage_asset`
- Debugging: `HealthAsync()`, `ListInstancesAsync()`, `PingAsync()`, `ReadConsoleAsync()`

## Error Handling

The bridge retries transient connection failures with backoff. Unity reload/compile windows can return retry hints; these are surfaced as `UnityMcpBridgeException` so the caller can retry the whole operation or call `WaitUntilReadyAsync()`.

## Troubleshooting

- `Cannot reach Unity MCP`: open Unity, then `Window > MCP For Unity`, and start the bridge/server.
- `No Unity plugins are currently connected`: the HTTP server is alive but the Unity Editor package WebSocket is not connected. Restart `Start Bridge` in the MCP window.
- Multiple instances connected: run `instances`, then set `UNITY_MCP_INSTANCE` to `Name@hash`.
- Commands time out: Unity may be compiling, reloading assemblies, or blocked by a modal dialog. Run `status` and `read_console`.
- Port mismatch: MCP for Unity defaults to `8080` in this project. Set `UNITY_MCP_HTTP_PORT` if the Unity window shows another port.
