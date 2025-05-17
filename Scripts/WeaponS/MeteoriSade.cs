using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriSade : MonoBehaviour
{
    GameObject RI;
    int damage;

    private void Awake()
    {
        RI = GameObject.FindGameObjectWithTag("RI");
    }

    public void DealDamageToAmountOfStones()
    {
        GetComponent<EffectDamage>().amount -= damage;
        damage = 0;
        for(int i = 0; i < RI.transform.childCount; i++)
        {
            if(RI.transform.GetChild(i).GetComponent<Weapon>().type == MainController.Choise.kivi)
            {
                damage++;
            }
        }
        GetComponent<EffectDamage>().amount += damage;
        GetComponent<EffectDamage>().DealDamage(null);
    }
}
