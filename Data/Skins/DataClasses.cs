using COTL_JSONLoader.Helpers;
using System.Linq;
using COTL_API.CustomSkins;
using UnityEngine;

namespace COTL_JSONLoader.Data.Skins;

internal class PlayerSkinData
{
    public string Name;
    public string ImagePath;
    public OverrideData[] Overrides;
    public PlayerSkinDummy Create() => new(Name, ImagePath, Overrides);
}

internal class FollowerSkinData
{
    public string Name;
    public string ImagePath;
    public OverrideData[] Overrides;
    public FollowerColor[] Colors;

    public FollowerSkinDummy Create() => new(Name, ImagePath, Overrides, Colors);
}

public class FollowerColor
{
    public HexColor[] colorOverrides;
    public WorshipperData.SlotsAndColours Create() => new()
    {
        SlotAndColours = colorOverrides.Select(x => x.Create()).ToList()
    };
}

public class HexColor
{
    public string hexcode;
    public string overrideName;
    public Color GetColor() => AssetHelpers.HexToColor(hexcode);
    public WorshipperData.SlotAndColor Create() => new(overrideName, GetColor());
}

internal class OverrideData
{
    public string overrideName, imageArea;
    public CustomSkin.SkinOverride Create() => new(overrideName, AssetHelpers.ToRect(imageArea));
}

internal enum Override
{
    HEAD_SKIN_TOP,
    HEAD_SKIN_BTM,
    HEAD_SKIN_TOP_BACK,
    HEAD_SKIN_BTM_BACK,

}

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
