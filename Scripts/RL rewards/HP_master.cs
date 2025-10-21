using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_master : MonoBehaviour
{
    public void Chosen()
    {
        if(GetComponent<RLReward>().CheckIfCanBePicked())
        {
            IncreaseHP();
            GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Add(this.gameObject);
        }
    }

    private void IncreaseHP()
    {
        GameObject.Find("PlayerHealth").GetComponent<HealthBar>().IncreaseHealthBar(1, false);
    }
}
