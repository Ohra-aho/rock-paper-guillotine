using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanaticWeapons : MonoBehaviour
{
    bool armor_buff = false;
    public void Lose()
    {
        if (!GetComponent<Weapon>().owner.off_balance)
        {
            GetComponent<Weapon>().owner.OffBalance();
        }
    }

    public void Balance()
    {
        GetComponent<Weapon>().owner.Balance();
    }

    public void CheckIfOffBalance()
    {
        if(GetComponent<Weapon>().owner.off_balance && !armor_buff)
        {
            armor_buff = true;
            GetComponent<Weapon>().armor += 1;
        } else if(!GetComponent<Weapon>().owner.off_balance && armor_buff)
        {
            armor_buff = false;
            GetComponent<Weapon>().armor -= 1;
        }
    }

    public void Granade()
    {
        if (GetComponent<Weapon>().owner.off_balance)
        {
            GetComponent<Weapon>().GetComponent<EffectDamage>().DealDamage(null);
            GetComponent<Weapon>().GetComponent<EffectDamage>().SelfDamage(null);
        }
        else
        {
            GetComponent<Weapon>().GetComponent<EffectDamage>().SelfDamage(null);
        }
    }
}
