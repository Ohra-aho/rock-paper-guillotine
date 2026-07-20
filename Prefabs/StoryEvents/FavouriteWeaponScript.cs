using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavouriteWeaponScript : MonoBehaviour
{
	public List<Sprite> backgrounds;
	public List<Sprite> icons;
	public Weapon weapon;
	public GameObject UI;
	public GameObject favourite;
	public GameObject favourite_2;
	
	MainController MC;

	void Awake()
	{
		if(GetComponent<StoryEvent>())
		{
			MC = GameObject.Find("EventSystem").GetComponent<MainController>();
			MC.SetNewState(MainController.State.favourite_pick);
			GameObject.Find("Canvas").transform.GetChild(17).gameObject.SetActive(true);
			GameObject.Find("cellar scene").transform.GetChild(5).gameObject.SetActive(true);
			GameObject.Find("PlayerWheelHolder").GetComponent<NonUIButton>().press.Invoke();
			MC.GetComponent<RLController>().achievements.Add("Winner");
		}
	}

	

	public void DisplayFavouriteWeapon(Weapon w)
	{
		transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = w.sprite;
		transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = w.sprite;
		GetComponent<SpriteRenderer>().sprite = backgrounds[w.tier];
		switch(w.type)
		{
			case MainController.Choise.kivi: transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = icons[0]; break;
			case MainController.Choise.paperi: transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = icons[1]; break;
			case MainController.Choise.sakset: transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = icons[2]; break;
			case MainController.Choise.useless: transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = icons[3]; break;
			case MainController.Choise.voittamaton: transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = icons[4]; break;
		}
		weapon = w;
	}

	public void Confirm()
	{
		if(weapon != null)
		{
			GameObject.Find("PlayerWheelHolder").GetComponent<NonUIButton>().press.Invoke();

			favourite_2.SetActive(true);
			favourite_2.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon.sprite;
			favourite_2.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon.sprite;
			favourite_2.GetComponent<SpriteRenderer>().sprite = backgrounds[weapon.tier];
			favourite_2.GetComponent<FavouriteWeaponScript>().weapon = weapon;
			weapon.tier++;
			if(weapon.tier > 2) weapon.tier = 2;
			switch(weapon.type)
			{
				case MainController.Choise.kivi: favourite_2.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = icons[0]; break;
				case MainController.Choise.paperi: favourite_2.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = icons[1]; break;
				case MainController.Choise.sakset: favourite_2.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = icons[2]; break;
				case MainController.Choise.useless: favourite_2.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = icons[3]; break;
				case MainController.Choise.voittamaton: favourite_2.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = icons[4]; break;
			}

			UI.SetActive(false);
			favourite.SetActive(false);
			GameObject.Find("StartButton").GetComponent<StartButton>().end = true;
			GameObject.Find("Favourite weapon(Clone)").GetComponent<StoryEvent>().over = true;
		}
	}

	public void Refuse()
	{
		GameObject.Find("PlayerWheelHolder").GetComponent<NonUIButton>().press.Invoke();

		UI.SetActive(false);
		favourite.SetActive(false);
		favourite_2.SetActive(true);

		GameObject.Find("Favourite weapon(Clone)").GetComponent<StoryEvent>().over = true;
		GameObject.Find("StartButton").GetComponent<StartButton>().end = true;
	}

}
