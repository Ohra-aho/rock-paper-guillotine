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
        new string[] { "Beer", "Bottle", "Paper" },
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
        new string[] { "Deck", "Singularity", "Sidearm" },

        //Story 6
        new string[] { "Newspaper", "Flamethrower", "Victory streak" },

        new string[] { "Adrenaline", "Sidearm", "Smoke" },
        new string[] { "Teeth", "Mallet", "Hat" },
        new string[] { "Airbag", "Rock", "Throwing knife" },
        new string[] { "Scissors", "Paper", "Mountain" },

        //Story 7
        new string[] { "Gun", "Archnode", "Wallet", "Wallet" },

        new string[] { "Rock", "Paper", "Scissors" },
        new string[] { "Recycler", "Rock", "Bladestorm", "Paper" },
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
        new string[] { "Law Book", "Medical supplies", "Ruin" },

        //Story 11
        new string[] { "Archnode", "Recipe", "Battery" },

        new string[] { "Flesh render", "Wall", "Origami" },
        new string[] { "Pencil", "Whetstone", "Sandpaper" },
        new string[] { "Deck", "Teeth", "Monument" },

        //Story 12
        new string[] { "Beer", "Chip", "Buckshot" },

        new string[] { "Meteor swarm", "Meteor swarm", "Meteor swarm", "Meteor swarm", "Meteor swarm" },
        new string[] { "Barricade", "Bubble" },
        new string[] { "Ender", "Middle finger", "Painkiller" },
        new string[] { "Time bomb", "Joker", "Rage" },
        new string[] { "Barricade", "Sidearm", "Rage" },

        //Story 13
        new string[] { "Lava", "Paper armor", "Crystal Scissors" },
        new string[] { "Rock", "Paper", "Scissors" },
        new string[] { "Rock", "Paper", "Scissors" },
        new string[] { "Rock", "Paper", "Scissors" },
        new string[] { "Rock", "Paper", "Scissors" },
        new string[] { "Rock", "Paper", "Scissors" },
        new string[] { "Rock", "Paper", "Scissors" },
        new string[] { "Rock", "Paper", "Scissors" },
        new string[] { "Nothing" },
        //Kill
        new string[] { "Nothing" },
        new string[] { "Nothing" },
        new string[] { "Nothing" },
        new string[] { "Nothing" },
        new string[] { "Nothing" },
        new string[] { "Nothing" },
        new string[] { "Nothing" },
        //Continue
        new string[] { "Rock", "Paper", "Scissors" },
        new string[] { "Barricade", "Bunker", "Reality Smasher" },

        new string[] { "Singularity", "Star", "Double edged sword" },
        new string[] { "Mountain", "Mountain", "Mountain" },
        new string[] { "Rot", "Avalance", "Paper cutter" },
        new string[] { "Medicine", "Medicine", "Medicine", "Hook" },

        //Story 14
        new string[] { "Law Book", "Law Book", "Blood blade", "Victory streak" },

        new string[] { "Fireball", "Reinforced glass", "Glacial erratic" },
        new string[] { "Die", "Cape", "Shredder" },
        new string[] { "Needle", "Paper", "Scissors" },

        //Story 15
        new string[] { "Ender", "Handkerchief", "Drill" },

        new string[] { "Lava", "Bunker", "Bubble" },
        new string[] { "Battery", "Lightning", "Wire" },
        new string[] { "Bone", "Paper plane", "Gaint scissors" },

        //Story 16
        new string[] { "Thumb", "Middle finger", "Victory sign" },
        new string[] { "Diamond", "Sithe", "Sponge" },
        new string[] { "Airbag", "Scalpel", "Time bomb" },

        new string[] { "Pact" },

        new string[] { "Rock", "Paper", "Guillotine" },


    };
}
