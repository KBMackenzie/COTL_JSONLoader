using COTL_JSONLoader.Helpers;
using System.Linq;
using COTL_API.CustomSkins;
using UnityEngine;
#pragma warning disable CS0649

namespace COTL_JSONLoader.Data.Skins;

[System.Serializable]
internal class PlayerSkinData
{
    public string name;
    public string imagePath;
    public OverrideData[] overrides;
    public PlayerSkinDummy CreateSkin() => new(name, imagePath, overrides);
}

[System.Serializable]
internal class FollowerSkinData
{
    public string name;
    public string imagePath;
    public OverrideData[] overrides;
    public FollowerColor[] colorOverrides;

    public FollowerSkinDummy CreateSkin() => new(name, imagePath, overrides, colorOverrides);
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
    public string hex;
    public Color GetColor() => AssetHelpers.HexToColor(hex);
    public WorshipperData.SlotAndColor CreateColor() => new(name, GetColor());

    public HexColor(string name, string hex)
    {
        this.name = name;
        this.hex = hex;
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