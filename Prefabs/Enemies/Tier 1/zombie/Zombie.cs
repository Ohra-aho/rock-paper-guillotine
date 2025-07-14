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
                if(Hurt())
                {
                    int chance = Random.Range(0, 3);
                    if (chance > 0) return 2;
                    else return 0;
                }
                return 0;
            }
        }
        else
        {
            return GetComponent<BasicEnemy>().MakeChoise(choise);
        }
    }

    private bool Hurt()
    {
        int current_health = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<HealthBar>().GiveCurrentHealth();
        int max_health = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<HealthBar>().GiveMaxHealth();
        return current_health < max_health;
    }


}
