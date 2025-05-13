using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lippu : MonoBehaviour
{
    bool debuffed = false;
    public void CheckIfDamaged()
    {
        if(GetComponent<Weapon>().player)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player.GetComponent<PlayerContoller>().HB.GiveCurrentHealth() < player.GetComponent<PlayerContoller>().HB.GiveMaxHealth())
            {
                if(!debuffed)
                {
                    GetComponent<Weapon>().damage -= 3;
                    debuffed = true;
                }
            } else
            {
                if(debuffed)
                {
                    GetComponent<Weapon>().damage += 3;
                    debuffed = false;
                }
            }
        }
    }
}
