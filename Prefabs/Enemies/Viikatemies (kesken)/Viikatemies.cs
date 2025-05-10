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
            if(i < RIE.transform.childCount)
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().lose.AddListener(() => KalmaFunction(RIE.transform.GetChild(i).GetComponent<Weapon>().name));
                RIE.transform.GetChild(i).GetComponent<Weapon>().draw.AddListener(() => {
                    try
                    {
                        //If there is no object in i index this doesn't work. This needs a work around
                        string temp = RIE.transform.GetChild(i).GetComponent<Weapon>().name;
                        KalmaFunction(temp);
                    }
                    catch
                    {
                        Debug.Log("Don't know");
                    }
                });
            }
        }
    }

    public void RemoveKalma()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if (i < RIE.transform.childCount)
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().lose.RemoveListener(() => KalmaFunction(RIE.transform.GetChild(i).GetComponent<Weapon>().name));
                RIE.transform.GetChild(i).GetComponent<Weapon>().draw.RemoveListener(() => KalmaFunction(RIE.transform.GetChild(i).GetComponent<Weapon>().name));
            }
        }
    }

    public void KalmaFunction(string weapon)
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().name == weapon)
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().EffectDamage(
                        RIE.transform.GetChild(i).GetComponent<Weapon>().damage / 2
                    );
                RemoveKalma();
            }
        }
        
    }

    public void AddKatse()
    {
        damage_dealt = false;
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if(i < RIE.transform.childCount)
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().dealDamage.AddListener(() => KatseFunction());
            }
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
            if (i < RIE.transform.childCount)
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().dealDamage.RemoveListener(() => KatseFunction());
            }
        }
    }
}
