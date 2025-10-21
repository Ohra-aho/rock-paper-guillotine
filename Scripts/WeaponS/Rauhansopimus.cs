using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rauhansopimus : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = CompareHPs;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void CompareHPs(Weapon w)
    {
        bool enemy = GetComponent<DamageInteractions>().CalculateDealtDamage() == 0;
        bool player = GetComponent<DamageInteractions>().CalculateTakenDamage() == 0;

        if (enemy && player)
        {
            if(GetComponent<Weapon>().player)
            {
                GetComponent<Healing>().Heal();
            }
            else
            {
                GetComponent<Healing>().Heal();
            }
        }
    }

    public void AddDamageInteractionListeners()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for(int i = 0; i < RI.transform.childCount; i++)
        {
            RI.transform.GetChild(i).GetComponent<Weapon>().choisePhase.AddListener(GetComponent<DamageInteractions>().SetPreviousHealth);
        }
    }

    public void RemoveDamageInteractions()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for (int i = 0; i < RI.transform.childCount; i++)
        {
            RI.transform.GetChild(i).GetComponent<Weapon>().choisePhase.RemoveListener(GetComponent<DamageInteractions>().SetPreviousHealth);
        }
    }

}
