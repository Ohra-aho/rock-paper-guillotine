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

    bool activated = false;

    //Counters
    int slow_counter = 0;
    int survivor_counter = 0;
    public int unyielding_counter = 0;
    [HideInInspector] public int previous_health = 0;
    [HideInInspector] public int bosses_killed = 0;
    public int hoard_counter = 0;

    public GameObject bark;

    private void Start()
    {
        RL data = SaveSystem.LoadAchievements();
        if(data != null)
        {
            achievements.AddRange(data.achievements);
            picks = data.picks;
            picks = 0;
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
                case "Tough": background.transform.GetChild(0).gameObject.SetActive(true); break;
                case "Collector": background.transform.GetChild(1).gameObject.SetActive(true); break;
                case "Slaughterer": background.transform.GetChild(2).gameObject.SetActive(true); break;
                case "Slow": background.transform.GetChild(3).gameObject.SetActive(true); break;
                case "Experimentor": background.transform.GetChild(4).gameObject.SetActive(true); break;
                case "Madman": background.transform.GetChild(5).gameObject.SetActive(true); break;
                case "Traditionalist": background.transform.GetChild(6).gameObject.SetActive(true); break;
                case "Risk taker": background.transform.GetChild(7).gameObject.SetActive(true); break;
                case "Neurotic": background.transform.GetChild(8).gameObject.SetActive(true); break;
                case "Plotter": background.transform.GetChild(9).gameObject.SetActive(true); break;
                case "Survivor": background.transform.GetChild(10).gameObject.SetActive(true); break;
                case "Relentless": background.transform.GetChild(11).gameObject.SetActive(true); break;
                case "Unyielding": background.transform.GetChild(12).gameObject.SetActive(true); break;
                case "Picky": background.transform.GetChild(13).gameObject.SetActive(true); break;
                case "Hoarder": background.transform.GetChild(14).gameObject.SetActive(true); break;
            }
        }
    }

    public void ActivateWinEffects()
    {
        for(int i = 0; i < chosen_buffs.Count; i++)
        {
            if(chosen_buffs[i].GetComponent<RLReward>().victory_effect != null)
            {
                chosen_buffs[i].GetComponent<RLReward>().victory_effect.Invoke();
            }
        }   
    }

    public void Bark(string script)
    {
        GameObject bark_holder = GameObject.Find("BarkHolder");
        GameObject new_bark = Instantiate(bark, bark_holder.transform);
        new_bark.GetComponent<Bark>().bark = script;
        new_bark.GetComponent<Bark>().immediate = true;
        new_bark.GetComponent<Bark>().Inisiate();
    }


    //Win an encounter with 10 or more max hp
    //+1 HP
    public void CHeckHPMaster()
    {
        if(!achievements.Contains("Tough"))
        {
            HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
            if (HB.GiveMaxHealth() >= 10)
            {
                AddAchievement("Tough");
                Bark("Your survival was never in doubt. You have grown quite tough. Let's see what brings you down.");
            }
        }
    }

    //If you have 13 weapons
    //Start with one additional random weapon
    public void CheckCollector()
    {
        if(!achievements.Contains("Collector"))
        {
            if (RI.transform.childCount >= 13)
            {
                AddAchievement("Collector");
                Bark("You have amassed a sizable collection of weapons. How many you plan to use?");
            }
        }
    }

    //Win a fight while owning a weapon with 7 or more damage
    //+1 damage to all weapons but -2 to HP
    public void CheckForSlautherer()
    {
        if(!achievements.Contains("Slaughterer"))
        {
            for (int i = 0; i < RI.transform.childCount; i++)
            {
                if (RI.transform.GetChild(i).GetComponent<Weapon>().damage >= 7)
                {
                    AddAchievement("Slaughterer");
                    Bark("That's a powerful weapon you got. But is it strong enough?");
                }
            }
        }
    }

    //Take damage on the first turn 3 times in a row
    //All weapons gain +2 to armor during the first round
    public void CheckForSlow()
    {
        if(!achievements.Contains("Slow"))
        {
            bool hit = previous_health > player.HB.GiveCurrentHealth();
            if (hit)
            {
                slow_counter++;
                if (slow_counter >= 3)
                {
                    AddAchievement("Slow");
                    Bark("That's the third time you have taken hit right away. Bit slow, are we.");
                } 
            }
            else
            {
                slow_counter = 0;
            }
        }
    }

    //Use 13 different weapons during a single game
    //Your starting weapons are selected at random from small selection
    public void CheckForExperimentor()
    {
        if(!achievements.Contains("Experimentor"))
        {
            if (wheel_holder.GetComponent<PlayerWheelHolder>().used_weapons.Count >= 13)
            {
                AddAchievement("Experimentor");
                Bark("You have been using a lot of different weapons. I like your style.");
            }
        }
    }

    //Win a fight with at least 2 "useless" weapons equipped
    //+1 HP for each "useless" equipped
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
                Bark("You are one of the few who actually makes use of those useless weapons. Or maybe you just like losing.");
            }
        }
    }

    //Win a fight with the original rock, paper or sciccors after the first boss.
    //OG weapons gain +1 damage
    public void CheckForTraditionalist()
    {
        if(!achievements.Contains("Traditionalist"))
        {
            if (bosses_killed > 0)
            {
                if (MC.playerChoise.name == "Paper" || MC.playerChoise.name == "Rock" || MC.playerChoise.name == "Scissors")
                {
                    AddAchievement("Traditionalist");
                    Bark("That was funny. Even I would have ditched the original weapons by now.");
                }
            }
        }
    }

    //Win a fight with no weapons left equipped
    //Self destructing weapons can be used twice
    public void CheckForRiskTaker()
    {
        if(!achievements.Contains("Risk taker"))
        {
            int amount = 0;
            GameObject wheel = wheel_holder.transform.GetChild(0).gameObject;
            for (int i = 0; i < wheel.transform.childCount - 1; i++)
            {
                GameObject weapon = wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon;
                if (weapon != null)
                {
                    if(weapon.GetComponent<SelfDestruct>())
                    {
                        if(!weapon.GetComponent<SelfDestruct>().destroyed)
                        {
                            amount++;
                            break;
                        }
                    } else {
                        amount++;
                        break;
                    }
                }
            }
            if(amount == 0)
            {
                AddAchievement("Risk taker");
                Bark("Well that's beautiful. One more turn and it would have been over. Just beautiful.");
            }
        }
    }

    //Own 4 rocks, 4 sicssors and 4 papers
    //You get always 1 scissors, 1 paper and 1 rock as a reward
    public void CheckForNeurotic()
    {
        int rocks = 0;
        int papers = 0;
        int scissors = 0;
        if(!achievements.Contains("Neurotic"))
        {
            for(int i = 0; i < RI.transform.childCount; i++)
            {
                switch(RI.transform.GetChild(i).GetComponent<Weapon>().type)
                {
                    case MainController.Choise.kivi: rocks++; break;
                    case MainController.Choise.paperi: papers++; break;
                    case MainController.Choise.sakset: scissors++; break;
                }
            }

            if(rocks >= 4 && papers >= 4 && scissors >= 4)
            {
                AddAchievement("Neurotic");
                Bark("Perfectly balanced selection I guess. But can you select the correct combination?");
            }
        }
    }

    //Win an fight with only effect damage dealing weapons equipped
    //Effect damage pierces armor
    public void CheckForPlotter()
    {
        if(!achievements.Contains("Plotter"))
        {
            bool found = false;
            GameObject wheel = wheel_holder.transform.GetChild(0).gameObject;
            for(int i = 0; i < wheel.transform.childCount-1; i++)
            {
                if(wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
                {
                    if (!wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<EffectDamage>())
                    {
                        found = true;
                        break;
                    }
                }
            }
            if(!found)
            {
                AddAchievement("Plotter");
                Bark("It seems you are prepared to deal damage no matter what. Seems to be working.");
            }
        }
    }

    //Win 3 fights with 1 HP during a single game
    //Heal 1 after each win
    public void CheckForSurvivor()
    {
        if(!achievements.Contains("Survivor"))
        {
            if(player.HB.GiveCurrentHealth() == 1)
            {
                survivor_counter++;
            }
            if(survivor_counter == 3)
            {
                AddAchievement("Survivor");
                Bark("I have tought for few times, that this time you are done, but no. Maybe fear sharpens you wit.");
            }
        }
    }

    //Win a fight with a draw
    //Deal 1 damage with each draw
    public void CheckForLucky()
    {
        if(!achievements.Contains("Relentless"))
        {
            if(MC.playerChoise.type == MC.enemyChoise.type)
            {
                AddAchievement("Relentless");
                Bark("Hehe... Usually I find draws a bit dull, but that was funny.");
            }
        }
    }

    //Heal 3 times during a one fight
    //Each selfdestructing healing item has +3 armor
    public void CheckForUnyielding()
    {
        if(!achievements.Contains("Unyielding"))
        {
            unyielding_counter++;
            if(unyielding_counter == 3)
            {
                AddAchievement("Unyielding");
                Bark("You just go up and down like a yo-yo. Quit taking damage and you maybe don't need to heal so much.");
            }
        }
    }

    //After the first boss, own 6 weapons you have never brought to a fight
    //You can reroll rewards ones ber encounter
    public void CheckForPicky()
    {
        if(!achievements.Contains("Picky"))
        {
            if(bosses_killed >= 1)
            {
                int amount = 0;
                for(int i = 0; i < RI.transform.childCount; i++)
                {
                    if(!RI.transform.GetChild(i).GetComponent<Weapon>().used_this_game)
                    {
                        amount++;
                    }
                }
                if(amount >= 6)
                {
                    AddAchievement("Picky");
                    Bark("Maybe I shold disable the reward mechanism. you are not using the weapons you pick anyway.");
                }
            }
        }
    }

    //Collect total of 20 points
    //All point weapons gain 1 point when you pick them
    public void CheckForHoarder()
    {
        if(!achievements.Contains("Hoarder"))
        {
            if(hoard_counter == 20)
            {
                AddAchievement("Hoarder");
                Bark("You have collected quite a lot of poinst for your weapons. You just like seeing a number to go up don't you.");
            }
        }
    }

    public void ActivateChosen()
    {
        if(!activated)
        {
            for (int i = 0; i < chosen_buffs.Count; i++)
            {
                chosen_buffs[i].GetComponent<RLReward>().activate.Invoke();
            }
            activated = true;
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
