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

    //Counters
    int slow_counter = 0;
    [HideInInspector] public int previous_health = 0;

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
            }
        }
    }

    //Win an encounter with 10 or more max hp
    public void CHeckHPMaster()
    {
        HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
        if(HB.GiveMaxHealth() >= 10)
            AddAchievement("HP_master");
    }

    //If you have 13 weapons
    public void CheckCollector()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        if(RI.transform.childCount >= 13)
            AddAchievement("Collector");
    }

    //Win a fight while owning a weapon with 7 or more damage
    public void CheckForSlautherer()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for(int i = 0; i < RI.transform.childCount; i++)
        {
            if(RI.transform.GetChild(i).GetComponent<Weapon>().damage >= 7)
                AddAchievement("Slaughterer");
        }
    }

    //Take damage on the first turn 3 times in a row
    public void CheckForSlow()
    {
        bool hit = previous_health > player.HB.GiveCurrentHealth();
        if(hit)
        {
            slow_counter++;
            if (slow_counter >= 3)
                AddAchievement("Slow");
        } else
        {
            slow_counter = 0;
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
