using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public string id;

    public int damage_buff;
    public int armor_buff;


    private void OnDestroy()
    {
        RemoveBuff();
    }

    public void AddBuff()
    {
        if (damage_buff != 0)
        {
            transform.parent.GetComponent<Weapon>().damage += damage_buff;
        }

        if (armor_buff != 0)
        {
            transform.parent.GetComponent<Weapon>().armor += armor_buff;
        }
    }

    public void RemoveBuff()
    {
        if (damage_buff != 0)
        {
            transform.parent.GetComponent<Weapon>().damage -= damage_buff;
        }

        if (armor_buff != 0)
        {
            transform.parent.GetComponent<Weapon>().armor -= armor_buff;
        }
    }
}
