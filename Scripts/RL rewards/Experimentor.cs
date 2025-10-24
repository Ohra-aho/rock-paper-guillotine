using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experimentor : MonoBehaviour
{
    public List<GameObject> possible_weapons;
    public List<GameObject> weapons_to_remove;
    public void Chosen()
    {
        if (GetComponent<RLReward>().CheckIfCanBePicked())
        {
            GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Add(this.gameObject);
            RandomizeStartingWeapons();
        }
    }

    public void RandomizeStartingWeapons()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject RI = GameObject.FindGameObjectWithTag("RI");

        //Remove starting weapons
        for(int i = 0; i < weapons_to_remove.Count; i++)
        {
            player.GetComponent<PlayerInventory>().items.Remove(weapons_to_remove[i]);
            for(int j = 0; j < player.GetComponent<PlayerInventory>().items.Count; j++)
            {
                if(player.GetComponent<PlayerInventory>().items[j].GetComponent<Weapon>().name == weapons_to_remove[i].GetComponent<Weapon>().name)
                {
                    player.GetComponent<PlayerInventory>().items.Remove(player.GetComponent<PlayerInventory>().items[j]);
                    break;
                }
            }

            for(int j = 0; j < RI.transform.childCount; j++)
            {
                if(RI.transform.GetChild(j).GetComponent<Weapon>().name == weapons_to_remove[i].GetComponent<Weapon>().name)
                {
                    Destroy(RI.transform.GetChild(j).gameObject);
                    break;
                }
            }
        }

        //Add new starting weapons
        for(int i = 0; i < 3; i++)
        {
            GameObject weapon = possible_weapons[Random.Range(0, possible_weapons.Count)];
            while (player.GetComponent<PlayerInventory>().items.Contains(weapon))
            {
                weapon = possible_weapons[Random.Range(0, possible_weapons.Count)];
            }
            player.GetComponent<PlayerInventory>().AddItem(weapon);
        }
    }
}

