using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    bool active = false;

    public void Activate()
    {
        if(!active)
        {
            GetComponent<HealthIncrease>().Increase();
            active = true;
        }
    }
}
