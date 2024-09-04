using System;
using System.Collections.Generic;
using UnityEngine;

public class ChestController
{
    private ChestModel _chest;
    private ChestView _chestView;

    public ChestView ChestView => _chestView;

    public event Action ChestClicked;

    public ChestController(ChestModel chest, ChestView chestView)
    {
        _chest = chest;
        _chestView = chestView;

        _chestView.Clicked += OnChestClicked;
    }

    private void OnChestClicked()
    {
        ChestClicked?.Invoke();
    }

    public void Open()
    {
        _chestView.Open();
        _chestView.SpawnAddedItemText(_chest.Items);
    }

    public List<Item> GetItems()
    {
        return _chest.Items;
    }

    public GameObject GetPrefab() 
    {
        return _chest.ChestPrefab;
    }

    public void DisableCollider()
    {
        _chestView.GetComponent<Collider>().enabled = false;
    }
}
