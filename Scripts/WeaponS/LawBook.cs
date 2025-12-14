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
        GetComponent<BuffController>().special = DefyDeath;
    }

    public void DefyDeath(Weapon w)
    {
        if(!used && w.dead)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.dead = false;
            w.dead = false;
            GetComponent<Healing>().ForcedHeal();
            used = true;
        }
    }
}
