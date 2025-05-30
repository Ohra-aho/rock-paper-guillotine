using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    EnemyController controller;
    public bool grab;
    bool flip;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    private int MakeChoise(MainController.Choise choise)
    {
        if (!grab)
        {
            if(!flip)
            {
                flip = !flip;
                return 1;
            } else
            {
                flip = !flip;
                return 0;
            }
        }
        else
        {
            return GetComponent<BasicEnemy>().MakeChoise(choise);
        }
    }


}
