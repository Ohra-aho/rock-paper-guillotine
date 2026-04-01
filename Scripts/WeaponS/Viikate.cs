using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viikate : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = IncreaseStack;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon != this; };
        GetComponent<BuffController>().onDestruction = true;
    }

    public void IncreaseStack(Weapon weapon)
    {
        Buff new_buff = Instantiate(GetComponent<BuffController>().buff, transform).GetComponent<Buff>();
        new_buff.damage_buff = 2;
        new_buff.id = GetComponent<Weapon>().name + "_2";
        new_buff.temporary = true;
        new_buff.timer = 1000;
        new_buff.AddBuff();
    }
}
