using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingWeapons : MonoBehaviour
{
    List<GameObject> all_weapons = new List<GameObject>();

    private void Awake()
    {
        all_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/sakset"));
        all_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/hyödytön"));
        all_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/paperi"));
        all_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/kivi"));
        all_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/voittamaton"));
    }

    public List<GameObject> GiveStartingWeapons()
    {
        List<GameObject> temp = new List<GameObject>();
        int index = GetComponent<MainController>().GetComponent<StoryCheckList>().greeting_index;

        if(index >= weapon_collections.Length)
        {
            index = weapon_collections.Length - 1;
        }
        string[] weapon_names = weapon_collections[index];

        if(weapon_names.Length > 0)
        {
            for (int i = 0; i < all_weapons.Count; i++)
            {
                for (int j = 0; j < weapon_names.Length; j++)
                {
                    if (all_weapons[i].GetComponent<Weapon>().name == weapon_names[j])
                    {
                        temp.Add(all_weapons[i]);
                        break;
                    }
                }
            }
        }
        return temp;
    }

    string[][] weapon_collections =
    {
        new string[] { "Scissors", "Paper", "Rock" },
        new string[] { "Scissors", "Cardboard", "Rock" },
        new string[] { "Sword", "Paper", "Rock" },

        //Story 1
        new string[] { "Crystal scissors", "Access code", "Brass Knuckles" },

        new string[] { "Adrenaline", "Voodoo doll", "Scissors" },
        new string[] { "Altar", "Shotgun", "Paper" },
        new string[] { "Scissors", "Rock", "Newspaper" },
        new string[] { "Adrenaline", "Voodoo doll", "Scissors" },
        new string[] { "Beer", "Bottle" },
        new string[] { "Gun", "Ammunition", "Bill" },

        //Story 2
        new string[] { "Blowtorch", "Throwing knife", "Smoke" },

        new string[] { "Double edged sword", "Bone", "Bandade" },
        new string[] { "Spike ball", "Pickaxe", "Thumb" },
        new string[] { "Drill", "Medicine", "Rot" },
        new string[] { "Middle finger" },
        new string[] { "Catapult", "Rock", "Rock", "Rock", "Rock" },

        //Story 3
        new string[] { "Flag", "Victory sign", "Rock" },

        new string[] { "Law Book", "Scissors", "Rock" },
        new string[] { "Paper", "Scissors", "Time bomb" },
        new string[] { "Manual", "Rock", "Scissors" },
        new string[] { "Four jokers", "Sithe" },
        new string[] { "Altar", "Mirror", "Holy text"},

        //Story 4
        new string[] { "Flag", "Cape", "Peace treaty" },

        new string[] { "Dynamo", "Hit list", "Scalpel" },
        new string[] { "Cursed scissors", "Prosthesis", "Sandpaper" },
        new string[] { "Gun", "Shotgun", "Granade" },
        new string[] { "Blood blade", "Victory sign", "Bandages" },
    };
}
