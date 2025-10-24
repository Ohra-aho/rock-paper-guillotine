using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madman : MonoBehaviour
{
    public GameObject buff;
    string name = "Madman";

    public void Chosen()
    {
        if (GetComponent<RLReward>().CheckIfCanBePicked())
        {
            ApplyBuff();
            GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Add(this.gameObject);
        }
    }

    public void ApplyBuff()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for (int i = 0; i < RI.transform.childCount; i++)
        {
            GameObject weapon = RI.transform.GetChild(i).gameObject;
            if (!FindOwnBuff(weapon.GetComponent<Weapon>()) && weapon.GetComponent<Weapon>().type == MainController.Choise.hyödytön)
            {
                GameObject new_buff = Instantiate(buff, weapon.transform);
                new_buff.GetComponent<Buff>().id = name;
                new_buff.GetComponent<Buff>().health_buff = 1;
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
