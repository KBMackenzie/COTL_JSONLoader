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
        CustomSkinManager.AddPlayerSkin(new DebugPlayerSkin());
        return; // TODO: Remove return and what's above it

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

    // Temporary, adding this just because I kept getting errors with skins in the API.
    // There's a bug with the API Skin Settings menu currently, I think. ><;
    public class DebugPlayerSkin : CustomPlayerSkin
    {
        public override string Name => "Debug Skin";

        public override Texture2D Texture => AssetHelpers.Load("debug_lamb_sheet.png");

        public override List<SkinOverride> Overrides => new()
    {
        new SkinOverride("HeadBack", new Rect(0, 0, 128, 128)),
        new SkinOverride("HeadBackDown", new Rect(128, 0, 128, 128)),
        new SkinOverride("HeadBackDown_RITUAL", new Rect(0, 128, 128, 128)),
        new SkinOverride("HeadBackDown_SERMON", new Rect(128, 128, 128, 128)),
        new SkinOverride("HeadFront", new Rect(256, 0, 128, 128)),
        new SkinOverride("HeadFrontDown", new Rect(256, 128, 128, 128))
    };
    }
}
