using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavouriteMenu : MonoBehaviour
{
	public List<Sprite> backgrounds;
	public List<Sprite> icons;
	public GameObject pick;
	public List<GameObject> favourites;
	private int pick_count = 2;

	void Awake()
	{
		LoadFavourites();
		DisplayFavourites();
	}

	public void LoadFavourites()
	{
		StartingWeapons SW = GameObject.Find("EventSystem").GetComponent<StartingWeapons>();
		for(int i = 0; i < SW.all_weapons.Count; i++)
		{
			if(SW.all_weapons[i].GetComponent<Weapon>().tier > 0)
			{
				favourites.Add(SW.all_weapons[i]);
			}
		}
	}

	public void DisplayFavourites()
	{
		for(int i = 0; i < favourites.Count; i++)
		{
			GameObject FW = Instantiate(pick, transform);
			FW.GetComponent<FWeapon>().weapon = favourites[i];
			FW.GetComponent<FWeapon>().DispalyWeapon();
		}
	}

	public void WeaponPicked()
	{
		pick_count--;
		if(pick_count <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
