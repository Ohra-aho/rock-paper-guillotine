using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor : MonoBehaviour
{
    public int amount = 1;

    public void Chosen()
    {
        if (GetComponent<RLReward>().CheckIfCanBePicked())
        {
            GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Add(this.gameObject);
        }
    }

    public void Heal()
    {
        PlayerContoller player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
        player.HB.HealDamage(amount);
    }
}
