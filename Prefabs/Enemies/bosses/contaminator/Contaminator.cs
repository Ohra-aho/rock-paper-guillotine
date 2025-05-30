using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contaminator : MonoBehaviour
{
    EnemyController controller;
    public bool net;
    public int net_timer = 0;
    public bool flip = true;
    public int netted_burst = 0;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    private int MakeChoise(MainController.Choise choise)
    {
        if (!net)
        {
            net_timer--;
            if(net_timer <= 0)
            {
                net_timer = 3;
                return 1;
            }
            if(flip)
            {
                flip = !flip;
                return 0;
            } else
            {
                flip = !flip;
                return 2;
            }
        }
        else
        {
            netted_burst--;
            if(netted_burst <= 0)
            {
                net = false;
                flip = false;
                return 0;
            } else
            {
                return 2;
            }
        }
    }
}
