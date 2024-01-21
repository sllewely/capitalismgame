using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayController : MonoBehaviour
{
    public GameObject inventory;


    public Item stockedItem;
    public StockItemDisplay stockItemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (stockedItem != null)
        {
            Vector2 adjustedPosition = new Vector2(transform.position.x, transform.position.y + 0.07f);
            StockItemDisplay createdItem = Instantiate(stockItemPrefab, adjustedPosition, transform.rotation);
            createdItem.data = stockedItem;
        }
    }

    // Update is called once per frame
    void Update()
    {

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
