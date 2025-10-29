using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiskTaker : MonoBehaviour
{
    public void Chosen()
    {
        if (GetComponent<RLReward>().CheckIfCanBePicked())
        {
            GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Add(this.gameObject);
        }
    }
}
