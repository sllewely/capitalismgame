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

    // The content pane in InventoryUI
    public Transform itemContent;
    public GameObject inventoryItem;
    public Item selectedItem;
    
    private InputControls input = null;

    private void Awake()
    {
        Instance = this;
        input = new InputControls();
        input.Enable();

        if (itemContent == null)
        {
            Debug.LogError("inventoryContent missing");
        }
    }

    void Start()
    {
        foreach (var item in items)
        {
            InsertItem(item);
        }

        input.Player.OpenInventory.performed += pressed =>
        {

        };

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
        obj.GetComponent<InventoryItem>().name = item.itemName;
        itemName.text = item.itemName;
        itemIcon.sprite = item.icon;
        obj.GetComponent<Button>().onClick.AddListener(() => this.selectedItem = item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        // note: v1 just destroy first matching item since we don't have stacks!
        Destroy(itemContent.transform.Find(item.itemName).gameObject);
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
