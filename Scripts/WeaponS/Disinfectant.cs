using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disinfectant : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = ExtraHeal;
        GetComponent<BuffController>().heal = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }

    public void ExtraHeal(Weapon weapon)
    {
        if(weapon.player)
        {
            GameObject.Find("Table").GetComponent<TableController>().player_healing++;
        }
    }
}
