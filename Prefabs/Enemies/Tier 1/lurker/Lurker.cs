using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lurker : MonoBehaviour
{
    public bool taken_damage = false;
    public int tail_hit = 0;
    private bool tail = true;

    private void Awake()
    {
        GameObject.Find("EnemyHolder").GetComponent<EnemyController>().choiseMaker = MakeAChoise;
    }

    public int MakeAChoise(MainController.Choise c)
    {
        
        if(taken_damage)
        {
            taken_damage = false;
            return 0;
        } else if(tail_hit > 0)
        {
            tail = true;
            tail_hit--;
            return 2;
        } else
        {
            if (tail) { tail = false; return 1; }
            else { tail = true; return 2; }
        }
    }
}
