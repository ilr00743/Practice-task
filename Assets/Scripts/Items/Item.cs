using UnityEngine;

[System.Serializable]
public class Item
{
    [field: SerializeField] public ItemType ItemType { get; set; }
    [field: SerializeField] public int Quantity { get; set; }
    [field: SerializeField] public int DropChance { get; set; }

    public Item (ItemType itemType, int quantity, int dropChance)
    {
        ItemType = itemType;
        Quantity = quantity;
        DropChance = dropChance;
    }
}

public enum ItemType
{
    Ring,
    Sword,
    MannaPotion,
    HealthPotion,
    Gold
}