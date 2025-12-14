using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot : MonoBehaviour
{
    public void RotAway()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.DecreaseHealthBar(1, true);
        GetComponent<HealthIncrease>().amount--;
    }
}
