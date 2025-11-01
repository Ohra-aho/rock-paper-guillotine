using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traditionalist : MonoBehaviour
{
    public GameObject buff;
    string name = "Traditionalist";

    public void Chosen()
    {
        ApplyBuff();
    }

    public void ApplyBuff()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for (int i = 0; i < RI.transform.childCount; i++)
        {
            GameObject weapon = RI.transform.GetChild(i).gameObject;
            if (!FindOwnBuff(weapon.GetComponent<Weapon>()) && (weapon.GetComponent<Weapon>().name == "Rock" || weapon.GetComponent<Weapon>().name == "Paper" || weapon.GetComponent<Weapon>().name == "Scissors"))
            {
                GameObject new_buff = Instantiate(buff, weapon.transform);
                new_buff.GetComponent<Buff>().id = name;
                new_buff.GetComponent<Buff>().damage_buff = 1;
                new_buff.GetComponent<Buff>().AddBuff();
            }
        }
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
