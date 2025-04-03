using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    

    public void AddItem(GameObject newItem)
    {
        GameObject the_item = Instantiate(newItem, GetComponent<PlayerContoller>().TrueInventory.transform);
        items.Add(the_item);

        if(newItem.GetComponent<Weapon>())
        {
            //Debug.Log("New weapon: "+newItem.GetComponent<Weapon>().name);
        } else if(newItem.GetComponent<Item>())
        {
            //Debug.Log("New item: " + newItem.GetComponent<Item>().name);
        } else
        {
            //Debug.Log("Something");
        }
    }
}
