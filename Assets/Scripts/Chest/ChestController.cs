﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestController
{
    private ChestModel _chest;
    private ChestView _chestView;

    public ChestView ChestView => _chestView;

    public ChestController(ChestModel chest, ChestView chestView)
    {
        _chest = chest;
        _chestView = chestView;
    }

    public void Open()
    {
        _chestView.Open();
        _chestView.SpawnAddedItemText(_chest.Items.ToList());
    }

    public List<Item> GetItems()
    {
        return _chest.Items.ToList();
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
