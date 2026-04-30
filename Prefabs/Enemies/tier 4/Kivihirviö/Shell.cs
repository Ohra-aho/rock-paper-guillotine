using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public void Retaliate()
    {
        GetComponent<EffectDamage>().DealDamage(null);
    }

    public void ShellBreak()
    {
        GameObject.Find("Table").GetComponent<TableController>().enemy_damage += 3;
        GetComponent<EffectDamage>().DealSetDamage(1);
        GetComponent<SelfDestruct>().Destruct();
    }

    public void Fist()
    {
        GetComponent<Weapon>().damage++;
    }

    public void Spikes()
    {
        GetComponent<EffectDamage>().DealDamage(null);
        GameObject.Find("Table").GetComponent<TableController>().enemy_damage += 1;
    }
}
