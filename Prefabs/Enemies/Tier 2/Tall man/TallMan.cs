using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallMan : MonoBehaviour
{
    GameObject controller;

    bool hurt;
    [HideInInspector] public bool dodge_active;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        controller.GetComponent<EnemyController>().damageEffect = TakeDamage;
    }

    private int MakeChoise(MainController.Choise playerChoise)
    {
        if(!hurt)
        {
            if (dodge_active)
            {
                dodge_active = false;
                int index = Random.Range(1, 3);
                index = SpamPrevention(index);
                return index;
            }
            return GetComponent<BasicEnemy>().MakeChoise(MainController.Choise.kivi);
        } else
        {
            hurt = false;
            int index = Random.Range(0, 2);
            index = SpamPrevention(index);

            GetComponent<BasicEnemy>().previous_weapon = GetComponent<BasicEnemy>().weapons[index].GetComponent<Weapon>();
            return index;
        }
    }

    private int SpamPrevention(int index)
    {
        if (GetComponent<BasicEnemy>().previous_weapon == GetComponent<BasicEnemy>().weapons[index].GetComponent<Weapon>())
        {
            GetComponent<BasicEnemy>().weapon_streak++;
            return Random.Range(0, 2);
        }
        else
        {
            GetComponent<BasicEnemy>().weapon_streak = 1;
        }
        return index;
    }

    public void TakeDamage()
    {
        if(GetComponent<BasicEnemy>().HB.GiveCurrentHealth() <= 2 && GameObject.Find("Seerumi(Clone)").GetComponent<Stacking>().stacks > 0)
        {
            GetComponent<BasicEnemy>().OffBalance();
            hurt = true;
        }
    }
}
