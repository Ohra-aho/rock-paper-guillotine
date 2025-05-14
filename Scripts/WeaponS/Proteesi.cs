using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proteesi : MonoBehaviour
{
    public void HealthIncrease()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.IncreaseHealthBar(3);
        GetComponent<SelfDestruct>().Destruct();
    }
}
