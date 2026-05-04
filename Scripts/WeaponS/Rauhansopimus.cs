using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rauhansopimus : MonoBehaviour
{
    public void CompareHPs(Weapon w)
    {
        TableController TC = GameObject.Find("Table").GetComponent<TableController>();

        if (TC.enemy_damage == 0 && TC.player_damage == 0)
        {
            GetComponent<Healing>().Heal();
        }
    }

}
