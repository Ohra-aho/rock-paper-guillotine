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
	int plotter_counter = 0;
    [HideInInspector] public int previous_health = 0;
    [HideInInspector] public int bosses_killed = 0;
    public int hoard_counter = 0;

    public GameObject bark;

	public bool slaughterer = false;

    public void Insiate()
    {
        RL data = SaveSystem.LoadAchievements();
        if (data != null)
        {
            achievements.AddRange(data.achievements);
            picks = data.picks;
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
                case "Martyr": background.transform.GetChild(6).gameObject.SetActive(true); break;
                case "Risk taker": background.transform.GetChild(7).gameObject.SetActive(true); break;
                case "Neurotic": background.transform.GetChild(8).gameObject.SetActive(true); break;
                case "Plotter": background.transform.GetChild(9).gameObject.SetActive(true); break;
                case "Survivor": background.transform.GetChild(10).gameObject.SetActive(true); break;
                case "Relentless": background.transform.GetChild(11).gameObject.SetActive(true); break;
                case "Unyielding": background.transform.GetChild(12).gameObject.SetActive(true); break;
                case "Picky": background.transform.GetChild(13).gameObject.SetActive(true); break;
                case "Hoarder": background.transform.GetChild(14).gameObject.SetActive(true); break;
				default:
					List<GameObject> all_weapons = new List<GameObject>();
					//all_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/hyödytön"));
					//all_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/Kivi"));
					//all_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/paperi"));
					//all_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/sakset"));
					//all_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/voittamaton"));
					for(int j = 0; j < all_weapons.Count; j++)
					{
						if(all_weapons[j].GetComponent<Weapon>().name == achievements[i])
						{
							GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(all_weapons[j]);
							break;
						}
					}
					break;
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
        bark_holder.GetComponent<BarkController>().ActivateInstantBark(script);
    }


    //Win an encounter with 10 or more max hp
    //+2 HP
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

    //If you have 15 weapons
    //Have an additional reward to choose from after each fight.
    public void CheckCollector()
    {
        if(!achievements.Contains("Collector"))
        {
            if (RI.transform.childCount >= 12)
            {
                AddAchievement("Collector");
                Bark("You have amassed a sizable collection of weapons. How many you plan to use?");
            }
        }
    }

    //Deal 5 or more damage during a single round
    //+1 damage to all weapons but -2 to HP
    public void CheckForSlautherer()
    {
        if(!achievements.Contains("Slaughterer"))
        {
			AddAchievement("Slaughterer");
			Bark("That was a lot of damage. But can you pull that off again?");
        }
    }

    //Take damage on the first turn 4 times during a single game.
    //All weapons gain +2 to armor during the first round
    public void CheckForSlow()
    {
        if(!achievements.Contains("Slow"))
        {
			slow_counter++;
			if (slow_counter >= 4)
			{
				AddAchievement("Slow");
				Bark("That's the third time you have taken hit right away. Unlucky I guess.");
			}
			GetComponent<MainController>().first_turn = false;
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
                    if (wheel_holder.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().type == MainController.Choise.useless)
                    {
                        amount++;
                    }
                }
            }
            if(amount >= 2)
            {
                AddAchievement("Madman");
                Bark("You are one of the few who actually makes use of those \"useless\" weapons. Or maybe you just like losing.");
            }
        }
    }

    //Give up
    //If you give up, the next person gets one of your equipped weapons.
    public void CheckForMartyr()
    {
        if(!achievements.Contains("Martyr"))
        {
			if(GetComponent<StoryController>().storyIndex > 5)
			{
				AddAchievement("Martyr");
			}
        }
		for(int i = 0; i < chosen_buffs.Count; i++)
		{
			if(chosen_buffs[i].GetComponent<Traditionalist>())
			{
				chosen_buffs[i].GetComponent<Traditionalist>().Chosen();
				break;
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

            if(rocks == 4 && papers == 4 && scissors == 4)
            {
                AddAchievement("Neurotic");
                Bark("Perfectly balanced selection I guess. But can you select the correct combination?");
            }
        }
    }

    //Win 4 fights with only effect damage dealing weapons equipped in a single game.
    //Effect damage pierces armor
    public void CheckForPlotter()
    {
        if(!achievements.Contains("Plotter"))
        {
            GameObject wheel = wheel_holder.transform.GetChild(0).gameObject;
			bool found = false;
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
			if(!found) plotter_counter++;
            if(plotter_counter >= 4)
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
                Bark("I have tought for few times, that this is the time you die, but no. Maybe fear sharpens your wit.");
            }
        }
    }

    //Deal damage 5 times in a row.
    //At the start of each fight, deal 1 damage.
	int relentless_count = 0;
    public void CheckForRelentless(bool damage_taken)
    {
		if(damage_taken) relentless_count++;
		else relentless_count = 0;
        if(!achievements.Contains("Relentless"))
        {
			if (relentless_count >= 5)
			{
				AddAchievement("Relentless");
				Bark("You just keep on beating them up.");
			}
        }
    }

    //Heal 3 times during a single fight
    //Whenever you heal, all of your weapons gain +1 armor for one turn.
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
    //You can reroll rewards ones per encounter
    public void CheckForPicky()
    {
        if(!achievements.Contains("Picky"))
        {
			int amount = 0;
			for(int i = 0; i < RI.transform.childCount; i++)
			{
				if(!RI.transform.GetChild(i).GetComponent<Weapon>().used_this_game)
				{
					amount++;
				}
			}
			if(amount >= 7)
			{
				AddAchievement("Picky");
				Bark("Maybe I shold disable the reward mechanism. You are not using the weapons you pick anyway.");
			}
        }
    }

    //Win a fight with at least 10 points on your equipped weapons.
    //All weapons gain 2 points when you pick them.
    public void CheckForHoarder()
    {
        if(!achievements.Contains("Hoarder"))
        {
			List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
			for(int i = 0; i < weapons.Count; i++)
			{
				if(weapons[i].GetComponent<Stacking>())
				{
					hoard_counter += weapons[i].GetComponent<Stacking>().stacks;
				}
			}
            if(hoard_counter >= 10)
            {
                AddAchievement("Hoarder");
                Bark("You have collected quite a lot of poinst for your weapons. You just like seeing a number to go up don't you.");
            }
			hoard_counter = 0;
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
