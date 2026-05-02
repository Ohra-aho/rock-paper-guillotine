using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<BuffController>().special = Retaliate;
        GetComponent<BuffController>().takeNoDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void Retaliate(Weapon w)
    {
        if(GameObject.Find("EventSystem").GetComponent<MainController>().won == false)
        {
            GetComponent<EffectDamage>().DealDamage(null);
        }
    }
}
