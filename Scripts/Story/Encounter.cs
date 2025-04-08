using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    public List<GameObject> possible_enemies;
    public List<GameObject> enemies;
    public int amount;

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
            //GetComponent<StoryEvent>().over = true;
        }
    }
}
