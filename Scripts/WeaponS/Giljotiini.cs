using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giljotiini : MonoBehaviour
{
    public void Fate()
    {
        //GameObject.FindGameObjectWithTag("Player")
        //    .GetComponent<PlayerContoller>().DealDamage(1000);
    }

    public void Demise()
    {
        GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerContoller>().Die();
    }
}
