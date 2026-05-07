using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LurkerWeapons : MonoBehaviour
{
    public GameObject buff;
    public void DebuffOpposingWeapon()
    {
        Weapon opponent = GetComponent<Weapon>().opponent;
        Buff new_buff = Instantiate(buff, opponent.gameObject.transform).GetComponent<Buff>();
        new_buff.id = GetComponent<Weapon>().name + "_2";
        new_buff.temporary = true;
        new_buff.timer = 1;
        new_buff.type_change = MainController.Choise.useless;
        new_buff.AddBuff();
    }
}
