using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantScissors : MonoBehaviour
{
    int previous_equips = 0;
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void CalculateDamage()
    {
        List<Weapon> weapons = player.GetComponent<PlayerContoller>().GetWeapons();
        int current_equips = weapons.Count;
        if (weapons.Contains(GetComponent<Weapon>())) current_equips--;

        if(current_equips != previous_equips)
        {
            GetComponent<Weapon>().damage += previous_equips;
            previous_equips = current_equips;
            GetComponent<Weapon>().damage -= previous_equips;
        }
    }
}
