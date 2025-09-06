using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambler : MonoBehaviour
{
    public bool won;
    private void Awake()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        controller.GetComponent<EnemyController>().choiseMaker = MakeAChoise;
    }

    public int MakeAChoise(MainController.Choise choise)
    {
        if(won)
        {
            won = false;
            return 0;
        } else {
            return GetComponent<BasicEnemy>().MakeChoise(choise);
        }
    }
}
