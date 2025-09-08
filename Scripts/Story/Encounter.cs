using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    public List<GameObject> possible_enemies;
    public List<GameObject> enemies;
    public int amount;
    public bool immideate_over;
    public bool last; //Needs immideate over to work

    private void Awake()
    {
        MakeEnemyList();
    }

    public void MakeEnemyList()
    {
        if(possible_enemies.Count > 1)
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
        
    }

    public void Victory()
    {
        enemies.RemoveAt(0);
        if(enemies.Count <= 0)
        {
            if(immideate_over) GetComponent<StoryEvent>().over = true;
        }
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
}
