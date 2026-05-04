using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teramyrsky : MonoBehaviour
{
    public int damage_bonus;
    private void Awake()
    {
        GetComponent<BuffController>().damage_bonus = damage_bonus;
        GetComponent<BuffController>().destructive = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => {
            if (!weapon.gameObject.GetComponent<SelfDestruct>() && weapon.name != this.GetComponent<Weapon>().name) return true;
            else return false;
        };
    }
}
