using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tee : MonoBehaviour
{
    public void HealBoth()
    {
        GameObject EC = GameObject.FindGameObjectWithTag("EnemyHolder");
        GameObject PC = GameObject.FindGameObjectWithTag("Player");

        EC.GetComponent<EnemyController>().HB.HealDamage(1);
        PC.GetComponent<PlayerContoller>().HB.HealDamage(1);
        GetComponent<Weapon>().heal.Invoke();
    }

    public void BuffPlayerWeapon()
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        MC.playerChoise.damage++;
    }
}
