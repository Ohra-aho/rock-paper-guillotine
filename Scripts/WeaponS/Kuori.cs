using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuori : MonoBehaviour
{
    //Needs different self destruct system. System that detects that destructable weapon isn't selected currently
    private void Awake()
    {
        GetComponent<BuffController>().special = Destruction;
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().damage_bonus = 1;
        GetComponent<BuffController>().armor_bonus = 1;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }

    public void Destruction(Weapon weapon)
    {
        GetComponent<SelfDestruct>().Destruct();
    }
}
