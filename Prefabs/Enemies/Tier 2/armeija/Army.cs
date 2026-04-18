using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    EnemyController controller;
    public Weapon previous_weapon;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    private int MakeChoise(MainController.Choise choise)
    {
        if(!GetComponent<BasicEnemy>().off_balance)
        {
            return GetComponent<BasicEnemy>().MakeChoise(choise);
        } else
        {
            return GetComponent<BasicEnemy>().MakeOffBalanceChoise();
        }
    }
}
