using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolverisankari : MonoBehaviour
{
    int stand_off_counter;
    int not_working;

    EnemyController EC;

    private void Awake()
    {
        EC = GameObject.Find("EnemyHolder").GetComponent<EnemyController>();
        stand_off_counter = Random.Range(2, 4);
        EC.choiseMaker = MakeAChoise;
        EC.damageEffect = NotWorking;
        not_working = 2;
    }

    public void EndStandoff()
    {
        stand_off_counter = 0;
    }

    public int MakeAChoise(MainController.Choise choise)
    {
        if(stand_off_counter > 0)
        {
            stand_off_counter--;
            return 1;
        } else
        {
            if(GetComponent<BasicEnemy>().weapons[0].GetComponent<Weapon>().damage > 0)
            {
                if(not_working > 0)
                {
                    return 0;
                } else
                {
                    not_working = 1;
                    return 1;
                }
            } else
            {
                return 2;
            }
        }
    }

    public void NotWorking()
    {
        not_working--;
    }
}
