using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Howler : MonoBehaviour
{
    public bool howl_active;
    public MainController.Choise howled_weapon;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    public int MakeChoise(MainController.Choise choise)
    {
        if(howl_active)
        {
            howl_active = false;
            switch (howled_weapon)
            {
                case MainController.Choise.kivi:
                    if (Chance(4)) return 1;
                    return 0;
                case MainController.Choise.paperi:
                    if (Chance(4)) return 2;
                    return 1;
                case MainController.Choise.sakset:
                    if (Chance(2)) return 0;
                    return 2;
                default:
                    return GetComponent<BasicEnemy>().MakeChoise(choise);
            }
        }

        return GetComponent<BasicEnemy>().MakeChoise(choise);
    }

    public bool Chance(int max)
    {
        int x = Random.Range(1, max);
        if (x == 1) return true;
        else return false;
    }
}
