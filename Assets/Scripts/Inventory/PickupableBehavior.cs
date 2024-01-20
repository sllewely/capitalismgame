using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PickupableBehavior : MonoBehaviour
{

    public Item item;


    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }
    
    // On collision with the player, I get picked up
    private void OnTriggerEnter(Collider other)
    {
        // Check if collided with player
        if (other.tag != "player")
        {
            Debug.Log("collided with " + other.name);
            return;
        }

        // Add to inventory.
        Pickup();
    }
}
