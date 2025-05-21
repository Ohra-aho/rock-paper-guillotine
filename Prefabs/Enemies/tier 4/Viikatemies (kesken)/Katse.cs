using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katse : MonoBehaviour
{
    public void AddEffect()
    {
        Debug.Log("Katse");
        GameObject.Find("EnemyHolder").GetComponent<EnemyController>().currentEnemy.GetComponent<Viikatemies>().katse = 1;
    }
}
