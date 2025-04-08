using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardMenu : MonoBehaviour
{
    public List<GameObject> rewards1;
    public List<GameObject> chosenRewards;

    public GameObject rope;

    public GameObject real_inventory;


    void Awake()
    {
        real_inventory = GameObject.Find("Real inventory");
        RemovePossibleRewards();
        makeRewardList();
        rope = GameObject.Find("Roope");
        rope.GetComponent<Test>().PlayAnimation("Move");
        GameObject.Find("Roope").GetComponent<Test>().UnPauseAnimation();
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
        List<int> choises = GetThreeUniqueRandomNumbers(0, rewards1.Count);
        for(int i = 0; i < choises.Count; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<Revard>().actualReward = rewards1[choises[i]];
            transform.GetChild(i).GetChild(0).GetComponent<Revard>().Invoke();
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
