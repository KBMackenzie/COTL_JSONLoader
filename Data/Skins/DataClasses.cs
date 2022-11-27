using COTL_JSONLoader.Helpers;
using System.Linq;
using COTL_API.CustomSkins;
using UnityEngine;
#pragma warning disable CS0649

namespace COTL_JSONLoader.Data.Skins;

[System.Serializable]
internal class PlayerSkinData
{
    public string Name;
    public string ImagePath;
    public OverrideData[] Overrides;
    public PlayerSkinDummy CreateSkin() => new(Name, ImagePath, Overrides);
}

[System.Serializable]
internal class FollowerSkinData
{
    public string Name;
    public string ImagePath;
    public OverrideData[] Overrides;
    public FollowerColor[] Colors;

    public FollowerSkinDummy CreateSkin() => new(Name, ImagePath, Overrides, Colors);
}

public class FollowerColor
{
    public HexColor[] colorOverrides;
    public WorshipperData.SlotsAndColours CreateColors() => new()
    {
        SlotAndColours = colorOverrides.Select(x => x.CreateColor()).ToList()
    };
}

public class HexColor
{
    public string name;
    public string hexcode;
    public Color GetColor() => AssetHelpers.HexToColor(hexcode);
    public WorshipperData.SlotAndColor CreateColor() => new(name, GetColor());

    public HexColor(string name, string hexcode)
    {
        this.name = name;
        this.hexcode = hexcode;
    }
}

internal class OverrideData
{
    public string name, rect;
    public CustomSkin.SkinOverride CreateOverride() => new(name, AssetHelpers.ToRect(rect));
    public OverrideData(string name, string rect)
    {
        this.name = name;
        this.rect = rect;
    }
}

/*internal enum Override
{
    HEAD_SKIN_TOP,
    HEAD_SKIN_BTM,
    HEAD_SKIN_TOP_BACK,
    HEAD_SKIN_BTM_BACK,

}*/

/*
internal class OverrideData
{
    public Override type;
    public Rect rect;
    public SkinOverride Create() => new SkinOverride(type.ToString(), rect);
}

internal enum Override
{
    HEAD_SKIN_TOP,
    HEAD_SKIN_BTM,
    HEAD_SKIN_TOP_BACK,
    HEAD_SKIN_BTM_BACK,

}*/

/*
 So:
    - We registr an INSTANCE of the FollowerSkin whatever.
    - The overrides are all instances of an override. KEEP THAT IN MIND. > X<;
 */
