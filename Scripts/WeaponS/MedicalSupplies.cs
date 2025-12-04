using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalSupplies : MonoBehaviour
{
    public List<GameObject> items;

    public void GiveRandomItem()
    {
        int index = Random.Range(0, items.Count);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerInventory>().AddItem(items[index]);
    }
}
