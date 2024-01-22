using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayController : MonoBehaviour
{
    public GameObject inventory;

    public Item stockedItem;
    public StockItemDisplay stockItemPrefab;

    public StoreManager storeManager;

    // Start is called before the first frame update
    void Start()
    {
        if (stockedItem != null)
        {
            RenderItemSprite();
        }
    }

    
    public void StockItem(Item item)
    {
        stockedItem = item;
        RenderItemSprite();
        storeManager.ClearSelectedItem();
        inventory.SetActive(false);
    }

    void RenderItemSprite()
    {
        Vector2 adjustedPosition = new Vector2(transform.position.x, transform.position.y + 0.07f);
        StockItemDisplay createdItem = Instantiate(stockItemPrefab, adjustedPosition, transform.rotation);
        createdItem.data = stockedItem;
        createdItem.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (stockedItem == null && storeManager.selectedItem != null)
        {
            StockItem(storeManager.selectedItem);
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

    void toggleMenu (bool state)
    {
        if (stockedItem == null)
        {
            inventory.SetActive(state);
        }
    }
}
