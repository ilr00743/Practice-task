using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerInventory _inventory;
    private Camera _camera;

    public PlayerInput Input => _input;

    public event Action ItemsAdded;

    private void Awake()
    {
        _camera = Camera.main;
        _inventory = new PlayerInventory();
        _input = new PlayerInput(_camera, new MouseInput());
    }

    private void Update()
    {
        _input.Update();
    }

    public Dictionary<ItemType, int> GetInventory()
    {
        return _inventory.GetInventory();
    }

    public void AddItemsToInventory(List<Item> items)
    {
        _inventory.AddItems(items);
        ItemsAdded?.Invoke();
    }
}
