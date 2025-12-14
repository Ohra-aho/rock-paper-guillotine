using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    public GameObject power;
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().special = Sacrifice;
    }

    public void Sacrifice(Weapon w)
    {
        GetComponent<Stacking>().IncreaseStacks(1);
    }

    public void Ritual()
    {
        if(GetComponent<Stacking>().stacks == 10)
        {
            PlayerInventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
            inventory.AddItem(power);
            GetComponent<SelfDestruct>().Destruct();
        }
    }
}
