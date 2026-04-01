using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    public List<GameObject> powers;
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
        if (GetComponent<Stacking>().stacks >= 5)
        {
            GetComponent<Stacking>().stacks -= 5;
            PlayerInventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
            inventory.AddItem(powers[Random.Range(0, powers.Count)]);
        }
    }
}
