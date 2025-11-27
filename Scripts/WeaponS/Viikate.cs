using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viikate : MonoBehaviour
{
    public int amount = 1;
    private void Awake()
    {
        GetComponent<BuffController>().special = IncreaseStack;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon != this; };
        GetComponent<BuffController>().onDestruction = true;
    }

    public void IncreaseStack(Weapon weapon)
    {
        GetComponent<Stacking>().IncreaseStacks(amount);
    }

    public void BeforeStacking()
    {
        GetComponent<Weapon>().damage -= GetComponent<Stacking>().stacks;
    }

    public void AfterStacking()
    {
        GetComponent<Weapon>().damage += GetComponent<Stacking>().stacks;
        /*if(GetComponent<Weapon>().damage > GetComponent<Weapon>().damage_soft_cap)
        {
            GetComponent<Weapon>().damage = 7;
        }*/
    }

    public void LoadDamage()
    {
        GetComponent<Weapon>().damage += GetComponent<Stacking>().stacks;
        /*if (GetComponent<Weapon>().damage > GetComponent<Weapon>().damage_soft_cap)
        {
            GetComponent<Weapon>().damage = 7;
        }*/
    }
}
