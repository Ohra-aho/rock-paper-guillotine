using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disinfectant : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = ExtraHeal;
        //GetComponent<BuffController>().heal_modifier = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
		GetComponent<BuffController>().special_apply = true;
    }

    public void ExtraHeal(Weapon weapon)
    {
		TableController TC = GameObject.Find("Table").GetComponent<TableController>();
		if(TC.player_healing > 0)
		{
			GameObject.Find("Table").GetComponent<TableController>().player_healing++;
		}
    }
}
