using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    public GameObject buff;

    public void DebuffOpposingWeapon()
    {
        GameObject new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform);
        new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name;
        new_buff.GetComponent<Buff>().until_used = true;
        new_buff.GetComponent<Buff>().type_change = MainController.Choise.useless;
        new_buff.GetComponent<Buff>().AddBuff();
    }
}
