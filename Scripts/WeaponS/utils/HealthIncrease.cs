using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncrease : MonoBehaviour
{
    public int amount;

    public void Increase()
    {
        Debug.Log("Increasing" +
            "");
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.IncreaseHealthBar(amount);
    }

    public void Decrease()
    {
        Debug.Log("Decreasing");
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.DecreaseHealthBar(amount);
    }
}
