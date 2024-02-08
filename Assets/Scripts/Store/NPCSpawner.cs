using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public int dailyLimit = 5;
    public NPCController shopper;
    public bool isActive = true;
    public GameObject slots;


    private GameObject activeShopper;

    void Start()
    {
        if (isActive)
        {
           spawnShopper();
        }
    }

    void Update()
    {
        if (isActive && activeShopper == null && dailyLimit > 0)
        {
            spawnShopper();
            dailyLimit -= 1;
        }
    }

    void spawnShopper()
    {
        Vector2 adjustedPosition = new Vector2(this.transform.position.x, this.transform.position.y + 0.07f);
        NPCController newShopper = Instantiate(shopper, adjustedPosition, this.transform.rotation);
        newShopper.spawnPoint = this.gameObject;
        newShopper.targetItem = itemLocation();
        newShopper.transform.SetParent(this.GetComponent<NPCSpawner>().gameObject.transform);
        activeShopper = newShopper.gameObject;
    }

    ItemDisplayController itemLocation()
    {
        List<ItemDisplayController> availableItems = new List<ItemDisplayController>();

        foreach (ItemDisplayController slot in slots.GetComponentsInChildren<ItemDisplayController>())
        {
            if (slot.stockedItem != null)
            {
                availableItems.Add(slot);
            }
        };

        return availableItems.Count > 0 ? availableItems[Random.Range(0, availableItems.Count)] : null;
    }
}
