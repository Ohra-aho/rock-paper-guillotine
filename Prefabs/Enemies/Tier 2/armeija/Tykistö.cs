using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tykistö : MonoBehaviour
{
    public void DealDamage()
    {
        if(GetComponent<Stacking>().stacks < 3)
        {
            Debug.Log("Que");

            GetComponent<EffectDamage>().DealDamage(null);
            GetComponent<Stacking>().IncreaseStacks(1);
            
            if(GetComponent<Stacking>().stacks >= 3)
            {
                GetComponent<EffectDamage>().amount = 0;
            }
        }
    }
}
