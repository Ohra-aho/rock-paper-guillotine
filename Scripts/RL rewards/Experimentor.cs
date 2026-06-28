using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experimentor : MonoBehaviour
{
    public List<GameObject> possible_weapons;

	void Awake()
	{
		possible_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/Kivi"));
		possible_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/paperi"));
		possible_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/sakset"));
	}

	public void Chosen()
    {
        RandomizeStartingWeapons();
    }

    public void RandomizeStartingWeapons()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //Add new starting weapons
        for(int i = 0; i < 2; i++)
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

