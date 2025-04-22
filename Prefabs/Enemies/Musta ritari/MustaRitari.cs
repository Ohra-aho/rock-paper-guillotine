using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustaRitari : MonoBehaviour
{
    GameObject controller;
    GameObject RIE;

    public bool buffed;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        RIE = GameObject.FindGameObjectWithTag("RIE");
    }

    private void Update()
    {
        bool found = false;
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).childCount > 0)
            {
                found = true;
                break;
            }
        }
        buffed = found;
    }

    public int MakeChoise(MainController.Choise playerChoise)
    {
        if (buffed)
        {
            return 0;
        }
        else
        {
            return GetComponent<BasicEnemy>().MakeChoise(playerChoise);
        }
    }
}
