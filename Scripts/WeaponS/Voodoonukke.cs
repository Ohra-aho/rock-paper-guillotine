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
        if (weapon.player)
        {
            GameObject MC = GameObject.Find("EventSystem");
            if (MC.GetComponent<MainController>().enemyChoise != null)
            {
                MC.GetComponent<MainController>().enemyChoise.TakeDamage(damage);
            } else
            {
                GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<HealthBar>().TakeDamage(damage);
            }
        }
        else
        {
            GameObject.Find("EventSystem").GetComponent<MainController>().playerChoise.TakeDamage(damage);
        }
    }
}
