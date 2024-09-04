using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ChestConfig
{
    public string Name;
    public GameObject ChestPrefab;
    public float DropChance;
    public List<Item> Items;
}
