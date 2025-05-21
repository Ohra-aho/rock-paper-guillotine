using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kalma : MonoBehaviour
{
    public void AddEffect()
    {
        Debug.Log("Kalma");
        GameObject.Find("EnemyHolder").GetComponent<EnemyController>().currentEnemy.GetComponent<Viikatemies>().kalma = 1;
    }
}
