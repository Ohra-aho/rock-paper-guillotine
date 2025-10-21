using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLController : MonoBehaviour
{
    public List<string> achievements = new List<string>();


    private void Start()
    {
        /*string[] data = SaveSystem.LoadAchievements();
        if(data != null)
        {
            achievements.AddRange(data);
        }*/
        //ActivateAchievements();
    }

    //Lis‰‰ t‰h‰n jokin miehen kommentti, kun on ekan kerran
    public void ActivateAchievements()
    {
        for(int i = 0; i < achievements.Count; i++)
        {
            switch(achievements[i])
            {
                case "decontaminated":
                    GainRandomWeapon();
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
        SaveSystem.SaveAchievements(achievements.ToArray());
    }
}
