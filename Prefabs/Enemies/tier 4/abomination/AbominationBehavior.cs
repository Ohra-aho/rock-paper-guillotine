using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbominationBehavior : MonoBehaviour
{
    public bool damaged;
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    private int MakeChoise(MainController.Choise choise)
    {
        if(damaged)
        {
            damaged = false;
            return 0;
        }
        
        return GetComponent<BasicEnemy>().MakeChoise(choise);
    }
}
