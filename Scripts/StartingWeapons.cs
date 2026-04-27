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
                        //break;
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
        new string[] { "Scissors", "Hat", "Wall" },

        //Story 1
        new string[] { "Crystal Scissors", "Access code", "Brass Knuckles" },

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
        new string[] { "Catapult", "Rock", "Rock", "Rock", "Rock", "Rock", "Rock"},

        //Story 3
        new string[] { "Flag", "Victory sign", "Rock" },

        new string[] { "Law Book", "Scissors", "Rock" },
        new string[] { "Paper", "Scissors", "Time Bomb" },
        new string[] { "Manual", "Rock", "Scissors" },
        new string[] { "4 Jokers", "Sithe" },
        new string[] { "Altar", "Mirror", "Holy text"},

        //Story 4
        new string[] { "Flag", "Cape", "Peace treaty" },

        new string[] { "Dynamo", "Hit list", "Scalpel" },
        new string[] { "Cursed scissors", "Prosthesis", "Sandpaper" },
        new string[] { "Gun", "Shotgun", "Granade" },
        new string[] { "Blood blade", "Victory sign", "Bandages" },
        new string[] { "Silver", "Cardboard", "Scalpel" },

        //Story 5
        new string[] { "Scissors", "Paper", "Star" },

        new string[] { "Sithe", "Paper armor", "Beer" },
        new string[] { "Crystal scissors", "Paper armor", "Ice cube" },
        new string[] { "Scissors", "Paper", "Rock" },
        new string[] { "Chip", "Deck", "Die" },
        new string[] { "Deck", "Singularity" },

        //Story 6
        new string[] { "Newspaper", "Flamethrower", "Victory streak" },

        new string[] { "Adrenaline", "Sidearm", "Smoke" },
        new string[] { "Teeth", "Mallet", "Hat" },
        new string[] { "Airbag", "Rock", "Throwing knife" },
        new string[] { "Scissors", "Paper", "Mountain" },

        //Story 7
        new string[] { "Gun", "Wallet", "Wallet", "Wallet" },

        new string[] { "Rock", "Paper", "Scissors" },
        new string[] { "Recycler", "Rock", "Bladestorm" },
        new string[] { "Pickaxe", "Smoke", "Medipack" },
        new string[] { "Middle finger", "Hit list", "Handkerchief" },

        //Story 8
        new string[] { "Arm band", "Brass Knuckles", "Pencil" },

        new string[] { "Wall", "Ice cube" },
        new string[] { "Access code", "Knife belt" },
        new string[] { "Diamond", "Paper", "Scissors" },
        new string[] { "Boulder", "Shield", "Sword" },
        new string[] { "Guillotine", "Whetstone" },

        //Story 9
        new string[] { "Medical supplies", "Smoke", "Ruin" },

        new string[] { "Beer", "Granade", "Disinfectant" },
        new string[] { "Smoke", "Cape", "Monument" },
        new string[] { "Bubble", "Defence manifest" },

        //Story 10
        new string[] { "Bone", "Teeth", "Prosthesis" },

        new string[] { "Recycler", "Paper", "Rock" },
        new string[] { "Chainsaw", "Paper", "Rock" }, /// Tee chainsaw
        new string[] { "Teeth", "Reinforced glass", "Barricade" },


    };
}
