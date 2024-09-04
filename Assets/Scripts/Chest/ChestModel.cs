using System.Collections.Generic;
using UnityEngine;

public class ChestModel
{
    public string Name;
    public GameObject ChestPrefab;
    public float DropChance;
    public List<Item> Items;

    public ChestModel() { }

    public ChestModel(string name, GameObject chestPrefab, float dropChance)
    {
        Name = name;
        ChestPrefab = chestPrefab;
        DropChance = dropChance;
    }

    public void AddItem(Item item)
    {
        if (item == null) 
        {
            Debug.LogError("Item you try to add to chest is null");
        }

        Items ??= new List<Item>();

        Items.Add(item);
    }
}
