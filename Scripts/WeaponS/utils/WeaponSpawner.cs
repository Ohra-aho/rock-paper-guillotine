using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
	public int spawn_limit = 0;
	int spawns = 0;
    public List<GameObject> weapons;

    public void SpawnRandomWeapon()
    {
		if(spawns < spawn_limit && spawn_limit != 0)
		{
			int index = Random.Range(0, weapons.Count);
        	GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(weapons[index]);	
		} else if(spawn_limit == 0)
		{
			int index = Random.Range(0, weapons.Count);
        	GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(weapons[index]);	
		}
		spawns++;
    }

    public void SpawnSpecificWeapon(int i)
    {
		if(spawns < spawn_limit && spawn_limit != 0)
		{
        	GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(weapons[i]);
		} else if(spawn_limit == 0)
		{
        	GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(weapons[i]);
		}
		spawns++;
    }

    public void SpawnOnlyWeapon()
    {
		if(spawns < spawn_limit && spawn_limit != 0)
		{
        	GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(weapons[0]);
		} else if(spawn_limit == 0)
		{
        	GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(weapons[0]);
		}
		spawns++;
    }

    public void SpawnMultipleWeapons(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
			SpawnOnlyWeapon();
        }
    }

    public void SpawnMultipleRandomWeapons(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
			if(spawns < spawn_limit && spawn_limit != 0)
			{
            	SpawnSpecificWeapon(Random.Range(0, weapons.Count));
			} else if(spawn_limit == 0)
			{
				SpawnSpecificWeapon(Random.Range(0, weapons.Count));
			}
			spawns++;
        }
    }
}
