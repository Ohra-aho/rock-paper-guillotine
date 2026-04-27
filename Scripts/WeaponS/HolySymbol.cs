using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolySymbol : MonoBehaviour
{
    public List<GameObject> miracles;
  
    public void Worship()
    {
        GetComponent<Stacking>().IncreaseStacks(1);
    }

    public void Miracle()
    {
        if (GetComponent<Stacking>().stacks >= 3)
        {
            GetComponent<Stacking>().stacks = 0;
            PlayerInventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
            inventory.AddItem(miracles[Random.Range(0, miracles.Count)]);
        }
    }
}
