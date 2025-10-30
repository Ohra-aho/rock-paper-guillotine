using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picky : MonoBehaviour
{
    public void Chosen()
    {
        if (GetComponent<RLReward>().CheckIfCanBePicked())
        {
            GameObject.Find("Reward reroll").GetComponent<RewardReroll>().unlocked = true;
            GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Add(this.gameObject);
        }
    }
}
