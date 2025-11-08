using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contaminator : MonoBehaviour
{
    EnemyController controller;
    public bool net;
    public int netted_burst = 0;
    bool granade_used = false;
    public bool mask_active = false;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        GameObject.Find("EventSystem").GetComponent<StoryCheckList>().first_boss_met = true;
    }

    private int MakeChoise(MainController.Choise choise)
    {
        if(controller.HB.GiveCurrentHealth() <= 3 && !granade_used && mask_active)
        {
            granade_used = true;
            return 3;
        } 
        else if(controller.HB.GiveCurrentHealth() <= 3 && !granade_used && !mask_active)
        {
            return 0;
        }
        else
        {
            if (!net)
            {
                return GetComponent<BasicEnemy>().MakeChoise(choise);
            }
            else
            {
                netted_burst--;
                if (netted_burst <= 0)
                {
                    net = false;
                    return GetComponent<BasicEnemy>().MakeChoise(choise);
                }
                else
                {
                    return 2;
                }
            }
        }  
    }
}
