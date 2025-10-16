using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anger : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().damage_bonus = 2;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }
}
