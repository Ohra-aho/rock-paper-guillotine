using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public void GivePoints()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        List<Weapon> weapons = player.GetComponent<PlayerContoller>().GetWeapons();
        for(int i = 0; i < weapons.Count; i++)
        {
            if(weapons[i].GetComponent<Stacking>())
            {
                weapons[i].GetComponent<Stacking>().IncreaseStacks(1);
            }
        }
    }
}
