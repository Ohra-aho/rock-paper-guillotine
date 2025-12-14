using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidearm : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().special = ApplyBuffs;
    }

    public void ApplyBuffs(Weapon w)
    {
        if (GameObject.Find("EventSystem").GetComponent<MainController>().won == false && !GameObject.Find("EnemyHolder").GetComponent<EnemyController>().dead)
        {
            List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
            for (int i = 0; i < weapons.Count; i++)
            {
                GameObject new_buff = Instantiate(GetComponent<BuffController>().buff, weapons[i].transform);
                new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name + "_2";
                new_buff.GetComponent<Buff>().damage_buff = 1;
                new_buff.GetComponent<Buff>().temporary = true;
                new_buff.GetComponent<Buff>().timer = 2;
                new_buff.GetComponent<Buff>().AddBuff();
            }
        }
    }
}
