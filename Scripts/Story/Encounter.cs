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
        for(int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, possible_enemies.Count);
            while(enemies.Contains(possible_enemies[index]))
            {
                index = Random.Range(0, possible_enemies.Count);
            }
            enemies.Add(possible_enemies[index]);
        }
    }

    public void Victory()
    {
        amount--;
        enemies.RemoveAt(0);
        if(amount <= 0)
        {
            GetComponent<StoryEvent>().over = true;
        }
    }
}
