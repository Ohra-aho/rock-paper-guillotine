using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    EnemyController controller;
    public Weapon previous_weapon;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    private int MakeChoise(MainController.Choise choise)
    {
        if(GetComponent<BasicEnemy>().off_balance)
        {
            switch(previous_weapon.name)
            {
                case "Shield wall": return 0;
                case "Charge": return 1;
                case "Cannons": return 1;
            }
        } else
        {
            if(previous_weapon != null)
            {
                switch (previous_weapon.name)
                {
                    case "Shield wall": return 2;
                    case "Charge": return 0;
                    case "Cannons": return 1;
                }
            } else
            {
                return Random.Range(0, 2);
            }
        }
        return 0;
    }
}
