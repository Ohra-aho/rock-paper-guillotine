using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public bool used_ones = false;
    public void Destruct()
    {
        Buff k�ytt�ohje = FindCertainBuff("K�ytt�ohje");
        
        if(GetComponent<Weapon>().player)
        {
            if (k�ytt�ohje != null && !used_ones)
            {
                used_ones = true;
            }
            else if (k�ytt�ohje != null && used_ones)
            {
                GameObject.Find("Destruction hand").GetComponent<Test>().PlayAnimation("grab");
            }
            else
            {
                GameObject.Find("Destruction hand").GetComponent<Test>().PlayAnimation("grab");
            }
        } else
        {
            if(!GameObject.Find("EnemyHolder").GetComponent<EnemyController>().dead)
            {
                GameObject.Find("Destruction hand e").GetComponent<Test>().PlayAnimation("grab2");
            }
        }
    }

    public void TrueDestruct()
    {
        if(GetComponent<Weapon>().player)
        {
            GameObject.Find("PlayerWheelHolder").GetComponent<PlayerWheelHolder>()
                .RemoveWeapon(this.gameObject);
        } else
        {
            
        }
    }

    private Buff FindCertainBuff(string name)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<Buff>().id == name)
            {
                return transform.GetChild(i).GetComponent<Buff>();
            }
        }
        return null;
    }
}
