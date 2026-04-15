using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avalance : MonoBehaviour
{
    public void Use()
    {
        GetComponent<HealthIncrease>().DecreaseSetAmount(1);
        GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
        GetComponent<HealthIncrease>().amount--;
        if(GetComponent<HealthIncrease>().amount < 0)
        {
            GetComponent<HealthIncrease>().amount = 0;
        }
    }
}
