using System.Collections.Generic;
using UnityEngine;

public class ChestModel
{
    public string Name { get; private set; }
    public GameObject ChestPrefab { get; private set; }
    public float DropChance { get; private set; }
    private List<Item> _items;

    public IReadOnlyList<Item> Items => _items;

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

        _items ??= new List<Item>();

        _items.Add(item);
    }
}
