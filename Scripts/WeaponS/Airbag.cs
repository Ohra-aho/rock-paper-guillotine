using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airbag : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = Cushion;
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void Cushion(Weapon w)
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.GiveCurrentHealth() == 1)
        {
            GetComponent<Healing>().Heal();
        }
    }
}
