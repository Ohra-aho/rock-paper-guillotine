using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutation : MonoBehaviour
{
    [HideInInspector] public int mutation_counter = 0;

    private void Awake()
    {
        if(GetComponent<BuffController>())
        {
            GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
            GetComponent<BuffController>().draw = true;
            GetComponent<BuffController>().special = Mutate;
        }
    }

    public void Mutate(Weapon w)
    {
        int choise = Random.Range(1, 5);
        switch (choise)
        {
            case 1: GetComponent<Healing>().Heal(); break;
            case 2: IncreaseStat(true, w); GetComponent<Weapon>().TakeDamage(1); break;
            case 3: IncreaseStat(false, w); GetComponent<Weapon>().TakeDamage(1); break;
            case 4: IncreaseStat(true, w); GetComponent<Weapon>().TakeDamage(1); break;
        }

    }

    private void IncreaseStat(bool damage, Weapon w)
    {
        Weapon chosen = w;
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
