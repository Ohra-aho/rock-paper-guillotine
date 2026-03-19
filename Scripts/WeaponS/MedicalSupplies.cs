using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalSupplies : MonoBehaviour
{
    public List<GameObject> items;

    public void GiveRandomItem()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerInventory>().AddItem(this.gameObject);
    }
}
