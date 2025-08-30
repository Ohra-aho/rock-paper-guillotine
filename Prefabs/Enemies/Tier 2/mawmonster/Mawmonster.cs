using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mawmonster : MonoBehaviour
{
    GameObject controller;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    private int MakeChoise(MainController.Choise playerChoise)
    {
        int mutate = Random.Range(0, 5);
        if (mutate == 0)
        {
            return 0;
        }
        else
        {
            return GetComponent<BasicEnemy>().MakeChoise(MainController.Choise.kivi);
        }
    }
}
