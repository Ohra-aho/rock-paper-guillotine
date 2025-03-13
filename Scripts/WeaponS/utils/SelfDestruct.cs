using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private bool used_ones = false;
    public void Destruct()
    {
        Buff k�ytt�ohje = FindCertainBuff("K�ytt�ohje");
        if (k�ytt�ohje != null && !used_ones)
        {
            used_ones = true;
        }
        else if(k�ytt�ohje != null && used_ones)
        {
            GameObject.Find("PlayerWheelHolder").GetComponent<PlayerWheelHolder>()
                .RemoveWeapon(this.gameObject);
        }
        else
        {
            GameObject.Find("PlayerWheelHolder").GetComponent<PlayerWheelHolder>()
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
