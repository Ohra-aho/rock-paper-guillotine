using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStreak : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = Stacking;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void Stacking(Weapon w)
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        if(MC.won == true)
        {
            AppluBuffs();
        }

    }

    public void AppluBuffs()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for(int i = 0; i < RI.transform.childCount; i++)
        {
            Buff new_buff = Instantiate(GetComponent<BuffController>().buff, RI.transform.GetChild(i)).GetComponent<Buff>();
            new_buff.id = GetComponent<Weapon>().name+"_2";
            new_buff.temporary = true;
            new_buff.timer = 1000;
            new_buff.special = (Weapon w) => { RemoveDamageBuffs(); };
            new_buff.draw = true;
            new_buff.lose = true;
            new_buff.damage_buff = 1;
            new_buff.AddBuff();
        }
    }

    public void RemoveDamageBuffs()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for(int i = 0; i < RI.transform.childCount; i++)
        {
            for(int j = RI.transform.GetChild(i).transform.childCount-1; j >= 0; j--)
            {
                if(RI.transform.GetChild(i).transform.GetChild(j).GetComponent<Buff>().id == GetComponent<Weapon>().name + "_2")
                {
                    RI.transform.GetChild(i).transform.GetChild(j).GetComponent<Buff>().RemoveBuff(); 
                    Destroy(RI.transform.GetChild(i).transform.GetChild(j).gameObject);
                }
            }
        }
    }
}
