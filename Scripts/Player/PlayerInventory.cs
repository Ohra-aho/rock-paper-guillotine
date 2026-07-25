using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<GameObject> all = new List<GameObject>();

    public bool all_weapons = false;

	public WeaponData[][] loaded_weapons;

	void Awake()
	{
		//LoadWeapons();
	}

	public void AddAllWeapons()
    {
        if (all_weapons)
        {
            GameObject[] temp = Resources.LoadAll<GameObject>("weapons/Kivi");
            GameObject[] temp1 = Resources.LoadAll<GameObject>("weapons/paperi");
            GameObject[] temp2 = Resources.LoadAll<GameObject>("weapons/sakset");

            items.AddRange(temp);
            items.AddRange(temp1);
            items.AddRange(temp2);
        }
    }

    public void AddItem(GameObject newItem)
    {
        GameObject the_item = Instantiate(newItem, GetComponent<PlayerContoller>().TrueInventory.transform);
		
		if(the_item.transform.childCount > 0)
		{
			for(int i = the_item.transform.childCount-1; i >= 0; i--)
			{
				DestroyImmediate(the_item.transform.GetChild(i).gameObject);
			}	
		}

        the_item.GetComponent<Weapon>().player = true;
        if(the_item.GetComponent<BuffController>())
        {
            the_item.GetComponent<BuffController>().Inisiate();
        }
        the_item.GetComponent<Weapon>().on_pick.Invoke();
        the_item.GetComponent<Weapon>().InisiateTypeEffects();
        items.Add(the_item);
        
        AddBuffToNewWeapon();
        GameObject event_system = GameObject.Find("EventSystem");
        event_system.GetComponent<RLController>().CheckCollector();
        event_system.GetComponent<RLController>().CheckForNeurotic();
        event_system.GetComponent<RLController>().CheckForPicky();
        event_system.GetComponent<RLController>().ApplyBuffs();

        if(GameObject.FindGameObjectWithTag("Inventory") != null)
        {
            InventoryMenu IM = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryMenu>();
            IM.ReconstructInventory();
        }
    }

    public void ClearInventory()
    {
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		if(RI.transform.childCount > 0)
		{
			for(int i = RI.transform.childCount-1; i >= 0; i--)
			{
				Destroy(RI.transform.GetChild(i).gameObject);
			}	
		}
        items.Clear();
    }

    public void AddBuffToNewWeapon()
    {
        List<Weapon> equipped_weapons = GetComponent<PlayerContoller>().GetWeapons();
        for(int i = 0; i < equipped_weapons.Count; i++)
        {
            if(equipped_weapons[i].player)
            {
                if (equipped_weapons[i].GetComponent<BuffController>())
                {
                    if(!equipped_weapons[i].GetComponent<BuffController>().special_apply)
                    {
                        equipped_weapons[i].GetComponent<BuffController>().Equip();
                    }
                }

                if (equipped_weapons[i].GetComponent<Laava>())
                {
                    equipped_weapons[i].GetComponent<Laava>().Equip();
                }
            }
        }
    }


	//Save functions
	public void SaveWeapons()
	{
		List<WeaponData> weapons = new List<WeaponData>();
		List<WeaponData> equipped_weapons = new List<WeaponData>();
		for(int i = 0; i < items.Count; i++)
		{
			weapons.Add(new WeaponData(items[i].GetComponent<Weapon>()));
		}
		List<Weapon> temp = GetComponent<PlayerContoller>().GetWeapons();
		for(int i = 0; i < temp.Count; i++)
		{
			equipped_weapons.Add(new WeaponData(temp[i]));
		}
		WeaponData[][] weapons_to_save = new WeaponData[2][];
		weapons_to_save[0] = weapons.ToArray();
		weapons_to_save[1] = equipped_weapons.ToArray();
		
		SaveSystem.SavePlayerWeapons(weapons_to_save);
	}

	public void LoadWeapons()
	{
		loaded_weapons = SaveSystem.LoadPlayerWeapons();
		if(loaded_weapons != null)
		{
			items.Clear();
			for(int i = 0; i < loaded_weapons[0].Length; i++)
			{
				string folder = "";
				switch(loaded_weapons[0][i].type)
				{
					case "kivi": folder += "Kivi"; break;
					case "paperi": folder += "paperi"; break;
					case "sakset": folder += "sakset"; break;
					case "useless": folder += "hyödytön"; break;
					case "voittamaton": folder += "voittamaton"; break;
				}
				switch(loaded_weapons[0][i].name)
				{
					case "Bleed": folder += "/Debuffs"; break;
					case "Dept": folder += "/Debuffs"; break;
					case "Poison": folder += "/Debuffs"; break;
					case "Authority": folder += "/eldritch power"; break;
					case "immortality": folder += "/eldritch power"; break;
					case "Strength": folder += "/eldritch power"; break;
					case "Mercy": folder += "/miracle"; break;
					case "Sanctuary": folder += "/miracle"; break;
					case "Smite": folder += "/miracle"; break;
				}
				folder += "/"+loaded_weapons[0][i].name;
				GameObject weapon = Resources.Load<GameObject>("weapons/"+folder);
				if(weapon != null)
				{
					items.Add(weapon);
				} else
				{
					Debug.Log(loaded_weapons[0][i].name + " not found in: "+ folder);
				}
			}

			for(int i = 0; i < loaded_weapons[1].Length; i++)
			{
				string folder = "";
				switch(loaded_weapons[1][i].type)
				{
					case "kivi": folder += "Kivi"; break;
					case "paperi": folder += "paperi"; break;
					case "sakset": folder += "sakset"; break;
					case "useless": folder += "hyödytön"; break;
					case "voittamaton": folder += "voittamaton"; break;
				}
				switch(loaded_weapons[1][i].name)
				{
					case "Bleed": folder += "/Debuffs"; break;
					case "Dept": folder += "/Debuffs"; break;
					case "Poison": folder += "/Debuffs"; break;
					case "Authority": folder += "/eldritch power"; break;
					case "Immortality": folder += "/eldritch power"; break;
					case "Strength": folder += "/eldritch power"; break;
					case "Mercy": folder += "/miracle"; break;
					case "Sanctuary": folder += "/miracle"; break;
					case "Smite": folder += "/miracle"; break;
				}
				folder += "/"+loaded_weapons[1][i].name;
				GameObject weapon = Resources.Load<GameObject>("weapons/"+folder);
				if(weapon != null)
				{
					GetComponent<PlayerContoller>().weapons.Add(weapon);
				} else
				{
					Debug.Log(loaded_weapons[1][i].name + " not found in: "+ folder);
				}
			}
		}
	}
}
