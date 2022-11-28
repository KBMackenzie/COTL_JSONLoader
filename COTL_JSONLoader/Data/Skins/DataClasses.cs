using COTL_JSONLoader.Helpers;
using COTL_API.CustomSkins;
using UnityEngine;

#pragma warning disable CS0649
#pragma warning disable CS8618

namespace COTL_JSONLoader.Data.Skins;

[Serializable]
public class PlayerSkinData
{
    public string name;
    public string imagePath;
    public OverrideData[] overrides;
    public PlayerSkinDummy CreateSkin() => new(name, imagePath, overrides);
}

[Serializable]
public class FollowerSkinData
{
    public string name;
    public string imagePath;
    public OverrideData[] overrides;
    public List<HexColor[]> colors;

    public FollowerSkinDummy CreateSkin() => new(name, imagePath, overrides, colors);
}

[Serializable]
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

[Serializable]
public class OverrideData
{
    public string name, rect;
    public CustomSkin.SkinOverride CreateOverride() => new(name, AssetHelpers.ToRect(rect));
    public OverrideData(string name, string rect)
    {
        this.name = name;
        this.rect = rect;
    }
}