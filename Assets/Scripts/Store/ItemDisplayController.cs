using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayController : MonoBehaviour
{
    // state
    public Item stockedItem;

    // references
    public GameObject inventory;
    public StockItemDisplay stockItemPrefab;
    public InventoryManager invManager;

    // event functions
    void Start()
    {
        if (stockedItem != null) RenderItemSprite();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (stockedItem == null && invManager.selectedItem != null)
        {
            StockItem(invManager.selectedItem);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        toggleMenu(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        toggleMenu(false);
    }

    // actions
    public void StockItem(Item item)
    {
        stockedItem = item;
        RenderItemSprite();
        invManager.selectedItem = null;
        invManager.Remove(item);
        toggleMenu(false, false);
    }

    public void SellItem()
    {
        invManager.gold += stockedItem.value;
        stockedItem = null;
        Destroy(this.transform.GetChild(0).gameObject);
    }

    void RenderItemSprite()
    {
        Vector2 adjustedPosition = new Vector2(transform.position.x, transform.position.y + 0.07f);
        StockItemDisplay createdItem = Instantiate(stockItemPrefab, adjustedPosition, transform.rotation);
        createdItem.data = stockedItem;
        createdItem.GetComponent<SpriteRenderer>().sortingOrder = 1;
        createdItem.transform.SetParent(this.GetComponent<ItemDisplayController>().gameObject.transform) ;
    }

    void toggleMenu (bool state, bool checkItem = true)
    {
        if (checkItem && stockedItem != null) return;
        inventory.SetActive(state);
    }
}
