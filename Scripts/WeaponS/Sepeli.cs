using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sepeli : MonoBehaviour
{
    GameObject ri;
    int damage_bonus=0;

    private void Awake()
    {
        ri = GameObject.Find("Real inventory");
    }

    public void CalculateDamage()
    {
        if(damage_bonus > 0) GetComponent<Weapon>().damage -= damage_bonus;
        damage_bonus = 0;
        int amount = 0;

        for(int i = 0; i < ri.transform.childCount; i++)
        {
            if(ri.transform.GetChild(i).GetComponent<Weapon>().type == MainController.Choise.sakset)
            {
                amount++;
            }
        }

        if(amount >= 2) damage_bonus = amount / 2;
        if(damage_bonus > 0) GetComponent<Weapon>().damage += damage_bonus;
    }
}
