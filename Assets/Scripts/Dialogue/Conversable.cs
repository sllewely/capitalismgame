using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversable : MonoBehaviour
{

    public GameObject speechBubble;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            speechBubble.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            speechBubble.SetActive(false);

        }
    }
}
