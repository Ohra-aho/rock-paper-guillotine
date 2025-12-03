using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBelt : MonoBehaviour
{
    public GameObject throwing_knife;

    public void SpawnKnife()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerInventory>().AddItem(throwing_knife);
    }
}
