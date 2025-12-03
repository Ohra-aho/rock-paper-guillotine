using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourJokers : MonoBehaviour
{
    public GameObject joker;

    public void SpawnCurse()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        for(int i = 0; i < 3; i++)
        {
            player.GetComponent<PlayerInventory>().AddItem(joker);
        }
    }
}
