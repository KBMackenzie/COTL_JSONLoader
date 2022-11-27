using COTL_JSONLoader.Data.Skins;
using System.IO;
using BepInEx;
using COTL_API.CustomSkins;
using COTL_API.Helpers;
using static COTL_API.CustomSkins.CustomSkin;
using System.Collections.Generic;
using UnityEngine;
using COTL_JSONLoader.Helpers;

namespace COTL_JSONLoader;

internal static class DebugLoad
{
    //public const string DebugDirectory = "JSONLoader_Debug/";
    private static string Folder() => Path.GetDirectoryName(Plugin.myInfo.Location);
    private static string DebugPath(string filename) => Path.Combine(Folder(), filename);

    public static void LoadSkins()
    {
        PlayerSkinData data = new PlayerSkinData()
        {
            Name = "Debug",
            ImagePath = "debug_lamb_sheet.png",
            Overrides = new OverrideData[]
            {
                new OverrideData("HeadBack", "0, 0, 128, 128"),
                new OverrideData("HeadBackDown", "128, 0, 128, 128"),
                new OverrideData("HeadBackDown_RITUAL", "0, 128, 128, 128"),
                new OverrideData("HeadBackDown_SERMON", "128, 128, 128, 128"),
                new OverrideData("HeadFront", "256, 0, 128, 128"),
                new OverrideData("HeadFrontDown", "256, 128, 128, 128"),
            }
        };

        string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        File.WriteAllText(DebugPath("debug_lamb.json"), json);
    }
}
