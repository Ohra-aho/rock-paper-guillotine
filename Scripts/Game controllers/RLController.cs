using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLController : MonoBehaviour
{
    public List<string> achievements = new List<string>();
    public int picks = 1;

    GameObject background;

    public List<GameObject> chosen_buffs = new List<GameObject>();


    private void Start()
    {
        RL data = SaveSystem.LoadAchievements();
        if(data != null)
        {
            achievements.AddRange(data.achievements);
            picks = data.picks;
        }

        background = GameObject.Find("main screen background");

        ActivateAchievements();
    }

    //Lis‰‰ t‰h‰n jokin miehen kommentti, kun on ekan kerran
    public void ActivateAchievements()
    {
        for(int i = 0; i < achievements.Count; i++)
        {
            switch(achievements[i])
            {
                case "HP_master":
                    background.transform.GetChild(0).gameObject.SetActive(true);
                    break;
            }
        }
    }

    private void GainRandomWeapon()
    {
        GameObject[] tier_1_weapons = Resources.LoadAll<GameObject>("weapons/Start reward");
        int index = Random.Range(0, tier_1_weapons.Length);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().items.Add(tier_1_weapons[index]);
    }

    public void SaveAchievements()
    {
        SaveSystem.SaveAchievements(new RL(achievements.ToArray(), picks));
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
