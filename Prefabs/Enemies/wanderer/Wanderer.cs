using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : MonoBehaviour
{
    bool bag_broken = false;
    public bool stick_missed = false;

    private void Awake()
    {
        GameObject.Find("EnemyHolder").GetComponent<EnemyController>().choiseMaker = MakeAChoise;
    }

    public int MakeAChoise(MainController.Choise c)
    {
        if(!bag_broken)
        {
            bag_broken = true;
            return 0;
        } else if(!stick_missed)
        {
            return 2;
        } else
        {
            stick_missed = false;
            return 1;
        }
    }
}
