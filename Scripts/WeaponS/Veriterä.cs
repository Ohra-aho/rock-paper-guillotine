using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veriterä : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name == GetComponent<Weapon>().name; };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 3;
        GetComponent<BuffController>().type_change = MainController.Choise.voittamaton;
        GetComponent<BuffController>().special_apply = true;
    }

    public void CalculateDamage()
    {
        if(GetComponent<Weapon>().player)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GetComponent<Weapon>().damage = 1 + (player.GetComponent<PlayerContoller>().HB.GiveMaxHealth() - player.GetComponent<PlayerContoller>().HB.GiveCurrentHealth());
        }
        else
        {
            GetComponent<Weapon>().damage = 
                1 + (GameObject.Find("EnemyHolder").GetComponent<EnemyController>().HB.GiveMaxHealth() - GameObject.Find("EnemyHolder").GetComponent<EnemyController>().HB.GiveCurrentHealth());
        }
    }
}
