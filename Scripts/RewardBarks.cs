using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBarks : MonoBehaviour
{
    List<GameObject> reward_barks = new List<GameObject>();
    private void Awake()
    {
        reward_barks = GameObject.FindGameObjectWithTag("GameController").GetComponent<RewardBarkController>().reward_barks;
    }

    public void InstanciateRewardBarks()
    {
        reward_barks = GameObject.FindGameObjectWithTag("GameController").GetComponent<RewardBarkController>().reward_barks;

        for (int i = 0; i < reward_barks.Count; i++)
        {
            if(CompareName(reward_barks[i].GetComponent<RewardBark>().triggering_weapon))
            {
                GameObject new_reward_bark = Instantiate(reward_barks[i], transform);
                SetUpTrigger(new_reward_bark, true);
            } else if(CompareType(reward_barks[i].GetComponent<RewardBark>().triggering_type))
            {
                GameObject new_reward_bark = Instantiate(reward_barks[i], transform);
                SetUpTrigger(new_reward_bark, false);
            }
            
        }
    }

    private bool CompareName(string name)
    {
        for(int i = 0; i < 3; i++)
        {
            if(transform.GetChild(i).GetChild(0).GetComponent<Revard>().actualReward.GetComponent<Weapon>().name == name)
            {
                return true;
            }
        }
        return false;
    }

    private bool CompareType(MainController.Choise? type)
    {
        for (int i = 0; i < 3; i++)
        {
            if (transform.GetChild(i).GetChild(0).GetComponent<Revard>().actualReward.GetComponent<Weapon>().type == type)
            {
                return true;
            }
        }
        return false;
    }

    private void SetUpTrigger(GameObject reward_bark, bool name)
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(i);
            Weapon temp = transform.GetChild(i).GetChild(0).GetComponent<Revard>().actualReward.GetComponent<Weapon>();
            if (name)
            {
                if(temp.name == reward_bark.GetComponent<RewardBark>().triggering_weapon)
                {
                    transform.GetChild(i).GetChild(0).GetComponent<NonUIButton>().press.AddListener(reward_bark.GetComponent<RewardBark>().Activate);
                }
            } else
            {
                if (temp.type == reward_bark.GetComponent<RewardBark>().triggering_type)
                {
                    transform.GetChild(i).GetChild(0).GetComponent<NonUIButton>().press.AddListener(reward_bark.GetComponent<RewardBark>().Activate);
                }
            }
        }
    }
}
