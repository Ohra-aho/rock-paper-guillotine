using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLController : MonoBehaviour
{
    public List<string> achievements = new List<string>();
    public int picks = 0;

    GameObject background;

    public List<GameObject> chosen_buffs = new List<GameObject>();

    PlayerContoller player;
    GameObject RI;
    GameObject wheel_holder;
    MainController MC;

    //Counters
    int slow_counter = 0;
    [HideInInspector] public int previous_health = 0;
    [HideInInspector] public int bosses_killed = 0;

    private void Start()
    {
        RL data = SaveSystem.LoadAchievements();
        if(data != null)
        {
            achievements.AddRange(data.achievements);
            picks = data.picks+1;
        }

        background = GameObject.Find("main screen background");

        ActivateAchievements();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
        RI = GameObject.FindGameObjectWithTag("RI");
        wheel_holder = GameObject.Find("PlayerWheelHolder");
        MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
    }

    public void ApplyBuffs()
    {
        for(int i = 0; i < chosen_buffs.Count; i++)
        {
            if(chosen_buffs[i].GetComponent<RLReward>().buffing != null)
            {
                chosen_buffs[i].GetComponent<RLReward>().buffing.Invoke();
            }
        }
    }

    //Lis‰‰ t‰h‰n jokin miehen kommentti, kun on ekan kerran
    public void ActivateAchievements()
    {
        for(int i = 0; i < achievements.Count; i++)
        {
            switch(achievements[i])
            {
                case "HP_master": background.transform.GetChild(0).gameObject.SetActive(true); break;
                case "Collector": background.transform.GetChild(1).gameObject.SetActive(true); break;
                case "Slaughterer": background.transform.GetChild(2).gameObject.SetActive(true); break;
                case "Slow": background.transform.GetChild(3).gameObject.SetActive(true); break;
                case "Experimentor": background.transform.GetChild(4).gameObject.SetActive(true); break;
                case "Madman": background.transform.GetChild(5).gameObject.SetActive(true); break;
                case "Traditionalist": background.transform.GetChild(6).gameObject.SetActive(true); break;
            }
        }
    }

    //Win an encounter with 10 or more max hp
    public void CHeckHPMaster()
    {
        if(!achievements.Contains("HP_master"))
        {
            HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
            if (HB.GiveMaxHealth() >= 10)
                AddAchievement("HP_master");
        }
    }

    //If you have 13 weapons
    public void CheckCollector()
    {
        if(!achievements.Contains("Collector"))
        {
            if (RI.transform.childCount >= 13)
                AddAchievement("Collector");
        }
    }

    //Win a fight while owning a weapon with 7 or more damage
    public void CheckForSlautherer()
    {
        if(!achievements.Contains("Slaughterer"))
        {
            for (int i = 0; i < RI.transform.childCount; i++)
            {
                if (RI.transform.GetChild(i).GetComponent<Weapon>().damage >= 7)
                    AddAchievement("Slaughterer");
            }
        }
    }

    //Take damage on the first turn 3 times in a row
    public void CheckForSlow()
    {
        if(!achievements.Contains("Slow"))
        {
            bool hit = previous_health > player.HB.GiveCurrentHealth();
            if (hit)
            {
                slow_counter++;
                if (slow_counter >= 3)
                    AddAchievement("Slow");
            }
            else
            {
                slow_counter = 0;
            }
        }
    }

    //Use 13 different weapons during a single game
    public void CheckForExperimentor()
    {
        if(!achievements.Contains("Experimentor"))
        {
            if (wheel_holder.GetComponent<PlayerWheelHolder>().used_weapons.Count >= 13)
            {
                AddAchievement("Experimentor");
            }
        }
    }

    //Win a fight with at least 2 "useless" weapons equipped
    public void CheckForMadman()
    {
        if(!achievements.Contains("Madman"))
        {
            int amount = 0;
            for(int i = 0; i < wheel_holder.transform.GetChild(0).transform.childCount-1; i++)
            {
                if(wheel_holder.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
                {
                    if (wheel_holder.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().type == MainController.Choise.hyˆdytˆn)
                    {
                        amount++;
                    }
                }
            }
            if(amount >= 2)
            {
                AddAchievement("Madman");
            }
        }
    }

    //Win a fight with the original rock, paper or sciccors after the first boss.
    public void CheckForTraditionalist()
    {
        if(!achievements.Contains("Traditionalist"))
        {
            if (bosses_killed > 0)
            {
                if (MC.playerChoise.name == "Paper" || MC.playerChoise.name == "Rock" || MC.playerChoise.name == "Scissors")
                {
                    AddAchievement("Traditionalist");
                }
            }
        }
    }


    public void SaveAchievements()
    {
        SaveSystem.SaveAchievements(new RL(achievements.ToArray(), picks));
    }

    public void AddAchievement(string name)
    {
        if(!achievements.Contains(name))
        {
            achievements.Add(name);
        }
    }

    [System.Serializable]
    public class RL
    {
        public string[] achievements;
        public int picks;
        public RL(string[] a, int p)
        {
            achievements = a;
            picks = p;
        }
    }
}
