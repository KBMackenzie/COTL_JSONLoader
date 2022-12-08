using COTL_API.CustomInventory;
using COTL_JSONLoader.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace COTL_JSONLoader.Data.Items
{
    internal class ItemDummy : CustomInventoryItem
    {
        private readonly ItemData? ItemData;

        public ItemDummy(ItemData? itemData)
        {
            ItemData = itemData;
        }

        public override string InternalName => $"{Plugin.PluginGuid}_{ItemData?.InternalName ?? string.Empty}";

        public override Sprite Sprite => AssetHelpers.SpriteNullable(ItemData?.Sprite) ?? base.InventoryIcon;
        public override Sprite InventoryIcon => AssetHelpers.SpriteNullable(ItemData?.InventoryIcon) ?? base.InventoryIcon;

        public override string LocalizedName() => ItemData?.LocalizedName ?? base.LocalizedName();
        public override string LocalizedLore() => ItemData?.LocalizedLore ?? base.LocalizedLore();
        public override string LocalizedDescription() => ItemData?.LocalizedDescription ?? base.LocalizedDescription();

        public override InventoryItem.ITEM_CATEGORIES ItemCategory => ItemData?.GetItemCategory() ?? base.ItemCategory;
        public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => ItemData?.GetItemPickup() ?? base.ItemPickUpToImitate;
        public override InventoryItem.ITEM_TYPE SeedType => ItemData?.GetSeedType() ?? base.SeedType;
        public override bool CanBeRefined => ItemData?.CanBeRefined ?? base.CanBeRefined;
    }
}
