using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] Sprite active;
    [SerializeField] Sprite inactive;

    public GameObject machine;
    public GameObject player;

    public GameObject story_event_holder;

    public bool isActive;

    public bool deactivated; //If start button needs to be deactivated individually

    MainController MC;
    PlayerWheelHolder PWH;

    BarkController BC;

    private string[] forfeit_barks =
    {
        "Suit yourself.",
        "Oh... Sorry about that.",
        "Pathetic",
        "What's the rush?",
        "If you insist.",
        "Won't even go down fighting?",
        "Pity.",
        "Have peace.",
        "Why give up?",
        "Going already?",
        "Can't even have fun with you people."
    };

    bool empty_regard = false; //To prevent constant barking
    int emtpy_regard_counter = 3; //Amount of fights man waits to bark at empty wheel again
    private string[] lacking_gear_barks =
    {
        "Are you seeking a challenge or are you just dumb?",
        "I think this will be interesting",
        "I don't get what you are going for, but surprise me.",
        "You still have empty bolts. You have a plan?",
        "Is this too easy for you? You have to handicap yourself?"
    };

    //Load out comments
    /*
     Full = all other slots are used
     */

    bool loadout_commented = false;
    List<string> previous_loadout = new List<string>();

    private string[] giant_scissors_full = {
        "You are not using those scissors to their full potential.",
        "You may as well use any other scissors.",
        "You could just oneshot enemies with a little risk taking."
    };

    private string[] back_to_basics =
    {
        "Back to basics.",
        "Why use the starting weapons? You have other options.",
        "What? New weapons not good for you enough?"
    };


    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        PWH = GameObject.Find("PlayerWheelHolder").GetComponent<PlayerWheelHolder>();
        BC = GameObject.Find("BarkHolder").GetComponent<BarkController>();
    }

    private void Update()
    {
        FindEncounter();
    }

    public void FindEncounter()
    {
        if(MC.CompareState(MainController.State.idle))
        {
            bool found = false;
            for (int i = 0; i < story_event_holder.transform.childCount; i++)
            {
                if (!story_event_holder.transform.GetChild(i).GetComponent<Encounter>())
                {
                    found = false;
                }
                else
                {
                    found = true;
                    break;
                }
            }
            GetComponent<NonUIButton>().interactable = found;

        } else if(MC.CompareState(MainController.State.in_battle))
        {
            GetComponent<NonUIButton>().interactable = true;
        } else
        {
            GetComponent<NonUIButton>().interactable = false;
        }

    }

    public void Activate()
    {
        GameObject.Find("ChoisePanel").GetComponent<PlayerContoller>().defeat = false;
        GameObject ec = GameObject.Find("EnemyHolder");
        ec.GetComponent<EnemyController>().victory = false;
        //ec.GetComponent<EnemyController>().HandleEnemy();

        GetComponent<SpriteRenderer>().sprite = active;
        machine.GetComponent<Test>().PlayAnimation("CloseMachine");
        isActive = true;
        GameObject.Find("ChoisePanel").GetComponent<PlayerContoller>().HB.PowerHealthBarUp();
        machine.GetComponent<Machine>().round_started = true;

        //Achievement aids
        SetHPForSlow();
        PWH.AdvanceExperimentor();
        MC.GetComponent<RLController>().CheckForExperimentor();

        DisableAchievements();
        MC.GetComponent<RLController>().ActivateChosen();
        DisplayEmptyGearBark();

        //LoadoutBarks
        GiantScissorsFull();
        BackToBasics();
    }

    public void Deactivate()
    {
        GetComponent<SpriteRenderer>().sprite = inactive;
        machine.GetComponent<Test>().PlayAnimation("OpenMachine");
        GameObject.Find("ChoisePanel").GetComponent<PlayerContoller>().HB.PowerHealthBarDown();
        GameObject.Find("EnemyHolder").GetComponent<EnemyController>().HB.PowerHealthBarDown();
        GameObject.Find("EventSystem").GetComponent<MainController>().GiveUp();
        isActive = false;
        if(MC.GetComponent<StoryController>().playthroughts != 1) DisplayForfeitBark();
    }

    private void DisableAchievements()
    {
        GameObject[] achievements = GameObject.FindGameObjectsWithTag("Achievement");
        for (int i = 0; i < achievements.Length; i++)
        {
            achievements[i].GetComponent<RLReward>().DisableReward();
        }
    }

    public void EndRound()
    {
        GetComponent<SpriteRenderer>().sprite = inactive;
        machine.GetComponent<Test>().PlayAnimation("OpenMachine");
        GameObject.Find("ChoisePanel").GetComponent<PlayerContoller>().HB.PowerHealthBarDown();
        GameObject.Find("EnemyHolder").GetComponent<EnemyController>().HB.PowerHealthBarDown();
        GameObject.Find("PlayerWheelHolder").GetComponent<NonUIButton>().individual_interactable = true;
        isActive = false;
    }

    public void press() 
    { 
        if(!isActive)
        {
            CheckPlayerStatus();
        } else
        {
            Deactivate();
        }
    }

    public void CheckPlayerStatus()
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        bool dead = player.transform.GetChild(2).GetComponent<HealthBar>().CheckIfDead();
        if (dead)
        {
            MC.SetNewState(MainController.State.dead);
        } else
        {
            Activate();
        }
    }

    private int LastIndex()
    {
        int index = transform.childCount - 1;
        if (index < 0) index = 0;
        return index;
    }

    public void PlayAudio()
    {
        if (isActive) transform.GetChild(LastIndex()).GetChild(1).GetComponent<AudioPlayer>().PlayClip();
        else transform.GetChild(LastIndex()).GetChild(0).GetComponent<AudioPlayer>().PlayClip();
    }

    //Barking

    private void DisplayForfeitBark()
    {
        GameObject bark_holder = GameObject.Find("BarkHolder");
        int index = Random.Range(0, forfeit_barks.Length);
        string bark = forfeit_barks[index];

        bark_holder.GetComponent<BarkController>().ActivateInstantBark(bark);
    }

    private void DisplayEmptyGearBark()
    {
        List<Weapon> weapons = player.transform.GetChild(1).GetComponent<PlayerContoller>().GetWeapons();
        int weapon_slots = player.transform.GetChild(1).GetComponent<PlayerContoller>().WheelHolder.transform.GetChild(0).childCount - 1;
        bool giant_scissors_equipped = false;

        for(int i = 0; i < weapons.Count; i++)
        {
            if(weapons[i].name == "Giant scissors")
            {
                giant_scissors_equipped = true;
            }
        }

        if (weapons.Count < weapon_slots && !giant_scissors_equipped)
        {
            if (!empty_regard)
            {
                GameObject bark_holder = GameObject.Find("BarkHolder");
                int index = Random.Range(0, lacking_gear_barks.Length);
                string bark = lacking_gear_barks[index];

                bark_holder.GetComponent<BarkController>().ActivateInstantBark(bark);
                empty_regard = true;
            }
            else
            {
                emtpy_regard_counter--;
                if (emtpy_regard_counter <= 0)
                {
                    empty_regard = false;
                    emtpy_regard_counter = 3;
                }
            }
        }
    }

    private bool HasWeapon(string name)
    {
        List<Weapon> weapons = player.transform.GetChild(1).GetComponent<PlayerContoller>().GetWeapons();
        bool found = false;

        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].name == name)
            {
                found = true;
            }
        }
        return found;
    }

    private bool FullWheel()
    {
        int amount = player.transform.GetChild(1).GetComponent<PlayerContoller>().GetWeapons().Count;
        int weapon_slots = player.transform.GetChild(1).GetComponent<PlayerContoller>().WheelHolder.transform.GetChild(0).childCount - 1;
        return amount == weapon_slots;
    }

    private bool LoadoutCommentChance()
    {
        List<Weapon> weapons = player.transform.GetChild(1).GetComponent<PlayerContoller>().GetWeapons();
        bool new_loadout = false;

        //Check if new loadout
        if(previous_loadout.Count > 0)
        {
            for(int i = 0; i < weapons.Count; i++)
            {
                int counter = 0;
                for(int j = 0; j < previous_loadout.Count; j++)
                {
                    if(previous_loadout[j] == weapons[i].name)
                    {
                        break;
                    } else
                    {
                        counter++;
                    }
                }
                if (counter == previous_loadout.Count) new_loadout = true;
                if (new_loadout) break;
            }
        } else
        {
            //Add first loadout
            for(int i = 0; i < weapons.Count; i++)
            {
                previous_loadout.Add(weapons[i].name);
            }
        }

        //Add new previous loadout
        if(new_loadout)
        {
            previous_loadout.Clear();
            for (int i = 0; i < weapons.Count; i++)
            {
                previous_loadout.Add(weapons[i].name);
            }
            loadout_commented = false;
        }

        if(!loadout_commented)
        {
            int chance = Random.Range(1, 2); //1, 3
            if(chance == 1)
            {
                loadout_commented = true;
                return true;
            }
        }
        return false;
    }

    private string GiveRandomComment(string[] array)
    {
        return array[Random.Range(0, array.Length)];
    }

    //Loadout comment functions 
    private void GiantScissorsFull()
    {
        if (HasWeapon("Giant scissors") && FullWheel())
            if(LoadoutCommentChance())
                BC.ActivateInstantBark(GiveRandomComment(giant_scissors_full));
    }

    private void BackToBasics()
    {
        if (HasWeapon("Rock") && HasWeapon("Paper") && HasWeapon("Scissors") && previous_loadout.Count > 0)
            if(!previous_loadout.Contains("Rock") || !previous_loadout.Contains("Paper") || !previous_loadout.Contains("Scissors"))
                if (LoadoutCommentChance())
                    BC.ActivateInstantBark(GiveRandomComment(back_to_basics));
    }

    //Achievement aids

    private void SetHPForSlow()
    {
        GameObject.Find("EventSystem").GetComponent<RLController>().previous_health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.GiveCurrentHealth();
    }

}
