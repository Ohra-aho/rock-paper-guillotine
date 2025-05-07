using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viikatemies : MonoBehaviour
{
    public int kalma;
    public int katse;
    bool damage_dealt;

    private void Awake()
    {
        kalma = 0;
        katse = 0;
        damage_dealt = true;
        GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().endEffect = ControlBuffs;

    }

    public void ControlBuffs()
    {
        if (!damage_dealt)
        {
            GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
            for (int i = 0; i < RIE.transform.childCount; i++)
            {
                if(RIE.transform.GetChild(i) != null)
                {
                    if (RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Viikate" || RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Cythe")
                    {
                        RIE.transform.GetChild(i).GetComponent<Weapon>().type = MainController.Choise.voittamaton;
                    }
                }
            }
        }
        if (kalma > 0)
        {
            AddKalma();
            kalma = 0;
        }
        if(katse > 0)
        {
            AddKatse();
            katse = 0;
        }
    }

    public void AddKalma()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<Weapon>().lose.AddListener(() => KalmaFunction(RIE.transform.GetChild(i).GetComponent<Weapon>()));
        }
    }

    public void RemoveKalma()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<Weapon>().lose.RemoveListener(() => KalmaFunction(RIE.transform.GetChild(i).GetComponent<Weapon>()));
        }
    }

    public void KalmaFunction(Weapon weapon)
    {
        weapon.EffectDamage(weapon.damage / 2);
        RemoveKalma();
    }

    public void AddKatse()
    {
        damage_dealt = false;
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<Weapon>().dealDamage.AddListener(() => KatseFunction());
        }
    }

    public void KatseFunction()
    {
        damage_dealt = true;
        RemoveKatse();
    }

    public void RemoveKatse()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<Weapon>().lose.RemoveListener(() => KatseFunction());
        }
    }
}
