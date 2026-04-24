using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Howl : MonoBehaviour
{
    public GameObject buff;
    public void DebuffOpposingWeapon()
    {
        GameObject weapon = GetComponent<Weapon>().opponent.gameObject;
        GameObject new_buff = Instantiate(buff, weapon.transform);
        new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name;
        new_buff.GetComponent<Buff>().destructive = true;
        new_buff.GetComponent<Buff>().AddBuff();
    }
}
