using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = IncreaseDamage;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
        GetComponent<BuffController>().endPhase = true;
    }

    public void IncreaseDamage(Weapon w)
    {
        if(!w.opponent.dead)
        {
            GetComponent<Weapon>().damage++;
        }
    }

    public void ResetDamage()
    {
        GetComponent<Weapon>().damage = 0;
    }
}
