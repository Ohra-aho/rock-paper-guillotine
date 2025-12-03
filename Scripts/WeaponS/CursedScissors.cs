using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedScissors : MonoBehaviour
{
    public GameObject curse;

    public void SpawnCurse()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerInventory>().AddItem(curse);
    }
}
