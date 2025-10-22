using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public List<GameObject> possible_weapons;
    public void Chosen()
    {
        if (GetComponent<RLReward>().CheckIfCanBePicked())
        {
            Debug.Log("Que");
            GainRandomWeapon();
            GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Add(this.gameObject);
        }
    }

    private void GainRandomWeapon()
    {
        int index = Random.Range(0, possible_weapons.Count);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(possible_weapons[index]);
    }
}
