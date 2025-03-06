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
            GetComponent<Test>().reverse = open;
        }
    }

    public void DestroyInventory()
    {
        if(open)
        {
            open = false;
            GetComponent<Test>().reverse = open;
            for (int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).GetComponent<InventoryMenu>())
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
