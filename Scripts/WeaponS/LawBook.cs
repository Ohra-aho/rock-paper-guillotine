using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawBook : MonoBehaviour
{
    bool used = false;

    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().endPhase = true;
        //GetComponent<BuffController>().on_death = true;
        GetComponent<BuffController>().special = DefyDeath;
    }

    public void DefyDeath(Weapon w)
    {
        if (!used && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.CheckIfDead())
        {
			TableController TC = GameObject.Find("Table").GetComponent<TableController>();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.dead = false;
			TC.player_damage = 0;
			TC.player_direct_damage = 0;
			GetComponent<Healing>().Heal();
            used = true;
			GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name).GetComponent<Buff>().reminder = "Won't save you anymore.";
        }
    }
}
