using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leka : MonoBehaviour
{
    // Start is called before the first frame update
    public void WinDraws()
    {
        if (GetComponent<Weapon>().player)
        {
            GetComponent<Weapon>().opponent.TakeDamage(
                    GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB, GetComponent<Weapon>().damage
                );
        }
        else
        {
            GetComponent<Weapon>().opponent.TakeDamage(
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB, GetComponent<Weapon>().damage
                );
        }
    }
}
