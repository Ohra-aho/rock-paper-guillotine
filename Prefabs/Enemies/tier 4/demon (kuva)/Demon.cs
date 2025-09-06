using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    public bool flames_active;
    public MainController.Choise effected_type;
    private void Awake()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    public int MakeChoise(MainController.Choise choise)
    {
        if(flames_active)
        {
            flames_active = false;
            switch(effected_type)
            {
                case MainController.Choise.kivi:
                    return 2;
                case MainController.Choise.paperi:
                    return 1;
                case MainController.Choise.sakset:
                    return 0;
            }
        }

        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().type == MainController.Choise.voittamaton)
            {
                return 0;
            }
        }

        return GetComponent<BasicEnemy>().MakeChoise(choise);
    }
}
