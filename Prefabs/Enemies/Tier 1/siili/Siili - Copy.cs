using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siili : MonoBehaviour
{
    public bool damage_taken = false;
    bool worm_eaten = false;

    private void Awake()
    {
        GameObject.Find("EnemyHolder").GetComponent<EnemyController>().choiseMaker = MakeAChoise;
        GameObject.Find("EnemyHolder").GetComponent<EnemyController>().damageEffect = TakeDamage;

    }

    public int MakeAChoise(MainController.Choise c)
    {

        if (damage_taken)
        {
            damage_taken = false;
            if(!worm_eaten)
            {
                worm_eaten = true;
                return 1;
            } else
            {
                return GetComponent<BasicEnemy>().MakeChoise(c);
            }
        }
        else
        {
            return GetComponent<BasicEnemy>().MakeChoise(c);
        }
    }

    private void TakeDamage()
    {
        damage_taken = true;
    }
}
