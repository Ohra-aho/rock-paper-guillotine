using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teroituskivi : MonoBehaviour
{
    public int damage_bonus;

    private void Awake()
    {
        GetComponent<BuffController>().damage_bonus = damage_bonus;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.type == MainController.Choise.sakset; };
    }


}
