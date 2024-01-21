using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gold;
    public List<Item> items;

    // New game state.
    public GameData()
    {
        this.gold = 0;
        this.items = new List<Item>();
    }

}
