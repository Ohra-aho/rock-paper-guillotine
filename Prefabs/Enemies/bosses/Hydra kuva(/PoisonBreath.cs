using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBreath : MonoBehaviour
{
    public void DealDamage()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        int amount = 0;
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<DisposableHead>() && RIE.transform.GetChild(i).GetComponent<Weapon>().type != MainController.Choise.hyödytön)
            {
                amount++;
            }
        }
        GetComponent<EffectDamage>().amount = amount;
        GetComponent<EffectDamage>().DealDamage(null);
    }
}
