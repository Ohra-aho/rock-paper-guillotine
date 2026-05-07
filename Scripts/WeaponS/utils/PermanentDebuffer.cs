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

    public void MakeOpposingWeaponUselessTemporarily(int turns)
    {
        Weapon opponent = GetComponent<Weapon>().opponent;
        Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
        new_buff.id = GetComponent<Weapon>().name + "_debuff";
        new_buff.type_change = MainController.Choise.useless;
        new_buff.temporary = true;
        new_buff.timer = turns;
        new_buff.AddBuff();
    }

    public void DecreaseOpposingHealth(int amount)
    {
        GetComponent<Weapon>().opponent.player_owner.HB.DecreaseHealthBar(amount, true);
    }

    public void MakeOpposingWeaponSelfDestructive(int turns)
    {
        Weapon opponent = GetComponent<Weapon>().opponent;
        Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
        new_buff.id = GetComponent<Weapon>().name + "_debuff";
        new_buff.destructive = true;
        new_buff.desruction_buffer = true;
        if(turns > 0)
        {
            new_buff.temporary = true;
            new_buff.timer = turns;
        }
        new_buff.AddBuff();
    }

    public void MakeOpposingWeaponUseless()
    {
        Weapon opponent = GetComponent<Weapon>().opponent;
        Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
        new_buff.id = GetComponent<Weapon>().name + "_debuff";
        new_buff.type_change = MainController.Choise.useless;
        new_buff.AddBuff();
    }
}
