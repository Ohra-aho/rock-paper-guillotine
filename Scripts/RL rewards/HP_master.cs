using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_master : MonoBehaviour
{
    public void Chosen()
    {
         IncreaseHP();
    }

    private void IncreaseHP()
    {
        GameObject.Find("PlayerHealth").GetComponent<HealthBar>().IncreaseHealthBar(1, false);
    }
}
