using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantBehaviour : MonoBehaviour
{
    int supply_counter = 2;
    int? last_index = null;
    private void Awake()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        supply_counter = Random.Range(2, 6);
    }

    private int MakeChoise(MainController.Choise none)
    {
        if(supply_counter == 0)
        {
            supply_counter = Random.Range(1, 4);
            return 2;
        }

        int choise = Random.Range(0, 2);
        if(last_index != null)
        {
            if(choise == last_index)
            {
                choise = Random.Range(0, 2);
            }
        }

        last_index = choise;
        supply_counter--;
        return choise;
    }
}
