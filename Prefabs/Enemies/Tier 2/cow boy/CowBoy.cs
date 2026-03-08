using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBoy : MonoBehaviour
{
    EnemyController controller;
    public Weapon previous_weapon;

    public int fan_counter = 0;
    public int fan_misses = 0; 

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    private int MakeChoise(MainController.Choise choise)
    {
        if (GetComponent<BasicEnemy>().off_balance)
        {
            switch (previous_weapon.name)
            {
                case "Presicion shot": 
                    if(previous_weapon.damage <= 1) 
                        return 2;
                    else
                        return GetComponent<BasicEnemy>().MakeOffBalanceChoise();
                    
                case "Fan the hammer": return 0;
            }
        }
        else if(DamageTooLow())
        {
            return 2;
        } else
        {
            return GetComponent<BasicEnemy>().MakeChoise(choise);
        }
        return 0;
    }

    private bool DamageTooLow()
    {
        int damage = 0;
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().GiveEffectiveDamage() < 1)
            {
                damage++;
            }
        }
        return damage == 3;
    }
}
