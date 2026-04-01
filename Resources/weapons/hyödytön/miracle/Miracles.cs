using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miracles : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().armor_bonus = 3;
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 4;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
    }
}
