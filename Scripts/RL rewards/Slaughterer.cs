using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slaughterer : MonoBehaviour
{
    public GameObject buff;
    string name = "Slaugtherer";

    public void Chosen()
    {
        ApplyBuff();
        DecreaseHealth();
    }

    public void ApplyBuff()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for(int i = 0; i < RI.transform.childCount; i++)
        {
            GameObject weapon = RI.transform.GetChild(i).gameObject;
            if(!FindOwnBuff(weapon.GetComponent<Weapon>()))
            {
                GameObject new_buff = Instantiate(buff, weapon.transform);
                new_buff.GetComponent<Buff>().id = name;
                new_buff.GetComponent<Buff>().damage_buff = 1;
                new_buff.GetComponent<Buff>().AddBuff();
            }
        }
    }

    private void DecreaseHealth()
    {
        GameObject.Find("PlayerHealth").GetComponent<HealthBar>().DecreaseHealthBar(2, false);
    }

    private bool FindOwnBuff(Weapon weapon)
    {
        for (int i = 0; i < weapon.transform.childCount; i++)
        {
            if (weapon.transform.GetChild(i).GetComponent<Buff>().id == name)
            {
                return true;
            }
        }
        return false;
    }


}
