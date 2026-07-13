using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teroituskivi : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<BuffController>().effect_damage_bonus = 1;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.type == MainController.Choise.sakset; };
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 3;
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().reminder = "+" + GetComponent<BuffController>().effect_damage_bonus + " effect damage.";
    }


}
