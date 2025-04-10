using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardMenu : MonoBehaviour
{
    public List<GameObject> rewards1;
    public List<GameObject> rewards2;
    public List<GameObject> rewards3;
    public List<GameObject> healing;

    public List<GameObject> chosenRewards;

    public GameObject rope;

    public GameObject real_inventory;

    MainController MC;

    //Might need some sort of connection to what player already has

    void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        rewards3.AddRange(rewards2);
        rewards2.AddRange(rewards1);
        real_inventory = GameObject.Find("Real inventory");
        RemovePossibleRewards();
        makeRewardList();
        rope = GameObject.Find("Roope");
        rope.GetComponent<Test>().PlayAnimation("Move");
        rope.GetComponent<Test>().UnPauseAnimation();
    }

    private List<int> GetThreeUniqueRandomNumbers(int min, int max)
    {
        HashSet<int> uniqueNumbers = new HashSet<int>();

        while (uniqueNumbers.Count < 3)
        {
            int randomNumber = Random.Range(min, max); // Generate a random number in the range
            uniqueNumbers.Add(randomNumber); // Add to the set (duplicates will be ignored)
        }

        return new List<int>(uniqueNumbers); // Convert to a list and return
    }

    private void makeRewardList()
    {
        List<int> choises = new List<int>();
        switch(MC.reward_tier)
        {
            case 1: choises = GetThreeUniqueRandomNumbers(0, rewards1.Count); break;
            case 2: choises = GetThreeUniqueRandomNumbers(0, rewards2.Count); break;
            case 3: choises = GetThreeUniqueRandomNumbers(0, rewards3.Count); break;
        }

        int heal_chance = Random.Range(1, 4);
        //heal_chance = 3;
        if(heal_chance == 3)
        {
            choises[2] = Random.Range(0, 3);
            for (int i = 0; i < choises.Count-1; i++)
            {
                switch (MC.reward_tier)
                {
                    case 1:
                        transform.GetChild(i).GetChild(0).GetComponent<Revard>().actualReward = rewards1[choises[i]];
                        break;
                    case 2:
                        transform.GetChild(i).GetChild(0).GetComponent<Revard>().actualReward = rewards2[choises[i]];
                        break;
                    case 3:
                        transform.GetChild(i).GetChild(0).GetComponent<Revard>().actualReward = rewards3[choises[i]];
                        break;
                }
                transform.GetChild(i).GetChild(0).GetComponent<Revard>().Invoke();
            }
            transform.GetChild(choises.Count - 1).GetChild(0).GetComponent<Revard>().actualReward = healing[choises[choises.Count-1]];
            transform.GetChild(choises.Count - 1).GetChild(0).GetComponent<Revard>().Invoke();
        }
        else
        {
            for (int i = 0; i < choises.Count; i++)
            {
                switch (MC.reward_tier)
                {
                    case 1:
                        transform.GetChild(i).GetChild(0).GetComponent<Revard>().actualReward = rewards1[choises[i]];
                        break;
                    case 2:
                        transform.GetChild(i).GetChild(0).GetComponent<Revard>().actualReward = rewards2[choises[i]];
                        break;
                    case 3:
                        transform.GetChild(i).GetChild(0).GetComponent<Revard>().actualReward = rewards3[choises[i]];
                        break;
                }
                transform.GetChild(i).GetChild(0).GetComponent<Revard>().Invoke();
            }
        }
    }

    public void RemovePossibleRewards()
    {
        for(int j = 0; j < real_inventory.transform.childCount; j++)
        {
            for (int i = 0; i < rewards1.Count; i++)
            {
                if (rewards1[i].GetComponent<Weapon>().name == real_inventory.transform.GetChild(j).GetComponent<Weapon>().name)
                {
                    rewards1.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < rewards2.Count; i++)
            {
                if (rewards2[i].GetComponent<Weapon>().name == real_inventory.transform.GetChild(j).GetComponent<Weapon>().name)
                {
                    rewards2.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < rewards3.Count; i++)
            {
                if (rewards3[i].GetComponent<Weapon>().name == real_inventory.transform.GetChild(j).GetComponent<Weapon>().name)
                {
                    rewards3.RemoveAt(i);
                    break;
                }
            }
        }
    }

    public void DisableRewards()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount > 0)
            {
                transform.GetChild(i).GetChild(0).GetComponent<Revard>().disabled = true;
            }
        }
    }

    public void EndThis()
    {
        Destroy(transform.GetChild(0).gameObject);
        Destroy(transform.GetChild(1).gameObject);
        Destroy(transform.GetChild(2).gameObject);
    }

    public void ObliterateThis()
    {
        rope.transform.GetChild(rope.transform.childCount - 1).GetChild(0).GetComponent<AudioPlayer>().StopClip();
        Destroy(gameObject);
    }

    public void AnimationEnd()
    {
        GameObject seh = GameObject.Find("Story Event Holder");
        if (seh.transform.childCount > 0)
        {
            if (seh.transform.GetChild(0).GetComponent<Encounter>())
            {
                if (seh.transform.GetChild(0).GetComponent<Encounter>().enemies.Count <= 0)
                {
                    seh.transform.GetChild(0).GetComponent<StoryEvent>().over = true;
                }
            }
        }
    }
}
