using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
    public void IcreaseDamage()
    {
        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
        int index = Random.Range(0, weapons.Count);
        while(weapons[index].name == GetComponent<Weapon>().name)
        {
            index = Random.Range(0, weapons.Count);
        }
        weapons[index].damage++;
    }
}
