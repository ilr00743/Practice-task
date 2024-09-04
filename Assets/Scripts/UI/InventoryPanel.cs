using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private List<ItemInfo> _itemsInfo;
    [SerializeField] private Player _player;

    private void Start()
    {
        _player.ItemsAdded += UpdateInventoryInfo;
    }

    private void UpdateInventoryInfo()
    {
        foreach (var item in _player.GetInventory())
        {
            var itemInfo = _itemsInfo.Where(i => i.ItemType == item.Key).First();
            itemInfo.UpdateQuantity(item.Value);
        }
    }
}
