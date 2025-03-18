using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santapaperi : MonoBehaviour
{
    public int damage_buff;

    public void Awake()
    {
        GetComponent<BuffController>().damage_bonus = damage_buff;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.type == MainController.Choise.kivi; };
    }


}
