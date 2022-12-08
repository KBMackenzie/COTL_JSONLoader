using COTL_JSONLoader.Data.Skins;
using Newtonsoft.Json;

namespace COTL_JSONLoader;

internal static class DebugLoad
{
    //public const string DebugDirectory = "JSONLoader_Debug/";
    private static string Folder() => Path.GetDirectoryName(Plugin.Instance?.Info.Location ?? string.Empty);
    private static string DebugPath(string filename) => Path.Combine(Folder(), filename);

    #region Skins
    internal static void MakePlayerSkin()
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

        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(DebugPath("debug_lamb.json"), json);
    }

    internal static void MakeFollowerSkin()
    {
        FollowerSkinData data = new FollowerSkinData()
        {
            Name = "Debug Follower",
            ImagePath = "debug_follower.png",
            Overrides = new OverrideData[]
            {
                new OverrideData("HEAD_SKIN_TOP_BACK", "0, 127, 111, 127"),
                new OverrideData("HEAD_SKIN_BTM_BACK", "0, 0, 111, 127"),
                new OverrideData("HEAD_SKIN_TOP", "111, 127, 149, 127"),
                new OverrideData("HEAD_SKIN_BTM", "111, 0, 149, 127")
            },
            Colors = new List<HexColor[]>
            {
                new HexColor[]
                {
                    new HexColor("ARM_LEFT_SKIN", "#FF0000"),
                    new HexColor("ARM_RIGHT_SKIN", "#FF0000"),
                    new HexColor("LEG_LEFT_SKIN", "#FF0000"),
                    new HexColor("LEG_RIGHT_SKIN", "#FF0000"),
                    new HexColor("BODY_SKIN", "#FF0000"),
                    new HexColor("BODY_SKIN_BOWED", "#FF0000"),
                    new HexColor("BODY_SKIN_UP", "#FF0000"),
                    new HexColor("HEAD_SKIN_BTM", "#FF0000"),
                    new HexColor("HEAD_SKIN_TOP", "#FF7F00"),
                },

                new HexColor[]
                {
                    new HexColor("ARM_LEFT_SKIN", "#00FF00"),
                    new HexColor("ARM_RIGHT_SKIN", "#00FF00"),
                    new HexColor("LEG_LEFT_SKIN", "#00FF00"),
                    new HexColor("LEG_RIGHT_SKIN", "#00FF00"),
                    new HexColor("BODY_SKIN", "#00FF00"),
                    new HexColor("BODY_SKIN_BOWED", "#00FF00"),
                    new HexColor("BODY_SKIN_UP", "#00FF00"),
                    new HexColor("HEAD_SKIN_BTM", "#00FF00"),
                    new HexColor("HEAD_SKIN_TOP", "#00FF7F"),
                },

                new HexColor[]
                {
                    new HexColor("ARM_LEFT_SKIN", "#0000FF"),
                    new HexColor("ARM_RIGHT_SKIN", "#0000FF"),
                    new HexColor("LEG_LEFT_SKIN", "#0000FF"),
                    new HexColor("LEG_RIGHT_SKIN", "#0000FF"),
                    new HexColor("BODY_SKIN", "#0000FF"),
                    new HexColor("BODY_SKIN_BOWED", "#0000FF"),
                    new HexColor("BODY_SKIN_UP", "#0000FF"),
                    new HexColor("HEAD_SKIN_BTM", "#0000FF"),
                    new HexColor("HEAD_SKIN_TOP", "#7F00FF"),
                }
            }
        };

        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(DebugPath("debug_follower.json"), json);
    }
    #endregion


}
