using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IDataPersistence
{

    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();
    public int gold = 0;

    public Transform itemContent;
    public GameObject inventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // preload existing items
        for (int i = 0; i < items.Count; i++)
        {
            InsertItem(items[i]);
        }

    }

    public void Add(Item item)
    {
        items.Add(item);
        InsertItem(item);
    }

    void InsertItem(Item item)
    {
        // Instantiate inventoryItem
        GameObject obj = Instantiate(inventoryItem, itemContent);
        var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

        // Update from scriptableObject
        obj.GetComponent<InventoryItem>().itemInfo = item;
        itemName.text = item.itemName;
        itemIcon.sprite = item.icon;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

    }

    public void SaveData(ref GameData gameData)
    {
        gameData.gold = gold;
        gameData.items = items;

    }

    public void LoadData(GameData gameData)
    {
        gold = gameData.gold;

        foreach (var item in gameData.items)
        {
            Add(item);
        }
    }
    

}
