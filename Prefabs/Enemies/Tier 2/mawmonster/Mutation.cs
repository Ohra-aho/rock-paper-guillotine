using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutation : MonoBehaviour
{
    public void Mutate()
    {
        int choise = Random.Range(1, 5);
        GetComponent<EffectDamage>().SelfDamage(null);

        switch(choise)
        {
            case 1: GetComponent<Healing>().Heal(); break;
            case 2: IncreaseStat(true); break;
            case 3: IncreaseStat(false); break;
            case 4: IncreaseStat(true); break;
        }
    }

    private void IncreaseStat(bool damage)
    {
        int index = Random.Range(0, 3);
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        Weapon chosen = RIE.transform.GetChild(index).GetComponent<Weapon>();
        if (damage) chosen.damage++;
        else chosen.armor++;
    }
}
