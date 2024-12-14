using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardMenu : MonoBehaviour
{
    public List<GameObject> rewards1;
    public List<GameObject> chosenRewards;

    public GameObject rope;

    void Start()
    {
        makeRewardList();
        rope = GameObject.Find("Roope");
        //if(!rope.GetComponent<Test>().Paused())
        //{
           rope.GetComponent<Test>().PlayAnimation("Move");
        //} else
        //{
            GameObject.Find("Roope").GetComponent<Test>().UnPauseAnimation();
        //}
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
}
