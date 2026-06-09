using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MonoBehaviour
{
    public GameObject buff;
    public void BuffOpposingWeapon()
    {
        GameObject new_buff = Instantiate(buff, GetComponent<Weapon>().opponent.transform);
        new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name;
        new_buff.GetComponent<Buff>().damage_buff = 1;
        new_buff.GetComponent<Buff>().AddBuff();
    }
}
