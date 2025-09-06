using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anglerfish : MonoBehaviour
{
    public bool bait = false;
    public bool spit = false;
    public MainController.Choise baited_type;
    public MainController.Choise spitted_type;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    public int MakeChoise(MainController.Choise choise)
    {
        if(bait)
        {
            bait = false;
            switch(baited_type)
            {
                case MainController.Choise.kivi:
                    if (Chance(4)) return 2;
                    else return 1;
                case MainController.Choise.paperi:
                    if (Chance(4)) return 1;
                    else return 0;
                case MainController.Choise.sakset:
                    if (Chance(4)) return 0;
                    else return 2;
            }
        }

        if(spit)
        {
            switch(spitted_type)
            {
                case MainController.Choise.kivi:
                    if (Chance(3)) return 0;
                    return 1;
                case MainController.Choise.paperi:
                    if (Chance(3)) return 2;
                    return 0;
                case MainController.Choise.sakset:
                    if (Chance(3)) return 1;
                    return 2;
            }
        }

        return GetComponent<BasicEnemy>().MakeChoise(choise);
    }

    private bool Chance(int max)
    {
        return Random.Range(1, max) == 1;
    }
}
