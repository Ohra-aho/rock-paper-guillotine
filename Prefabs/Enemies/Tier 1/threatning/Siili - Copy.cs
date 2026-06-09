using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siili : MonoBehaviour
{
    public bool damage_taken = false;
    bool worm_eaten = false;

    private void Awake()
    {
        //GameObject.Find("EnemyHolder").GetComponent<EnemyController>().choiseMaker = MakeAChoise;
        //GameObject.Find("EnemyHolder").GetComponent<EnemyController>().damageEffect = TakeDamage;

    }

    public int MakeAChoise(MainController.Choise c)
    {
        if (damage_taken)
        {
            if(!worm_eaten)
            {
                worm_eaten = true;
                damage_taken = false;
                //GetComponent<BasicEnemy>().Balance();
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
        if(!worm_eaten)
        {
            damage_taken = true;
            //GetComponent<BasicEnemy>().OffBalance();
        }
    }
}
