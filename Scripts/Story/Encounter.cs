using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Encounter : MonoBehaviour
{
    public List<GameObject> possible_enemies;
    public List<GameObject> enemies;
    public int amount;
    public bool immideate_over;
    public bool last; //Needs immideate over to work

    public List<GameObject> surprices;

	public GameObject first_vistory;

    private void Awake()
    {
        MakeEnemyList();
    }

    public void MakeEnemyList()
    {
		StoryData SD = GameObject.Find("EventSystem").GetComponent<StoryController>().story_data;

		if(SD != null)
		{
			if(SD.enemies.Length > 0 && name == SD.tier)
			{
				for(int i = 0; i < SD.enemies.Length; i++)
				{
					if(FindSpecificEnemy(SD.enemies[i]) != null)
					{
						enemies.Add(FindSpecificEnemy(SD.enemies[i]));
					}
				}	
			}
			else if(possible_enemies.Count > 1)
			{
				for (int i = 0; i < amount; i++)
				{
					int index = Random.Range(0, possible_enemies.Count);
					while (enemies.Contains(possible_enemies[index]))
					{
						index = Random.Range(0, possible_enemies.Count);
					}
					enemies.Add(possible_enemies[index]);
				}
			} 
			else
			{
				for (int i = 0; i < amount; i++)
				{
					enemies.Add(possible_enemies[0]);
				}
			}
		}
        else if(possible_enemies.Count > 1)
        {
            for (int i = 0; i < amount; i++)
            {
                int index = Random.Range(0, possible_enemies.Count);
                while (enemies.Contains(possible_enemies[index]))
                {
                    index = Random.Range(0, possible_enemies.Count);
                }
                enemies.Add(possible_enemies[index]);
            }
        } else
        {
            for (int i = 0; i < amount; i++)
            {
                enemies.Add(possible_enemies[0]);
            }
        }
        //AddSurprice();
    }

	private GameObject FindSpecificEnemy(string name)
	{
		for(int i = 0; i < possible_enemies.Count; i++)
		{
			if(possible_enemies[i].name == name)
			{
				return possible_enemies[i];
			}
		}
		return null;
	}

    public void Victory()
    {
        enemies.RemoveAt(0);
        if(enemies.Count <= 0)
        {
            if(immideate_over) GetComponent<StoryEvent>().over = true;
        }
		GameObject.Find("EventSystem").GetComponent<SaveHub>().SaveAll();
    }

	public void FirstVictory()
	{
		Instantiate(first_vistory, transform.parent);
	}

    public void ChangeGear(int index)
    {
        GameObject wheel_holder = GameObject.Find("RightSide").transform.GetChild(0).gameObject;
        if(wheel_holder.transform.GetChild(0).name == "Enemy Wheel")
        {
            wheel_holder.transform.GetChild(index).gameObject.SetActive(true);
            wheel_holder.transform.GetChild(0).gameObject.SetActive(false);
            wheel_holder.transform.GetChild(index).SetAsFirstSibling();
        }
    }

    public void ResetGear()
    {
        GameObject wheel_holder = GameObject.Find("RightSide").transform.GetChild(0).gameObject;
        GameObject active_gear = wheel_holder.transform.GetChild(0).gameObject;
        wheel_holder.transform.GetChild(1).SetAsFirstSibling();
        wheel_holder.transform.GetChild(0).gameObject.SetActive(true);

        switch (active_gear.name)
        {
            case "Wheel 4": active_gear.transform.SetSiblingIndex(1); break;
            case "Wheel 5": active_gear.transform.SetSiblingIndex(2); break;
            case "Wheel 6": active_gear.transform.SetSiblingIndex(3); break;
        }
        active_gear.SetActive(false);
    }

    public void AddSurprice()
    {
        if(surprices.Count > 0)
        {
            int chance = Random.Range(1, 6);
            if (chance == 1)
            {
                int enemy = Random.Range(0, surprices.Count);
                int index = Random.Range(1, amount);
                enemies.Insert(index, surprices[enemy]);
            }
        }
    }
}
