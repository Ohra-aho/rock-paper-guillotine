using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teemummo : MonoBehaviour
{
    int poison_counter = 2;
    int? last_index = null;
    private void Awake()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        poison_counter = Random.Range(1, 5);
    }

    private int MakeChoise(MainController.Choise none)
    {
        if (poison_counter == 0)
        {
            poison_counter = Random.Range(1, 4);
            return 2;
        }
        
        poison_counter--;
        return GetComponent<BasicEnemy>().MakeChoise(none);
    }
}
