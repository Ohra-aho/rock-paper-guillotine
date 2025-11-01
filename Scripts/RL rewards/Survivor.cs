using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor : MonoBehaviour
{
    public int amount = 1;

    public void Chosen()
    {
        
    }

    public void Heal()
    {
        PlayerContoller player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
        player.HB.HealDamage(amount);
    }
}
