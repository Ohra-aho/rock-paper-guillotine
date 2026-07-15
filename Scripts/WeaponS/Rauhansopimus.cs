using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rauhansopimus : MonoBehaviour
{
    public void CompareHPs(Weapon w)
    {
        TableController TC = GameObject.Find("Table").GetComponent<TableController>();

        if (TC.GiveEffectiveEnemyDamage() == 0 && TC.GiveEffectivePlayerDamage() == 0)
        {
            GetComponent<Healing>().Heal();
        }
    }

}
