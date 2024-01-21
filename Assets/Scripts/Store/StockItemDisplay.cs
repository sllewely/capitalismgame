using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockItemDisplay : MonoBehaviour
{
    public Item data;
    SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = data.icon;
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
