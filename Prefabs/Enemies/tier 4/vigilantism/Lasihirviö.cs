using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasihirviö : MonoBehaviour
{
    GameObject controller;

    bool hurt;
    bool retaliated;
    int not_working = 0;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        controller.GetComponent<EnemyController>().damageEffect = TakeDamage;
    }

    public int MakeChoise(MainController.Choise playerChoise)
    {
        if(!hurt)
        {
            not_working++;
            retaliated = false;
            if(not_working >= 3)
            {
                not_working = 0;
                return 1;
            }
            return 0;
        } else if(!retaliated)
        {
            retaliated = true;
            return 1;
        } else
        {
            hurt = false;
            retaliated = false;
            return 2;
        }
    }

    public void TakeDamage()
    {
        hurt = true;
    }
}
