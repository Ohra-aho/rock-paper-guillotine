using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingWeapons : MonoBehaviour
{
    List<GameObject> all_weapons = new List<GameObject>();

    private void Awake()
    {
        all_weapons.AddRange(Resources.LoadAll<GameObject>("weapons/hyödytön"));
    }
       
    public List<GameObject> GiveStartingWeapons()
    {
        List<GameObject> temp = new List<GameObject>();
        int index = GetComponent<MainController>().GetComponent<StoryCheckList>().greeting_index;
        Debug.Log(index);
        if(index >= weapon_collections.Length)
        {
            index = weapon_collections.Length - 1;
        }
        string[] weapon_names = weapon_collections[index];

        for(int i = 0; i < all_weapons.Count; i++)
        {
            for(int j = 0; j < weapon_names.Length; j++)
            {
                if(all_weapons[i].GetComponent<Weapon>().name == weapon_names[j])
                {
                    temp.Add(all_weapons[i]);
                    break;
                }
            }
        }
        return temp;
    }

    string[][] weapon_collections =
    {
        new string[] { "Anvil" },
        new string[] { "Ritual stone" },
        new string[] { "Tombstone" },
    };
}
