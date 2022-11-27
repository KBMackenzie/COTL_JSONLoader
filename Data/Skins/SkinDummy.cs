using System.Linq;
using COTL_API.CustomSkins;
using COTL_JSONLoader.Helpers;
using System.Collections.Generic;
using UnityEngine;
#nullable enable

namespace COTL_JSONLoader.Data.Skins;

internal class PlayerSkinDummy : CustomPlayerSkin
{
    public string name, imagePath;
    public OverrideData[] overrideData;
    public override string Name => name;
    public override Texture2D Texture => AssetHelpers.Load(imagePath);
    public override List<SkinOverride> Overrides => overrideData.Select(x => x.Create()).ToList();

    public PlayerSkinDummy(string name, string imagePath, OverrideData[] overrideData)
    {
        this.name = name;
        this.imagePath = imagePath;
        this.overrideData = overrideData;
    }



    /*List<SkinOverride> overrides = new List<SkinOverride>();
            foreach(OverrideData data in overrideData)
            {
                overrides.Add();
            }
            return overrides;*/
}

internal class FollowerSkinDummy : CustomFollowerSkin
{
    public string name, imagePath;
    public OverrideData[] overrideData;
    public FollowerColor[]? colors;
    public override string Name => name;
    public override Texture2D Texture => AssetHelpers.Load(imagePath);
    public override List<SkinOverride> Overrides => overrideData.Select(x => x.Create()).ToList();
    public override List<WorshipperData.SlotsAndColours> Colors => colors?.Select(x => x.Create())?.ToList()
                                                                   ?? base.Colors;

    public FollowerSkinDummy(string name, string imagePath, OverrideData[] overrideData,
        FollowerColor[]? colors = null)
    {
        this.name = name;
        this.imagePath = imagePath;
        this.overrideData = overrideData;
        this.colors = colors;
    }
}
