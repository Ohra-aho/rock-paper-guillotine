using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avalance : MonoBehaviour
{
    public void Use()
    {
		GetComponent<EffectDamage>().amount = GetComponent<Weapon>().player_owner.HB.GiveCurrentHealth() / 2;
        GetComponent<EffectDamage>().DealDamage(GetComponent<Weapon>());
        GetComponent<SelfDestruct>().Destruct();
    }
}
