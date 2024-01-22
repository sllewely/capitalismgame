using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public Item selectedItem;

    public void SelectItem(Item item)
    {
        selectedItem = item;
    }

    public void ClearSelectedItem()
    {
        selectedItem = null;
    }
}
