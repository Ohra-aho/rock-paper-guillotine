using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : MonoBehaviour
{
    public void TakeDamage()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.TakeDamage(1);
    }

    public void DealPoisonDamage()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        int poisons = 0;
        for(int i = 0; i < RI.transform.childCount; i++)
        {
            if(RI.transform.GetChild(i).GetComponent<Weapon>().name == "Poison")
            {
                poisons++;
            }
        }
        if(poisons > 1) GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.TakeDamage(poisons);
    }
}
