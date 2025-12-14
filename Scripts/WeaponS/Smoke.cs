using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public GameObject buff;

    public void DebuffEnemy()
    {
        List<Weapon> enemy_weapons = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().GetWeapons();
        for (int i = 0; i < enemy_weapons.Count; i++)
        {
            GameObject new_buff = Instantiate(buff, enemy_weapons[i].transform);
            new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name + "_2";
            new_buff.GetComponent<Buff>().damage_buff = -1;
            new_buff.GetComponent<Buff>().temporary = true;
            new_buff.GetComponent<Buff>().timer = 2;

            new_buff.GetComponent<Buff>().AddBuff();
        }
    }
}
