using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    private void Awake()
    {
        //LoadPlayerWeapons();
    }

    public void SavePlayerWeapons()
    {
        int amount = transform.childCount;
        WeaponData[] weapons = new WeaponData[amount];

        for (int i = 0; i < amount; i++)
        {
            Weapon weapon = transform.GetChild(i).GetComponent<Weapon>();
            weapons[i] = new WeaponData(weapon);
        }

        MainController MC = GameObject.Find("EventSystem").GetComponent<MainController>();

        SaveSystem.SavePlayerWeapons(weapons, MC.dead);
    }

    public void LoadPlayerWeapons()
    {
        WeaponData[] weapons = SaveSystem.LoadPlayerWeapons();

        if(weapons != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().items.Clear();
            for(int i = 0; i < weapons.Length; i++)
            {
                string weapon_path = "weapons/"+weapons[i].type+"/"+weapons[i].name; // needs soem sort of ID system. Names are too fluid for this

                GameObject loaded_weapon = Resources.Load<GameObject>(weapon_path);
                if (loaded_weapon != null) Instantiate(loaded_weapon, transform);
                else Debug.Log(weapons[i].name+" not found");
            }
        }
    }
}
