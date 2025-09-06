using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleBehavior : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    public int MakeChoise(MainController.Choise choise)
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Wings" && RIE.transform.GetChild(i).GetComponent<Weapon>().damage >= 3)
            {
                return 1;
            }
        }

        return GetComponent<BasicEnemy>().MakeChoise(choise);
    }
}
