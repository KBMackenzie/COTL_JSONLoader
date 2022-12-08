using COTL_API.CustomInventory;
using Newtonsoft.Json;

#pragma warning disable CS8618

namespace COTL_JSONLoader.Data.Items;

public class ItemData
{
    [JsonProperty("internalName")]
    public string? InternalName { get; set; }

    [JsonProperty("sprite")]
    public string? Sprite { get; set; }

    [JsonProperty("inventoryIcon")]
    public string? InventoryIcon { get; set; }

    [JsonProperty("localizedName")]
    public string? LocalizedName { get; set; }

    [JsonProperty("localizedDescription")]
    public string? LocalizedDescription { get; set; }

    [JsonProperty("localizedLore")]
    public string? LocalizedLore { get; set; }

    [JsonProperty("itemCategory")]
    public string? ItemCategory { get; set; }

    [JsonProperty("itemPickUpToImitate")]
    public string ItemPickUpToImitate { get; set; }

    [JsonProperty("seedType")]
    public string SeedType { get; set; }

    [JsonProperty("fuelWeight")]
    public int? FuelWeight { get; set; }

    [JsonProperty("foodSatitation")]
    public int? FoodSatitation { get; set; }

    [JsonProperty("isFood")]
    public bool? IsFood { get; set; }

    [JsonProperty("isFish")]
    public bool? IsFish { get; set; }

    [JsonProperty("isBigFish")]
    public bool? IsBigFish { get; set; }

    [JsonProperty("isCurrency")]
    public bool? IsCurrency { get; set; }

    [JsonProperty("isSeed")]
    public bool? IsSeed { get; set; }

    [JsonProperty("isPlantable")]
    public bool? IsPlantable { get; set; }

    [JsonProperty("isBurnableFuel")]
    public bool? IsBurnableFuel { get; set; }

    [JsonProperty("canBeGivenToFollower")]
    public bool? CanBeGivenToFollower { get; set; }

    [JsonProperty("giftCommand")]
    public string GiftCommand { get; set; }

    [JsonProperty("rarity")]
    public string Rarity { get; set; }

    [JsonProperty("canBeRefined")]
    public bool? CanBeRefined { get; set; }

    [JsonProperty("refineryInput")]
    public string RefineryInput { get; set; }

    [JsonProperty("refineryInputQty")]
    public int? RefineryInputQty { get; set; }

    [JsonProperty("customRefineryDuration")]
    public float? CustomRefineryDuration { get; set; }

    public InventoryItem.ITEM_CATEGORIES GetItemCategory() => ItemUtils.ItemCategories.Get(ItemCategory);
    public InventoryItem.ITEM_TYPE GetSeedType() => ItemUtils.ItemTypes.Get(SeedType);
    public InventoryItem.ITEM_TYPE GetItemPickup() => ItemUtils.ItemTypes.Get(ItemPickUpToImitate);
    public InventoryItem.ITEM_TYPE GetRefineryInput() => ItemUtils.ItemTypes.Get(RefineryInput);
    public CustomItemManager.ItemRarity GetRarity() => ItemUtils.ItemRarity.Get(Rarity);
    public FollowerCommands GetGiftCommand() => ItemUtils.FollowerCommands.Get(GiftCommand);
}


public class MealData
{
    [JsonProperty("mealEffect")]
    public string MealEffect { get; set; }

    [JsonProperty("chance")]
    public string Chance { get; set; }

    public CookingData.MealEffect CreateMealEffect() => new()
    {
        MealEffectType = ItemUtils.MealEffects.Get(MealEffect),
        Chance = Int32.TryParse(Chance.Trim(), out int x) ? x : 0
    };
}
