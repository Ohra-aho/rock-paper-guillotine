using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rauhansopimus : MonoBehaviour
{
    private int current_hp_self;
    private int current_hp_enemy;

    public int heal;

    public void GetCurrentHPs()
    {
        current_hp_enemy = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB.GiveCurrentHealth();
        current_hp_self = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.GiveCurrentHealth();
    }

    public void CompareHPs()
    {
        bool enemy = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB.GiveCurrentHealth() == current_hp_enemy;
        bool player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.GiveCurrentHealth() == current_hp_self;

        if(enemy && player)
        {
            if(GetComponent<Weapon>().player)
            {
                GetComponent<Healing>().Heal();
            }
            else
            {
                GetComponent<Healing>().Heal();
            }
        }
        GetCurrentHPs();
    }

}
