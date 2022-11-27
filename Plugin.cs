using System.Linq;
using BepInEx;
using BepInEx.Logging;
using COTL_JSONLoader.Data.Skins;
using System.IO;
using BepInEx.Configuration;

namespace COTL_JSONLoader;

[BepInPlugin(PluginGuid, PluginName, PluginVer)]
public class Plugin : BaseUnityPlugin
{
    public const string PluginGuid = "kel.cotl.jsonloader";
    public const string PluginName = "COTL_JSONLoader";
    public const string PluginVer = "1.0.0";

    internal static ManualLogSource myLogger;
    internal static PluginInfo myInfo;
    internal static ConfigFile myConfig;

    internal static ConfigEntry<bool> Debug;

    private void Awake()
    {
        myLogger = Logger; // Make log source
        myInfo = Info;
        myConfig = Config;

        LoadConfig();
        if(Debug.Value) LoadDebug();

        LoadFiles();
        Logger.LogInfo($"Loaded {PluginName} successfully!");
    }

    internal static void Log(string x) => myLogger.LogInfo(x);
    internal static void LogError(string x) => myLogger.LogError(x);

    internal static void LoadConfig()
    {
        Debug = myConfig.Bind("General.Debug", "Debug", false,
                              "Enable creating and loading basic debug files.");
    }

    internal static void LoadFiles()
    {
        // The intent is to do only one search in the directory and then filter the JSON files by name.
        // I feel this would be faster than searching the BepInEx/plugins directory multiple times.

        string[] files = Directory.GetFiles(Paths.PluginPath, "*.json", SearchOption.AllDirectories);
        if (files.Length == 0) return;

        string[] lambSkin = files.Where(x => x.EndsWith("_lamb.json")).ToArray();
        LoadSkins.LoadPlayerSkins(lambSkin);

        string[] followerSkin = files.Where(x => x.EndsWith("_follower.json")).ToArray();
        LoadSkins.LoadFollowerSkins(followerSkin);
    }

    internal static void LoadDebug()
    {
        DebugLoad.MakePlayerSkin();
        DebugLoad.MakeFollowerSkin();
    }
}