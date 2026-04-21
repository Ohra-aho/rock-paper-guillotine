using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentDebuffer : MonoBehaviour
{
    GameObject buff;

    private void Awake()
    {
        buff = Resources.Load<GameObject>("buff/buff");
    }

    public void DebuffOpposingWeaponDamage(int amount)
    {
        Weapon opponent = GetComponent<Weapon>().opponent;
        Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
        new_buff.damage_buff = -amount;
        new_buff.id = GetComponent<Weapon>() + "_debuff";
        new_buff.AddBuff();
    }

    public void DebuffOpposingWeaponArmor(int amount)
    {
        Weapon opponent = GetComponent<Weapon>().opponent;
        Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
        new_buff.armor_buff = -amount;
        new_buff.id = GetComponent<Weapon>() + "_debuff";
        new_buff.AddBuff();
    }
}
