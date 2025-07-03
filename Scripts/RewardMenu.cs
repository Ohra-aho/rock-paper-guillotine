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

    private int self_destructive = 0; //Weapons which synergize with self destruction
    private int heal = 0; //Weapons which heal or synergice with it
    private int health = 0; //Weapons which give health or care about it
    private int kivi_synegry = 0; //Weapons which synergize with other stones
    private int paperi_synergy = 0;
    private int sakset_synergy = 0;
    private int points = 0; //Weapons which collect points or synergize with them.


    //Might need some sort of connection to what player already has

    void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        rewards = new List<GameObject>();
        rewards3.AddRange(rewards2);
        rewards2.AddRange(rewards1);
        real_inventory = GameObject.Find("Real inventory");
        RemovePossibleRewards();
        CollectTypePreference();
        CollectEquippedWeaponPreferences();
        makeRewardList();
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
    }

    public void EnableRewards()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<Revard>().disabled = false;
        }
    }

    private void makeRewardList()
    {
        //Get at least one random reward
        rewards.Add(GetRandomReward());

        //Change to get at least one healing weapon
        int heal_chance = Random.Range(1, 4);
        //heal_chance = 3;
        if(heal_chance == 3)
        {
            rewards.Add(SubChooseRandomWeapon(healing));   
        }
        else
        {
            rewards.Add(GetRandomReward());
        }

        //Get preffered weapon
        int preffered_type = PickFavouriteType();
        //If there is a preffered type of weapons, pick weapons of that type
        if(Chanse(0.7f))
        {
            if (preffered_type > 0)
            {
                switch (preffered_type)
                {
                    //If type synergizes with certain main type of weapon, there is a change to just get that type of weapon
                    case 4:
                        if (Chanse(0.4f))
                        {
                            rewards.Add(SubChooseRandomWeapon(ExtractSubtypeOfWeapons(preffered_type)));
                        }
                        else
                        {
                            rewards.Add(SubChooseRandomWeapon(ExtractTypeOFWeapons(MainController.Choise.kivi)));
                        }
                        break;
                    case 5:
                        if (Chanse(0.4f))
                        {
                            rewards.Add(SubChooseRandomWeapon(ExtractSubtypeOfWeapons(preffered_type)));
                        }
                        else
                        {
                            rewards.Add(SubChooseRandomWeapon(ExtractTypeOFWeapons(MainController.Choise.paperi)));
                        }
                        break;
                    case 6:
                        if (Chanse(0.4f))
                        {
                            rewards.Add(SubChooseRandomWeapon(ExtractSubtypeOfWeapons(preffered_type)));
                        }
                        else
                        {
                            rewards.Add(SubChooseRandomWeapon(ExtractTypeOFWeapons(MainController.Choise.sakset)));
                        }
                        break;
                    default:
                        rewards.Add(
                            SubChooseRandomWeapon(ExtractSubtypeOfWeapons(preffered_type))
                        );
                        break;
                }
            }
        } else
        {
            rewards.Add(GetRandomReward());
        }

        //Correction
        if(rewards.Count < 3)
        {
            rewards.Add(GetRandomReward());
        }

        for (int i = 0; i < rewards.Count; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<Revard>().actualReward = rewards[i];
            transform.GetChild(i).GetChild(0).GetComponent<Revard>().Invoke();
        }
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


    //Collect types and alter rewards to keter to players build. More player collects certain weapons, more they get that type of weapons

    private void CollectEquippedWeaponPreferences()
    {
        List<Weapon> equippend_weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
        for(int i = 0; i < equippend_weapons.Count; i++)
        {
            if (equippend_weapons[i].self_destructive) self_destructive += 2;
            if (equippend_weapons[i].healing) heal += 2;
            if (equippend_weapons[i].health) health += 2;
            if (equippend_weapons[i].kivi_synegry) kivi_synegry += 2;
            if (equippend_weapons[i].paperi_synergy) paperi_synergy += 2;
            if (equippend_weapons[i].sakset_synergy) sakset_synergy += 2;
            if (equippend_weapons[i].points) points += 2;
        }
    }

    private void CollectTypePreference()
    {
        for(int i = 0; i < real_inventory.transform.childCount; i++)
        {
            Weapon weapon = real_inventory.transform.GetChild(i).gameObject.GetComponent<Weapon>();
            if (weapon.self_destructive) self_destructive++;
            if (weapon.healing) heal++;
            if (weapon.health) health++;
            if (weapon.kivi_synegry) kivi_synegry++;
            if (weapon.paperi_synergy) paperi_synergy++;
            if (weapon.sakset_synergy) sakset_synergy++;
            if (weapon.points) points++;
        }
        //Debug.Log(self_destructive + " " + heal + " " + health + " " + kivi_synegry + " " + paperi_synergy + " " + sakset_synergy + " " + points);
    }

    private int PickFavouriteType()
    {
        int temp = 0;

        List<int> preferences = new List<int>();
        preferences.Add(self_destructive);
        preferences.Add(heal);
        preferences.Add(health);
        preferences.Add(kivi_synegry);
        preferences.Add(paperi_synergy);
        preferences.Add(sakset_synergy);
        preferences.Add(points);

        int biggest = 0;
        for(int i = 0; i < preferences.Count; i++)
        {
            if(preferences[i] > 0)
            {
                if (preferences[i] > biggest)
                {
                    biggest = preferences[i];
                    temp = i + 1;
                }
                if (preferences[i] == biggest)
                {
                    int change = Random.Range(0, 2);
                    if (change == 1)
                    {
                        biggest = preferences[i];
                        temp = i + 1;
                    }
                }
            }
        }
        return temp;
    }

    //Extracts all weapons of certain type
    private List<GameObject> ExtractSubtypeOfWeapons(int type)
    {
        List<GameObject> temp = new List<GameObject>();
        List<GameObject> weapons = GiveCurrentRewardTier();
        switch (type)
        {
            case 1:
                for (int i = 0; i < weapons.Count; i++)
                    if(weapons[i].GetComponent<Weapon>().self_destructive)
                        temp.Add(weapons[i]);
                break;
            case 2:
                for (int i = 0; i < weapons.Count; i++)
                    if (weapons[i].GetComponent<Weapon>().healing)
                        temp.Add(weapons[i]);
                break;
            case 3:
                for (int i = 0; i < weapons.Count; i++)
                    if (weapons[i].GetComponent<Weapon>().health)
                        temp.Add(weapons[i]);
                break;
            case 4:
                for (int i = 0; i < weapons.Count; i++)
                    if (weapons[i].GetComponent<Weapon>().kivi_synegry)
                        temp.Add(weapons[i]);
                break;
            case 5:
                for (int i = 0; i < weapons.Count; i++)
                    if (weapons[i].GetComponent<Weapon>().paperi_synergy)
                        temp.Add(weapons[i]);
                break;
            case 6:
                for (int i = 0; i < weapons.Count; i++)
                    if (weapons[i].GetComponent<Weapon>().sakset_synergy)
                        temp.Add(weapons[i]);
                break;
            case 7:
                for (int i = 0; i < weapons.Count; i++)
                    if (weapons[i].GetComponent<Weapon>().points)
                        temp.Add(weapons[i]);
                break;
        }
        return temp;
    }

    //Extracts weapons of main type
    private List<GameObject> ExtractTypeOFWeapons(MainController.Choise type)
    {
        List<GameObject> temp = new List<GameObject>();
        List<GameObject> weapons = GiveCurrentRewardTier();
        for (int i = 0; i < weapons.Count; i++)
        {
            if(weapons[i].GetComponent<Weapon>().type == type)
            {
                temp.Add(weapons[i]);
            }
        }
        return temp;
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
