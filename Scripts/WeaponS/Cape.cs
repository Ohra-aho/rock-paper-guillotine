using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cape : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().damage_bonus = 2;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != this.GetComponent<Weapon>().name; };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
    }

    public void ApplyBuff()
    {
        GetComponent<BuffController>().AddBuffs();
    }
}
