using System.Linq;
using COTL_API.CustomSkins;
using COTL_JSONLoader.Helpers;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
#nullable enable

namespace COTL_JSONLoader.Data.Skins;

internal class PlayerSkinDummy : CustomPlayerSkin
{
    public string name, imagePath;
    public OverrideData[] overrideData;
    public override string Name => name;
    public override Texture2D Texture => AssetHelpers.Load(imagePath);
    public override List<SkinOverride> Overrides => overrideData.Select(x => x.CreateOverride()).ToList();

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
    public List<HexColor[]>? colors;
    public override string Name => name;
    public override Texture2D Texture => AssetHelpers.Load(imagePath);
    public override List<SkinOverride> Overrides => overrideData.Select(x => x.CreateOverride()).ToList();
    public override List<WorshipperData.SlotsAndColours> Colors => GenerateColors() ?? base.Colors;

    public FollowerSkinDummy(string name, string imagePath, OverrideData[] overrideData,
        List<HexColor[]>? colors = null)
    {
        this.name = name;
        this.imagePath = imagePath;
        this.overrideData = overrideData;
        this.colors = colors;
    }

    public List<WorshipperData.SlotsAndColours>? GenerateColors()
    {
        return colors?.Select(x => new WorshipperData.SlotsAndColours()
        {
            SlotAndColours = x.Select(y => y.CreateColor()).ToList()
        })?.ToList();
    }
}
