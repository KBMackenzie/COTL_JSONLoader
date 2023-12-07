using COTL_JSONLoader.Helpers;
using COTL_API.CustomSkins;
using Newtonsoft.Json;
using UnityEngine;

#pragma warning disable CS0649
#pragma warning disable CS8618

namespace COTL_JSONLoader.Data.Skins;

public class SkinData
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("imagePath")]
    public string ImagePath { get; set; }

    [JsonProperty("overrides")]
    public OverrideData[] Overrides { get; set; }
}

[Serializable]
public class PlayerSkinData : SkinData
{
    public PlayerSkinDummy CreateSkin() => new(Name, ImagePath, Overrides);
}

[Serializable]
public class FollowerSkinData : SkinData
{
    [JsonProperty("colors")]
    public List<HexColor[]> Colors { get; set; }

    public FollowerSkinDummy CreateSkin() => new(Name, ImagePath, Overrides, Colors);
}

[Serializable]
public class HexColor
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("hex")]
    public string Hex { get; set; }

    public Color GetColor() => AssetHelpers.HexToColor(Hex);
    public WorshipperData.SlotAndColor CreateColor() => new(Name, GetColor());

    public HexColor(string name, string hex)
    {
        this.Name = name;
        this.Hex = hex;
    }
}

[Serializable]
public class OverrideData
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("rect")]
    public string Rect { get; set; }

    [JsonProperty("scale")] public string Scale { get; set; } = "1, 1";
    
    [JsonProperty("offset")]
    public string Offset { get; set; } = "0, 0";

    public CustomSkin.SkinOverride CreateOverride() => new(Name, AssetHelpers.ToRect(Rect), AssetHelpers.ToVector2(Scale), AssetHelpers.ToVector2(Offset));
    
    public OverrideData(string name, string rect)
    {
        this.Name = name;
        this.Rect = rect;
    }
}