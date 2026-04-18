using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBoy : MonoBehaviour
{
    EnemyController controller;
    public Weapon previous_weapon;

    public int fan_counter = 0;
    public int fan_misses = 0; 

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    private int MakeChoise(MainController.Choise choise)
    {
        if (GetComponent<BasicEnemy>().off_balance)
        {
            return GetComponent<BasicEnemy>().MakeOffBalanceChoise();           
        }
        else
        {
            return GetComponent<BasicEnemy>().MakeChoise(choise);
        }
    }

}
