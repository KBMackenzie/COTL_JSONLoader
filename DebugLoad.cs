using COTL_JSONLoader.Data.Skins;
using System.IO;
using Newtonsoft.Json;

namespace COTL_JSONLoader;

internal static class DebugLoad
{
    //public const string DebugDirectory = "JSONLoader_Debug/";
    private static string Folder() => Path.GetDirectoryName(Plugin.myInfo.Location);
    private static string DebugPath(string filename) => Path.Combine(Folder(), filename);

    #region Skins
    public static void MakePlayerSkin()
    {
        PlayerSkinData data = new PlayerSkinData()
        {
            name = "Debug",
            imagePath = "debug_lamb_sheet.png",
            overrides = new OverrideData[]
            {
                new OverrideData("HeadBack", "0, 0, 128, 128"),
                new OverrideData("HeadBackDown", "128, 0, 128, 128"),
                new OverrideData("HeadBackDown_RITUAL", "0, 128, 128, 128"),
                new OverrideData("HeadBackDown_SERMON", "128, 128, 128, 128"),
                new OverrideData("HeadFront", "256, 0, 128, 128"),
                new OverrideData("HeadFrontDown", "256, 128, 128, 128"),
            }
        };

        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(DebugPath("debug_lamb.json"), json);
    }

    public static void MakeFollowerSkin()
    {
        FollowerSkinData data = new FollowerSkinData()
        {
            name = "Debug Follower",
            imagePath = "debug_follower.png",
            overrides = new OverrideData[]
            {
                new OverrideData("HEAD_SKIN_TOP_BACK", "0, 127, 111, 127"),
                new OverrideData("HEAD_SKIN_BTM_BACK", "0, 0, 111, 127"),
                new OverrideData("HEAD_SKIN_TOP", "111, 127, 149, 127"),
                new OverrideData("HEAD_SKIN_BTM", "111, 0, 149, 127")
            },
            colorOverrides = new FollowerColor[]
            {
                new FollowerColor()
                {
                    colorOverrides = new HexColor[]
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
                    }
                },

                new FollowerColor()
                {
                    colorOverrides = new HexColor[]
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
                    }
                },

                new FollowerColor()
                {
                    colorOverrides = new HexColor[]
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
            }
        };

        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(DebugPath("debug_follower.json"), json);
    }

    /*public class DebugFollowerSkin : CustomFollowerSkin
{
    public override string Name => "Debug Skin";

    public override Texture2D Texture =>
        TextureHelper.CreateTextureFromPath(PluginPaths.ResolveAssetPath("debug_sheet.png"));

    public override List<SkinOverride> Overrides => new()
    {
        new SkinOverride("HEAD_SKIN_TOP_BACK", new Rect(0, 127, 111, 127)),
        new SkinOverride("HEAD_SKIN_BTM_BACK", new Rect(0, 0, 111, 127)),
        new SkinOverride("HEAD_SKIN_TOP", new Rect(111, 127, 149, 127)),
        new SkinOverride("HEAD_SKIN_BTM", new Rect(111, 0, 149, 127))
    };

    public override List<WorshipperData.SlotsAndColours> Colors { get; } = new()
    {
        new WorshipperData.SlotsAndColours
        {
            SlotAndColours = new List<WorshipperData.SlotAndColor>
            {
                new("ARM_LEFT_SKIN", new Color(1, 0, 0)),
                new("ARM_RIGHT_SKIN", new Color(1, 0, 0)),
                new("LEG_LEFT_SKIN", new Color(1, 0, 0)),
                new("LEG_RIGHT_SKIN", new Color(1, 0, 0)),
                new("BODY_SKIN", new Color(1, 0, 0)),
                new("BODY_SKIN_BOWED", new Color(1, 0, 0)),
                new("BODY_SKIN_UP", new Color(1, 0, 0)),
                new("HEAD_SKIN_BTM", new Color(1, 0, 0)),
                new("HEAD_SKIN_TOP", new Color(1, 0.5f, 0)),
            }
        },
        new WorshipperData.SlotsAndColours
        {
            SlotAndColours = new List<WorshipperData.SlotAndColor>
            {
                new("ARM_LEFT_SKIN", new Color(0, 1, 0)),
                new("ARM_RIGHT_SKIN", new Color(0, 1, 0)),
                new("LEG_LEFT_SKIN", new Color(0, 1, 0)),
                new("LEG_RIGHT_SKIN", new Color(0, 1, 0)),
                new("BODY_SKIN", new Color(0, 1, 0)),
                new("BODY_SKIN_BOWED", new Color(0, 1, 0)),
                new("BODY_SKIN_UP", new Color(0, 1, 0)),
                new("HEAD_SKIN_BTM", new Color(0, 1, 0)),
                new("HEAD_SKIN_TOP", new Color(0, 1, 0.5f)),
            }
        },
        new WorshipperData.SlotsAndColours
        {
            SlotAndColours = new List<WorshipperData.SlotAndColor>
            {
                new("ARM_LEFT_SKIN", new Color(0, 0, 1)),
                new("ARM_RIGHT_SKIN", new Color(0, 0, 1)),
                new("LEG_LEFT_SKIN", new Color(0, 0, 1)),
                new("LEG_RIGHT_SKIN", new Color(0, 0, 1)),
                new("BODY_SKIN", new Color(0, 0, 1)),
                new("BODY_SKIN_BOWED", new Color(0, 0, 1)),
                new("BODY_SKIN_UP", new Color(0, 0, 1)),
                new("HEAD_SKIN_BTM", new Color(0, 0, 1)),
                new("HEAD_SKIN_TOP", new Color(0.5f, 0, 1)),
            }
        }
    };
}*/

    #endregion
}
