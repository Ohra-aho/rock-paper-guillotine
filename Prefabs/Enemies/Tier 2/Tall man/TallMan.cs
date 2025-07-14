using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallMan : MonoBehaviour
{
    GameObject controller;

    bool hurt;
    bool dodged;
    int not_working = 0;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        controller.GetComponent<EnemyController>().damageEffect = TakeDamage;
    }

    private int MakeChoise(MainController.Choise playerChoise)
    {
        if(!hurt)
        {
            dodged = false;
            not_working++;
            if (not_working >= 3)
            {
                hurt = true;
                not_working = 0;
            }
            return 2;
        } else if(!dodged)
        {
            //if(hurt)
            //{
                dodged = true;
                hurt = false;
                return 0;
           /* } else
            {
                hurt = false;
                dodged = false;
                return 1;
            }*/
            
        } else
        {
            hurt = false;
            dodged = false;
            return 1;
        }
    }

    public void TakeDamage()
    {
        hurt = true;
    }
}
