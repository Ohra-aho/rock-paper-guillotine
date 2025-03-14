using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voodoonukke : MonoBehaviour
{
    public int damage;

    private void Awake()
    {
        GetComponent<BuffController>().special = Retaliate;
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }

    public void Retaliate(Weapon weapon)
    {
        Debug.Log(weapon.name + " : " + weapon.player);
        if (weapon.player)
        {
            GameObject.Find("EventSystem").GetComponent<MainController>().enemyChoise.TakeDamage(null, damage);
        }
        else
        {
            GameObject.Find("EventSystem").GetComponent<MainController>().playerChoise.TakeDamage(null, damage);
        }
    }
}
