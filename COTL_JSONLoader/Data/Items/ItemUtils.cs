using COTL_API.CustomInventory;
using COTL_JSONLoader.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace COTL_JSONLoader.Data.Items;

internal static class ItemUtils
{
    // Enum dictionaries, automatically generated.
    // (Because this is faster than casting string to enum value every time.)

    public readonly static EnumDictionary<InventoryItem.ITEM_CATEGORIES> ItemCategories = new();
    public readonly static EnumDictionary<InventoryItem.ITEM_TYPE> ItemTypes = new();
    public readonly static EnumDictionary<CustomItemManager.ItemRarity> ItemRarity = new();
    public readonly static EnumDictionary<CookingData.MealEffectType> MealEffects = new();
    public readonly static EnumDictionary<FollowerCommands> FollowerCommands = new();


}
