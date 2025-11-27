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
            if (GameObject.Find("Seerumi(Clone)").GetComponent<Stacking>().stacks > 0)
            {
                hurt = false;
                return 1;
            }
            return GetComponent<BasicEnemy>().MakeChoise(MainController.Choise.kivi);
        }
    }

    public void TakeDamage()
    {
        if(GetComponent<BasicEnemy>().HB.GiveCurrentHealth() <= 2)
        {
            hurt = true;
        }
    }
}
