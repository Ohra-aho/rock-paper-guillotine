using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veriterä : MonoBehaviour
{
    public void CalculateDamage()
    {
        if(GetComponent<Weapon>().player)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GetComponent<Weapon>().damage = 1 + (player.GetComponent<PlayerContoller>().HB.GiveMaxHealth() - player.GetComponent<PlayerContoller>().HB.GiveCurrentHealth());
        }
    }
}
