using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BasicEnemy : MonoBehaviour
{
    public string name;
    public Sprite image;

    public int maxHealth;
    public List<GameObject> weapons;

    private GameObject controller;

    public List<int> plan_1;
    public List<int> plan_2;

    public List<WeaponPair> weapon_pairs;

    [System.Serializable]
    public class WeaponPair { public List<int> pair; }
    private List<int> current_pair = new List<int>();

    public List<int> off_balance_choises;

    public bool advanced = false;

    public List<string> victory_barks;
    public string executioner_comment;
    public GameObject victory_message;

    private List<int> chosen_plan = new List<int>();
    private int planIndex = 0;
    private int off_balance_plan_index = 0;
    private int previous_pair = -1;

    [HideInInspector] public Weapon previous_weapon;
    [HideInInspector] public int weapon_streak = 0;

    [HideInInspector] public bool off_balance;
    [HideInInspector] public bool nearDeath;
    [HideInInspector] public bool off_balance_pattern_done;
    [HideInInspector] public bool commented = false;

    [HideInInspector] public HealthBar HB;

    [HideInInspector] public bool off_balance_triggered = false;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        TransferInfo();
        transform.parent.GetComponent<SpriteRenderer>().sprite = image;
        int plan = Random.Range(1, 3);
        switch(plan)
        {
            case 1: chosen_plan.AddRange(plan_1); break;
            case 2: chosen_plan.AddRange(plan_2); break;
        }

        MainController MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        MC.victory_barks = victory_barks;
        if (victory_message != null) MC.victory_message = victory_message;
        else MC.victory_message = null;

        HB = GameObject.Find("EnemyHealth").GetComponent<HealthBar>();
        GameObject.Find("light holder").GetComponent<Test>().PlayAnimation("balance");
    }

    public void TransferInfo()
    {
        controller.GetComponent<EnemyController>().maxHealth = maxHealth;
        controller.GetComponent<EnemyController>().weapons = weapons;
        if(!advanced) controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        controller.GetComponent<EnemyController>().currentEnemy = this.gameObject;
        controller.GetComponent<EnemyController>().Inisiate();
    }

    public int MakeChoise(MainController.Choise playerChoise)
    {

        if (!off_balance)
        {
            return PickWeaponFromPair();
        } else
        {
            return MakeOffBalanceChoise();
        }
    }

    public int MakeOffBalanceChoise()
    {
        int step = off_balance_choises[off_balance_plan_index];
        off_balance_plan_index++;
        if (off_balance_plan_index >= off_balance_choises.Count)
        {
            off_balance_pattern_done = true;
            off_balance_plan_index = 0;
            planIndex = 0; //Might need revision
        }

        //If weapon is destroyed, skip it in plan
        while (!CheckIfWeaponExists(step))
        {
            step = off_balance_choises[off_balance_plan_index];
            off_balance_plan_index++;
            if (off_balance_plan_index >= off_balance_choises.Count)
            {
                off_balance_pattern_done = true;
                off_balance_plan_index = 0;
                planIndex = 0; //Might need revision
            }
        }
        return step;
    }

    public void StikToPlan()
    {
        bool weapon_found = false;
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i] != null) 
            {
                if (weapons[i].GetComponent<SelfDestruct>())
                {
                    if(!weapons[i].GetComponent<SelfDestruct>().destroyed)
                    {
                        weapon_found = true;
                    }
                }
            }
        }


        if(weapon_found)
        {
            int step = chosen_plan[planIndex];
            planIndex++;
            if (planIndex >= chosen_plan.Count)
            {
                planIndex = 0;
            }

            bool valid_weapon_found = false;

            for (int i = 0; i < weapon_pairs[step].pair.Count; i++)
            {
                if (CheckIfWeaponExists(weapon_pairs[step].pair[i]))
                {
                    valid_weapon_found = true;
                    break;
                }
            }

            while (!valid_weapon_found)
            {
                planIndex++;
                if (planIndex >= chosen_plan.Count)
                {
                    planIndex = 0;
                }
                step = chosen_plan[planIndex];

                for (int i = 0; i < weapon_pairs[step].pair.Count; i++)
                {
                    if (CheckIfWeaponExists(weapon_pairs[step].pair[i]))
                    {
                        valid_weapon_found = true;
                        break;
                    }
                }
            }

            current_pair.Clear();
            for (int i = 0; i < weapon_pairs[step].pair.Count; i++)
            {
                if (CheckIfWeaponExists(weapon_pairs[step].pair[i]))
                {
                    current_pair.Add(weapon_pairs[step].pair[i]);
                }
            }
        } else
        {
            HB.InstaKill();
            GameObject.Find("EventSystem").GetComponent<MainController>().Win();
        }
    }

    public void SelectWeaponPair()
    {
        if(current_pair != null) current_pair.Clear();
        int legit_pairs = CalculateLegitPairs();
        //As long as there is pairs to use
        if (legit_pairs > 1)
        {
            int index = Random.Range(0, weapon_pairs.Count);
            while (index == previous_pair || CheckIfPairHasMissingWeapon(index))
            {
                index = Random.Range(0, weapon_pairs.Count);
            }
            previous_pair = index;
            current_pair.AddRange(weapon_pairs[index].pair);

        //Pick the last possible pair
        } else if(legit_pairs == 1)
        {
            for (int i = 0; i < weapon_pairs.Count; i++)
            {
                if(!CheckIfPairHasMissingWeapon(i))
                {
                    current_pair.AddRange(weapon_pairs[i].pair);
                    break;
                }
            }

        //Pick weapons left
        } else if(legit_pairs == 0)
        {
            List<int> temp = new List<int>();
            for(int i = 0; i < weapons.Count; i++)
            {
                if (CheckIfWeaponExists(i)) temp.Add(i);
            }
            //If there is enough weapons, make a random pair
            if (temp.Count > 2)
            {
                current_pair.Add(temp[Random.Range(0, temp.Count)]);
                int another = temp[Random.Range(0, temp.Count)];
                while(current_pair.Contains(another))
                {
                    another = temp[Random.Range(0, temp.Count)];
                }
                current_pair.Add(another);
            } else
            {
                current_pair.AddRange(temp);
            }

            if(current_pair.Count == 0)
            {
                GameObject.Find("EventSystem").GetComponent<MainController>().Win();
            }
        }
    }

    private bool CheckIfPairHasMissingWeapon(int index)
    {
        List<int> pair = weapon_pairs[index].pair;
        for(int i = 0; i < pair.Count; i++)
        {
            if(!CheckIfWeaponExists(pair[i]))
            {
                return true;
            }
        }
        return false;
    }

    public int CalculateLegitPairs()
    {
        int amount = 0;
        for(int i = 0; i < weapon_pairs.Count; i++)
        {
            if(!CheckIfPairHasMissingWeapon(i)) amount++;
        }
        return amount;
    }

    public void TelegraphWeaponPair()
    {
        GameObject EVI = GameObject.Find("EnemyWeaponInfo");
        for(int i = 0; i < EVI.transform.childCount; i++)
        {
            EVI.transform.GetChild(i).GetComponent<Image>().color = new Color(255, 255, 255);
            for (int j = 0; j < current_pair.Count; j++)
            {
                if (weapons[current_pair[j]].GetComponent<Weapon>().name == EVI.transform.GetChild(i).GetComponent<EnemyWeaponInfo>().weapon.name)
                {
                    EVI.transform.GetChild(i).GetComponent<Image>().color = new Color(150, 0, 0);
                }
            }
        }
    }

    public int PickWeaponFromPair()
    {
        return current_pair[Random.Range(0, current_pair.Count)];
    }

    public bool CheckIfWeaponExists(int index)
    {
        if(weapons[index] != null)
        {
            if (weapons[index].GetComponent<SelfDestruct>())
                if (weapons[index].GetComponent<SelfDestruct>().destroyed)
                    return false;
        }
        return weapons[index] != null;
    }

    private bool CheckIfWeaponHasBeenSpammed(int index)
    {
        if (weapons[index].GetComponent<Weapon>().spammable) return false;
        return weapon_streak >= 2 && previous_weapon == weapons[index].GetComponent<Weapon>();
    }

    public void ResetPlan()
    {
        planIndex = 0;
    }

    public void OffBalance()
    {
        off_balance_triggered = true;
        if (!HB.dead && !off_balance)
        {
            off_balance = true;
            GameObject.Find("light holder").GetComponent<Test>().PlayAnimation("offBalance");
            if(!GameObject.Find("EventSystem").GetComponent<StoryCheckList>().off_balance_explained)
            {
                GameObject.Find("EventSystem").GetComponent<StoryCheckList>().off_balance_explained = true;
                GameObject.Find("BarkHolder").GetComponent<BarkController>().ActivateInstantBark("Enemy is now off balance. Their strategy might change or some effects may activate.");
            }
        }
    }

    public void Balance()
    {
        if(off_balance && !off_balance_triggered)
        {
            off_balance = false;
            GameObject.Find("light holder").GetComponent<Test>().PlayAnimation("balance");
        }
    }

    public void ExecutionerComment()
    {
        StoryController SC = GameObject.Find("EventSystem").GetComponent<StoryController>();
        if (executioner_comment != "" && SC.executioner && !commented)
        {
            GameObject.Find("BarkHolder").GetComponent<BarkController>().ActivateExecutionerBark(executioner_comment);
            commented = true;
        }
    }
}
