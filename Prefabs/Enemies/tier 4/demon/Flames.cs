using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    public GameObject buff;
    public void DebuffOpposingWeapon()
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
       
        GameObject weapon = MC.playerChoise.gameObject;
        GameObject new_buff = Instantiate(buff, weapon.transform);
        if (!weapon.GetComponent<EffectDamage>())
        {
            weapon.AddComponent<EffectDamage>();
        }
        new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name;
        new_buff.GetComponent<Buff>().special = (Weapon w) => { w.GetComponent<EffectDamage>().SetSelfDamage(1); };
        new_buff.GetComponent<Buff>().endPhase = true;
        new_buff.GetComponent<Buff>().AddBuff();
    }
}
