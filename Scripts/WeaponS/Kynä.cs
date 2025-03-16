using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kynä : MonoBehaviour
{
    public int damage_buff;
    public int armor_buff;
    private void Awake()
    {
        GetComponent<BuffController>().damage_bonus = damage_buff;
        GetComponent<BuffController>().armor_bonus = armor_buff;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.type == MainController.Choise.paperi; };
    }


}
