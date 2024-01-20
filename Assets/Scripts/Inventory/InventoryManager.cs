using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        items.Add(item);
        
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
    

}
