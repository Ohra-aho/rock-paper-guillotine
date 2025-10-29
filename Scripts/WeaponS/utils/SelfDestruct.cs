using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public bool used_ones = false;
    public bool destroyed = false;
    public void Destruct()
    {
        Buff käyttöohje = FindCertainBuff("Käyttöohje");
        bool risk_taker = false;
        for(int i = 0; i < GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Count; i++)
        {
            if(GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs[i].GetComponent<RiskTaker>())
            {
                risk_taker = true;
                break;
            }
        }
        GetComponent<Weapon>().onDestruction.Invoke();

        if(GetComponent<Weapon>().player)
        {
            if ((käyttöohje != null || risk_taker) && !used_ones)
            {
                used_ones = true;
            }
            else if (käyttöohje != null && used_ones)
            {
                GameObject.Find("Destruction hand").GetComponent<Hand>().weapon_to_destroy = this.gameObject;
                GameObject.Find("Destruction hand").GetComponent<Test>().PlayAnimation("grab");
                destroyed = true;
            }
            else
            {
                GameObject.Find("Destruction hand").GetComponent<Hand>().weapon_to_destroy = this.gameObject;
                GameObject.Find("Destruction hand").GetComponent<Test>().PlayAnimation("grab");
                destroyed = true;
            }
        } else
        {
            if(!GetComponent<Weapon>().dead)
            {
                GameObject.Find("Destruction hand e").GetComponent<Hand>().weapon_to_destroy = this.gameObject;
                GameObject.Find("Destruction hand e").GetComponent<Test>().PlayAnimation("grab2");
                destroyed = true;
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
