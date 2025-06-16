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
                if (loaded_weapon != null) 
                { 
                    GameObject weapon = Instantiate(loaded_weapon, transform);

                    if (weapon.GetComponent<Stacking>()) { 
                        weapon.GetComponent<Stacking>().stacks = weapons[i].stacks;
                        if(weapon.GetComponent<Stacking>().LoadFunction != null)
                        {
                            weapon.GetComponent<Stacking>().LoadFunction.Invoke();
                        }
                    }
                    weapon.GetComponent<Weapon>().buff_data = ExtractRelevantBuffs(weapons[i].buffs);
                    if(weapon.GetComponent<SelfDestruct>())
                    {
                        weapon.GetComponent<SelfDestruct>().used_ones = weapons[i].self_destruct_used;
                    }

                }
                else Debug.Log(weapons[i].name + " not found");
            }
        }
    }

    private BuffData[] ExtractRelevantBuffs(BuffData[] buff_data)
    {
        List<BuffData> temp = new List<BuffData>();

        for(int i = 0; i < buff_data.Length; i++)
        {
            if(buff_data[i] != null)
            {
                temp.Add(buff_data[i]);
            }
        }

        return temp.ToArray();
    }
}
