using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydra : MonoBehaviour
{
    GameObject controller;
    GameObject RIE;
    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        RIE = GameObject.FindGameObjectWithTag("RIE");
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    public int MakeChoise(MainController.Choise c)
    {
        int immortal_head_chance = Random.Range(1, 5);
        int dead_heads = CalculateDeadHeads();
        int current_choise = GetComponent<BasicEnemy>().MakeChoise(c);

        if (immortal_head_chance <= dead_heads)
        {
            return 0;
        }

        if (current_choise == 2)
        {
            int dead_head_chance = Random.Range(1, 5);
            
            for (int i = 0; i < RIE.transform.childCount; i++)
            {
                Transform child = RIE.transform.GetChild(i);
                if(child.GetComponent<DisposableHead>())
                {
                    if (dead_head_chance <= dead_heads)
                    {
                        if (child.GetComponent<Weapon>().type == MainController.Choise.hyödytön)
                        {
                            return i;
                        }
                    }
                    else
                    {
                        if (child.GetComponent<Weapon>().type != MainController.Choise.hyödytön)
                        {
                            return i;
                        }
                    }
                }
            }
            
        }

        return current_choise;
    }

    public int CalculateDeadHeads()
    {
        int amount = 0;

        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            Transform child = RIE.transform.GetChild(i);
            if (child.GetComponent<DisposableHead>() && child.GetComponent<Weapon>().type == MainController.Choise.hyödytön)
            {
                amount++;
            }
        }

        return amount;
    }
}
