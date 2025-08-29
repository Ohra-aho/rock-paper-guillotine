using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallMan : MonoBehaviour
{
    GameObject controller;

    bool hurt;

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
            return GetComponent<BasicEnemy>().MakeChoise(MainController.Choise.kivi);
        } else
        {
            hurt = false;
            return 1;
        }
    }

    public void TakeDamage()
    {
        hurt = true;
    }
}
