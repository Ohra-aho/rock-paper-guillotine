using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().damage_bonus = 1;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void BuffEnemy()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            Buff new_buff = Instantiate(GetComponent<BuffController>().buff, RIE.transform.GetChild(i)).GetComponent<Buff>();
            new_buff.damage_buff = 1;
            new_buff.id = GetComponent<Weapon>().name;
        }
    }

    public void DebuffEnemy()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            for(int j = 0; j < RIE.transform.GetChild(i).transform.childCount; j++)
            {
                if(RIE.transform.GetChild(i).transform.GetChild(j).GetComponent<Buff>().id == GetComponent<Weapon>().name) {
                    RIE.transform.GetChild(i).transform.GetChild(j).GetComponent<Buff>().RemoveBuff();
                    Destroy(RIE.transform.GetChild(i).transform.GetChild(j).gameObject);
                }
            }
        }
    }
}
