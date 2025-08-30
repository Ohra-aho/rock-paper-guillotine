using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nunna : MonoBehaviour
{
    GameObject controller;

    bool hurt;
    int not_working = 0;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        controller.GetComponent<EnemyController>().damageEffect = TakeDamage;
    }

    private int MakeChoise(MainController.Choise playerChoise)
    {
        if (!hurt)
        {
            return GetComponent<BasicEnemy>().MakeChoise(playerChoise);
        } else
        {
            not_working++;
            if(not_working >= 2)
            {
                not_working = 0;
                return GetComponent<BasicEnemy>().MakeChoise(playerChoise);
            }
            hurt = false;
            return 0;
        }
    }

    public void TakeDamage()
    {
        hurt = true;
    }
}
