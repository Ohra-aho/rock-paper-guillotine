using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.GetComponent<Healing>(); };
        GetComponent<BuffController>().heal_disabler = true;
    }

    public void DebuffEnemy()
    {
        List<Weapon> enemy_weapons = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().GetWeapons();
        for(int i = 0; i < enemy_weapons.Count; i++)
        {
            GameObject buff = Instantiate(GetComponent<BuffController>().buff, enemy_weapons[i].transform);
            buff.GetComponent<Buff>().id = GetComponent<Weapon>().name + "_2";
            buff.GetComponent<Buff>().heal_disabler = true;
            buff.GetComponent<Buff>().AddBuff();
        }
    }
}
