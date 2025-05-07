using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hattu : MonoBehaviour
{
    public void DetectScissors()
    {
        if(GetComponent<Weapon>().opponent.type == MainController.Choise.sakset)
        {
            GameObject.Find("EnemyHolder").GetComponent<EnemyController>().currentEnemy.GetComponent<Revolverisankari>().EndStandoff();
        }
    }
}
