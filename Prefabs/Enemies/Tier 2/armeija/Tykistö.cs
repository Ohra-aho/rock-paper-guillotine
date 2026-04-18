using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tykistö : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
        GetComponent<BuffController>().lose = true;
        GetComponent<BuffController>().special = DealDamage;
    }

    public void Lose()
    {
        if (GetComponent<Weapon>().owner.HB.GiveCurrentHealth() <= GetComponent<Weapon>().owner.HB.GiveMaxHealth() / 2)
        {
            GetComponent<Weapon>().owner.OffBalance();
        }
    }
    public void DealDamage(Weapon w)
    {
        if(GetComponent<Stacking>().stacks > 0)
        {
            GetComponent<EffectDamage>().DealDamage(null);
            GetComponent<Stacking>().DecreaseStacks(1);
        }
    }
}
