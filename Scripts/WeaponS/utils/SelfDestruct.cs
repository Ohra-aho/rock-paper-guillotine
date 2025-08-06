using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public bool used_ones = false;
    public void Destruct()
    {
        Buff käyttöohje = FindCertainBuff("Käyttöohje");
        GetComponent<Weapon>().onDestruction.Invoke();

        if(GetComponent<Weapon>().player)
        {
            if (käyttöohje != null && !used_ones)
            {
                used_ones = true;
            }
            else if (käyttöohje != null && used_ones)
            {
                GameObject.Find("Destruction hand").GetComponent<Hand>().weapon_to_destroy = this.gameObject;
                GameObject.Find("Destruction hand").GetComponent<Test>().PlayAnimation("grab");
            }
            else
            {
                GameObject.Find("Destruction hand").GetComponent<Hand>().weapon_to_destroy = this.gameObject;
                GameObject.Find("Destruction hand").GetComponent<Test>().PlayAnimation("grab");
            }
        } else
        {
            if(!GetComponent<Weapon>().dead)
            {
                GameObject.Find("Destruction hand e").GetComponent<Hand>().weapon_to_destroy = this.gameObject;
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
            GameObject.Find("Wheel holder").GetComponent<EnemyWheelHolder>()
                .RemoveWeapon(this.gameObject);
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
