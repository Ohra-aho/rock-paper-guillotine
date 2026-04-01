using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuijamies : MonoBehaviour
{
    EnemyController controller;
    bool hurt;
    int smoke_timer = 3;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        controller.GetComponent<EnemyController>().damageEffect = TakeDamage;
    }

    private int MakeChoise(MainController.Choise choise)
    {
        if(!GetComponent<BasicEnemy>().off_balance)
        {
            if (!hurt && smoke_timer > 0)
            {
                smoke_timer--;
                return 2;
            }
            else
            {
                return GetComponent<BasicEnemy>().MakeChoise(choise);
            }
        } else
        {
            return GetComponent<BasicEnemy>().MakeOffBalanceChoise();
        }
    }

    private void TakeDamage()
    {
        hurt = true;
        if (GetComponent<BasicEnemy>().HB.GiveCurrentHealth() == 1)
        {
            GetComponent<BasicEnemy>().OffBalance();
        }
    }
}
