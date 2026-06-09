using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellspawn : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().special = Retaliate;

        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().name != GetComponent<Weapon>().name)
            {
                Buff new_buff = Instantiate(GetComponent<BuffController>().buff, RIE.transform.GetChild(i)).GetComponent<Buff>();
                new_buff.endPhase = true;
                new_buff.special = (Weapon w) => { w.owner.HB.TakeDamage(1); };
                new_buff.id = GetComponent<Weapon>().name + "_2";
                new_buff.AddBuff();
            }
        }
    }

    public void Retaliate(Weapon weapon)
    {
        int damage = GameObject.Find("Table").GetComponent<TableController>().enemy_damage;
        if(damage > 0)
        {
            GetComponent<Weapon>().opponent = weapon.opponent;
            GetComponent<EffectDamage>().DealSetDamage(damage);
        }
    }
}
