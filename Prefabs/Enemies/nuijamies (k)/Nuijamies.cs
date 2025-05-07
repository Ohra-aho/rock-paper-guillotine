using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuijamies : MonoBehaviour
{
    EnemyController controller;
    bool hurt;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        controller.GetComponent<EnemyController>().damageEffect = TakeDamage;
    }

    private int MakeChoise(MainController.Choise choise)
    {
        if(!hurt)
        {
            return 2;
        } else
        {
            return GetComponent<BasicEnemy>().MakeChoise(choise);
        }
    }

    private void TakeDamage()
    {
        hurt = true;
    }
}
