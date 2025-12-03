using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    bool debuffed = false;

    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
        GetComponent<BuffController>().special = RestoreArmor;
        GetComponent<BuffController>().endPhase = true;
    }

    public void DebuffArmor()
    {
        if(!debuffed)
        {
            GetComponent<Weapon>().armor--;
            debuffed = true;
        }
    }

    public void RestoreArmor(Weapon w)
    {
        if(debuffed)
        {
            GetComponent<Weapon>().armor++;
            debuffed = false;
        }
    }


}
