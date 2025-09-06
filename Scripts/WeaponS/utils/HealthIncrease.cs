using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncrease : MonoBehaviour
{
    public int amount;
    public bool in_view;

    public void Increase()
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.IncreaseHealthBar(amount, in_view);
        
    }

    public void Decrease()
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>();
        HB.DecreaseHealthBar(amount, in_view);
    }
}
