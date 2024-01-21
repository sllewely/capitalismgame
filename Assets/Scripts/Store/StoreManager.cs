using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    // todo: load in game state from global
    public int slots = 4;
    public ItemDisplayController displayPrefab;
    public GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 adjustedPosition = new Vector2(transform.position.x - 0.55f, transform.position.y + 0.45f);
        for (int x = 0; x < slots; x++)
        {
            adjustedPosition.x += 0.2f;
            ItemDisplayController display = Instantiate(displayPrefab, adjustedPosition, transform.rotation);
            display.inventory = inventory;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
