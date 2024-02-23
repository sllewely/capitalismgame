using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gold;
    public List<Item> items;

    // Story beats
    public bool openingConversation;
    
    
    // New game state.
    public GameData()
    {
        this.gold = 0;
        this.items = new List<Item>();
        this.openingConversation = false;
    }

}
