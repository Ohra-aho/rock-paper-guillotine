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
    private List<GameObject> rewards;

    public GameObject rope;

    public GameObject real_inventory;

    MainController MC;

    //Might need some sort of connection to what player already has

    void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        rewards = new List<GameObject>();
        rewards3.AddRange(rewards2);
        rewards2.AddRange(rewards1);
        real_inventory = GameObject.Find("Real inventory");

        RemovePossibleRewards();
        makeRewardList();

        GetComponent<RewardBarks>().InstanciateRewardBarks();
        rope = GameObject.Find("Roope");
        rope.GetComponent<Test>().PlayAnimation("Move");
        rope.GetComponent<Test>().UnPauseAnimation();
    }

    private void Update()
    {
        if (!MC.CompareState(MainController.State.reward))
        {
            MC.SetNewState(MainController.State.reward);
        }
    }

    private void OnDestroy()
    {
        if (!MC.CompareState(MainController.State.idle))
        {
            MC.SetNewState(MainController.State.idle);
        }
        GameObject.Find("Reward reroll").GetComponent<RewardReroll>().reward_open = true;
    }

    public void EnableRewards()
    {
        for(int i = 0; i < 3; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<Revard>().disabled = false;
        }
    }

    public void EndThis()
    {
        Destroy(transform.GetChild(0).gameObject);
        Destroy(transform.GetChild(1).gameObject);
        Destroy(transform.GetChild(2).gameObject);
    }

    public void EndAudio()
    {
        rope.transform.GetChild(rope.transform.childCount - 1).GetChild(0).GetComponent<AudioPlayer>().StopClip();
    }

    public void ObliterateThis()
    {
        //rope.transform.GetChild(rope.transform.childCount - 1).GetChild(0).GetComponent<AudioPlayer>().StopClip();
        EndAudio();
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

    private void makeRewardList()
    {
        //Achievement check
        bool neurotic = false;
        Neurotic the_neurotic = null;

        for (int i = 0; i < MC.GetComponent<RLController>().chosen_buffs.Count; i++)
        {
            if(MC.GetComponent<RLController>().chosen_buffs[i].GetComponent<Neurotic>())
            {
                neurotic = true;
                the_neurotic = MC.GetComponent<RLController>().chosen_buffs[i].GetComponent<Neurotic>();
                break;
            }
        }

        if(!neurotic)
        {
            //Get at least one random reward
            rewards.Add(GetRandomReward());
            rewards.Add(GetRandomReward());

            //Change to get at least one healing weapon
            if (CheckIfPlayerIsHurt())
            {
                int heal_chance = Random.Range(1, 4);
                if (heal_chance == 3)
                {
                    rewards.Add(SubChooseRandomWeapon(healing));
                }
                else
                {
                    rewards.Add(GetRandomReward());
                }
            }
            else
            {
                rewards.Add(GetRandomReward());
            }
        } else
        {
            if(CheckIfPlayerIsHurt())
            {
                int heal_chance = Random.Range(1, 4);
                if(heal_chance == 3)
                {
                    int heal = Random.Range(1, 4);
                    switch (heal)
                    {
                        case 1:
                            rewards.Add(the_neurotic.rock_heal);
                            rewards.Add(the_neurotic.GiveRandomPaper(MC.reward_tier));
                            rewards.Add(the_neurotic.GiveRandomScissors(MC.reward_tier));
                            break;
                        case 2:
                            rewards.Add(the_neurotic.GiveRandomRock(MC.reward_tier));
                            rewards.Add(the_neurotic.paper_heal);
                            rewards.Add(the_neurotic.GiveRandomScissors(MC.reward_tier));
                            break;
                        case 3:
                            rewards.Add(the_neurotic.GiveRandomRock(MC.reward_tier));
                            rewards.Add(the_neurotic.GiveRandomPaper(MC.reward_tier));
                            rewards.Add(the_neurotic.scissors_heal);
                            break;
                    }
                } else
                {
                    rewards.Add(the_neurotic.GiveRandomRock(MC.reward_tier));
                    rewards.Add(the_neurotic.GiveRandomPaper(MC.reward_tier));
                    rewards.Add(the_neurotic.GiveRandomScissors(MC.reward_tier));
                }
            } else
            {
                rewards.Add(the_neurotic.GiveRandomRock(MC.reward_tier));
                rewards.Add(the_neurotic.GiveRandomPaper(MC.reward_tier));
                rewards.Add(the_neurotic.GiveRandomScissors(MC.reward_tier));
            }
        }
        for (int i = 0; i < rewards.Count; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<Revard>().actualReward = rewards[i];
            transform.GetChild(i).GetChild(0).GetComponent<Revard>().Invoke();
        }

    }

    private bool CheckIfPlayerIsHurt()
    {
        int current_health = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>().GiveCurrentHealth();
        int max_health = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<HealthBar>().GiveMaxHealth();
        int two_thirds = max_health / 3 * 2;
        if (two_thirds == 0) return false;
        return current_health <= max_health - (max_health / 3 * 2);
    }

    public void RemovePossibleRewards()
    {
        for(int j = 0; j < real_inventory.transform.childCount; j++)
        {
            SubWeaponRemoval(real_inventory.transform.GetChild(j).GetComponent<Weapon>().name, rewards1);
            SubWeaponRemoval(real_inventory.transform.GetChild(j).GetComponent<Weapon>().name, rewards2);
            SubWeaponRemoval(real_inventory.transform.GetChild(j).GetComponent<Weapon>().name, rewards3);
        }
    }
    //Used in function above
    private void SubWeaponRemoval(string name, List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].GetComponent<Weapon>().name == name)
            {
                list.RemoveAt(i);
                break;
            }
        }
    }

    private GameObject GetRandomReward()
    {
        switch (MC.reward_tier)
        {
            case 1:
                return SubChooseRandomWeapon(rewards1); 
            case 2:
                return SubChooseRandomWeapon(rewards2);
            case 3:
                return SubChooseRandomWeapon(rewards3);
        }
        return null;
    }
    //Used in function above
    private GameObject SubChooseRandomWeapon(List<GameObject> list)
    {
        //Get random reward which is not alrady chosen
        //
        if(list.Count == 0)
        {
            return GetRandomReward();
        } else
        {
            GameObject temp = list[Random.Range(0, list.Count)];
            int safe = 0;
            while (rewards.Contains(temp) && safe < 500)
            {
                temp = list[Random.Range(0, list.Count)];
                safe++;
            }
            if (safe >= 500) Debug.Log("Safe");
            return temp;
        }

    }

    private List<GameObject> GiveCurrentRewardTier()
    {
        switch (MC.reward_tier)
        {
            case 1: return rewards1;
            case 2: return rewards2;
            case 3: return rewards3;
        }
        return null;
    }

    private bool Chanse(float chance)
    {
        return Random.Range(0f, 1f) <= chance;
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

   
}
