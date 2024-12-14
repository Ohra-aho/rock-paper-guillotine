using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    private bool open = false;
    public void ToggleOpen()
    {
        if(!open)
        {
            open = true;
        }
    }

    public void DestroyInventory()
    {
        if(open)
        {
            Destroy(transform.GetChild(0).gameObject);
            open = false;
        }
    }
}
