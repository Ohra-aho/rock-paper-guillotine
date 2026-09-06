using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Käyttöohje : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { 
			if(weapon.name != "Weakness" && weapon.name != "Poison" && weapon.name != "Bleed")
			{
				return weapon.gameObject.GetComponent<SelfDestruct>(); 
			} else
			{
				return false;
			}
		};
        GetComponent<BuffController>().toughness_buff = 1;
    }
}
