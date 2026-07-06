using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWeapons : MonoBehaviour
{
	public GameObject death_barks;
	void Awake()
	{
		MainController MC = GameObject.Find("EventSystem").GetComponent<MainController>();
		List<GameObject> starting_weapons = MC.GetComponent<StartingWeapons>().GiveStartingWeapons();
        if(starting_weapons.Count > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().ClearInventory();
            for (int i = 0; i < starting_weapons.Count; i++)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(starting_weapons[i]);
            }
        }
		Instantiate(death_barks, GameObject.Find("EventSystem").transform);
		GetComponent<StoryEvent>().over = true;
	}
}
