using TMPro;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] private ItemType _itemType;
    private int _quantity;
    private TextMeshProUGUI _info;

    public ItemType ItemType => _itemType;

    private void Start()
    {
        _quantity = 0;
        _info = GetComponent<TextMeshProUGUI>();
        _info.SetText($"{_itemType} x {_quantity}");
    }

    public void UpdateQuantity(int itemQuantity)
    {
        _quantity = itemQuantity;
        _info.SetText($"{_itemType} x {_quantity}");
    }
}
