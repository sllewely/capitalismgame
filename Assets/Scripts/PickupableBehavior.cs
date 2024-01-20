using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PickupableBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // On collision with the player, I get picked up
    private void OnTriggerEnter(Collider other)
    {
        // Check if collided with player
        if (other.name != "Player")
        {
            Debug.Log("collided with " + other.name);
            return;
        }

        // Add to inventory.
    }
}
