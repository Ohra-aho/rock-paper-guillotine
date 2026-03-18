using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutation : MonoBehaviour
{
    [HideInInspector] public int mutation_counter = 0;
    public void Mutate()
    {
        int choise = Random.Range(1, 5);

        mutation_counter++;
        if(mutation_counter % 3 == 0 && mutation_counter >= 3)
        {
            choise = 1;
        } else
        {
            GetComponent<EffectDamage>().SelfDamage(null);
        }


        switch (choise)
        {
            case 1: GetComponent<Healing>().Heal(); break;
            case 2: IncreaseStat(true); break;
            case 3: IncreaseStat(false); break;
            case 4: IncreaseStat(true); break;
        }

        if(!GetComponent<Weapon>().owner.off_balance_triggered)
        {
            GetComponent<Weapon>().owner.Balance();
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

    public void CheckDamage()
    {
        if(GetComponent<DamageInteractions>().CalculateTakenDamage() > 0)
        {
            GetComponent<Weapon>().owner.OffBalance();
        }
    }

    public void ResetMutationCounter()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Mutation")
            {
                RIE.transform.GetChild(i).GetComponent<Mutation>().mutation_counter--;
                if(RIE.transform.GetChild(i).GetComponent<Mutation>().mutation_counter < 0)
                {
                    RIE.transform.GetChild(i).GetComponent<Mutation>().mutation_counter = 0;
                }
            }
        }
    }
}
