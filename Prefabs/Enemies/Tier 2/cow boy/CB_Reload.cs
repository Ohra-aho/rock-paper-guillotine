using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CB_Reload : MonoBehaviour
{

    public void Reloading()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if (RIE.transform.GetChild(i).GetComponent<Weapon>().name != GetComponent<Weapon>().name)
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().damage += 3;
            }
        }
        GetComponent<Weapon>().owner.ResetPlan();
        ResetFantTheHammer();
    }

    public void ShotOffBalance()
    {
        GetComponent<Weapon>().owner.OffBalance();
    }

    public void FanOffBalance()
    {
        GetComponent<Weapon>().owner.GetComponent<CowBoy>().fan_misses++;
        if (GetComponent<Weapon>().owner.GetComponent<CowBoy>().fan_counter >= 2 && GetComponent<Weapon>().owner.GetComponent<CowBoy>().fan_misses >= 2)
        {
            GetComponent<Weapon>().owner.OffBalance();
        }
    }

    public void ResetFantTheHammer()
    {
        GetComponent<Weapon>().owner.GetComponent<CowBoy>().fan_misses = 0;
        GetComponent<Weapon>().owner.GetComponent<CowBoy>().fan_counter = 0;
    }

    public void SetPreviousWeapon()
    {
        GetComponent<Weapon>().owner.GetComponent<CowBoy>().previous_weapon = this.GetComponent<Weapon>();
        GetComponent<Weapon>().owner.GetComponent<BasicEnemy>().Balance();
    }

    public void FanTheHammer()
    {
        GetComponent<Weapon>().owner.GetComponent<CowBoy>().fan_counter++;
    }
}
