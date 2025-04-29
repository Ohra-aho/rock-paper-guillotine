using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<GameObject> all = new List<GameObject>();

    public bool all_weapons = false;

    private void Start()
    {
        
    }

    public void AddAllWeapons()
    {
        if (all_weapons)
        {
            GameObject[] temp = Resources.LoadAll<GameObject>("weapons/Kivi");
            GameObject[] temp1 = Resources.LoadAll<GameObject>("weapons/paperi");
            GameObject[] temp2 = Resources.LoadAll<GameObject>("weapons/sakset");

            items.AddRange(temp);
            items.AddRange(temp1);
            items.AddRange(temp2);
        }
    }

    public void AddItem(GameObject newItem)
    {
        GameObject the_item = Instantiate(newItem, GetComponent<PlayerContoller>().TrueInventory.transform);
        the_item.GetComponent<Weapon>().player = true;
        if(the_item.GetComponent<BuffController>())
        {
            the_item.GetComponent<BuffController>().Inisiate();
        }
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
