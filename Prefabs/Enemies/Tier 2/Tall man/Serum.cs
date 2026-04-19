using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serum : MonoBehaviour
{
    public void Heal()
    {
        if(GetComponent<Stacking>().stacks > 0)
        {
            GetComponent<Healing>().Heal();
            GetComponent<Stacking>().DecreaseStacks(1);
        }
        GetComponent<Weapon>().owner.off_balance_triggered = false;
        GetComponent<Weapon>().owner.Balance();
    }

    public void GiveSerum()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if (RIE.transform.GetChild(i).GetComponent<Serum>())
            {
                if (RIE.transform.GetChild(i).GetComponent<Stacking>().stacks > 0)
                {
                    GetComponent<WeaponSpawner>().SpawnSpecificWeapon(0);
                    break;
                }
                else
                {
                    GetComponent<WeaponSpawner>().SpawnSpecificWeapon(1);
                    break;
                }
            }
        }
    }
}
