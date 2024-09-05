using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : IInventory
{
    private Dictionary<ItemType, int> _itemQuantityPairs = new();

    public void AddItems(List<Item> items)
    {
        foreach (var item in items)
        {
            if (_itemQuantityPairs.ContainsKey(item.ItemType))
            {
                _itemQuantityPairs[item.ItemType] += item.Quantity;
            }
            else
            {
                _itemQuantityPairs[item.ItemType] = item.Quantity;
            }

            Debug.Log($"Added {item.Quantity}x {item.ItemType} to inventory.");
        }
    }

    public Dictionary<ItemType, int> GetInventory()
    {
        return _itemQuantityPairs;
    }
}