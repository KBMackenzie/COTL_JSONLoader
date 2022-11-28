using COTL_JSONLoader.Data.Skins;
using BepInEx.Configuration;
using BepInEx;

namespace COTL_JSONLoader;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
[BepInDependency("io.github.xhayper.COTL_API")]
public class Plugin : BaseUnityPlugin
{
    public const string PluginGuid = "kel.cotl.jsonloader";
    public const string PluginName = "COTL_JSONLoader";
    public const string PluginVersion = "1.0.0";

    public static Plugin? Instance;

    internal static ConfigEntry<bool>? Debug;

    private void Awake()
    {
        Instance = this;

        LoadConfig();
        if (Debug != null && Debug.Value) LoadDebug();

        LoadFiles();
        Logger.LogInfo($"Loaded {PluginName} successfully!");
    }

    internal static void LogInfo(string x) => Instance?.Logger.LogInfo(x);
    internal static void LogError(string x) => Instance?.Logger.LogError(x);

    internal static void LoadConfig()
    {
        Debug = Instance?.Config.Bind("General.Debug", "Debug", false,
                              "Enable creating and loading basic debug files.");
    }

    internal static void LoadFiles()
    {
        // The intent is to do only one search in the directory and then filter the JSON files by name.
        // I feel this would be faster than searching the BepInEx/plugins directory multiple times.

        string[] files = Directory.GetFiles(Paths.PluginPath, "*.json", SearchOption.AllDirectories).Concat(Directory.GetFiles(Paths.PluginPath, "*.jsonc", SearchOption.AllDirectories)).ToArray();
        if (files.Length == 0) return;

        string[] lambSkin = files.Where(x => x.EndsWith("_lamb.json") || x.EndsWith("_lamb.jsonc")).ToArray();
        LoadSkins.LoadPlayerSkins(lambSkin);

        string[] followerSkin = files.Where(x => x.EndsWith("_follower.json") || x.EndsWith("_lamb.jsonc")).ToArray();
        LoadSkins.LoadFollowerSkins(followerSkin);
    }

    internal static void LoadDebug()
    {
        DebugLoad.MakePlayerSkin();
        DebugLoad.MakeFollowerSkin();
    }
}