using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class WeaponWard : MonoBehaviour
{
	public List<Sprite> icons;
	[HideInInspector] public bool telegraphing = false;
	[HideInInspector] public Weapon weapon;

	public GameObject image_1;
	public GameObject image_2;
	public GameObject icon;
	public GameObject title;
	public GameObject point_stats;
	public GameObject point_damage;
	public GameObject point_armor;
	public GameObject points;
	public GameObject stats;
	public GameObject damage;
	public GameObject armor;
	public GameObject description;

	MainController MC;

	void Awake()
	{
		MC = GameObject.Find("EventSystem").GetComponent<MainController>();
	}

	public void RevealInfo()
	{
		if(weapon != null && MC.game_state == MainController.State.in_battle)
		{
			if(!telegraphing) GetComponent<Test>().PlayAnimation("CardInfoReveal");
			else GetComponent<Test>().PlayAnimation("InfoReveal");
		}
	}
	public void HideInfo()
	{
		if(weapon != null)
		{
			if(!telegraphing) GetComponent<Test>().PlayAnimation("CardInfoHide");
			else GetComponent<Test>().PlayAnimation("InfoHide");
		}
	}

	public void Telegraph()
	{
		if(weapon != null && MC.game_state == MainController.State.in_battle && !telegraphing)
		{
			GetComponent<Test>().PlayAnimation("Telegraph");
			telegraphing = true;
		}
	}

	public void ResetTelegraph()
	{
		if(weapon != null && telegraphing)
		{
			GetComponent<Test>().PlayAnimation("Reset telegraph");
			telegraphing = false;
		}
	}

	public void DisplayWeapon()
	{
		image_1.GetComponent<SpriteRenderer>().sprite = weapon.sprite;
		image_2.GetComponent<SpriteRenderer>().sprite = weapon.sprite;
		switch(weapon.type)
		{
			case MainController.Choise.kivi:
				icon.GetComponent<SpriteRenderer>().sprite = icons[0];
				break;
			case MainController.Choise.paperi:
				icon.GetComponent<SpriteRenderer>().sprite = icons[1];
				break;
			case MainController.Choise.sakset:
				icon.GetComponent<SpriteRenderer>().sprite = icons[2];
				break;
			case MainController.Choise.useless:
				icon.GetComponent<SpriteRenderer>().sprite = icons[3];
				break;
			case MainController.Choise.voittamaton:
				icon.GetComponent<SpriteRenderer>().sprite = icons[4];
				break;
		}

		title.GetComponent<TextMeshPro>().text = weapon.name;
		if(weapon.GetComponent<Stacking>())
		{
			point_stats.gameObject.SetActive(true);
			stats.gameObject.SetActive(false);

			point_damage.GetComponent<TextMeshPro>().text = weapon.GiveEffectiveDamage().ToString();
			point_armor.GetComponent<TextMeshPro>().text = weapon.GiveEffectiveArmor().ToString();
			points.GetComponent<TextMeshPro>().text = weapon.GetComponent<Stacking>().stacks.ToString();
		} else
		{
			point_stats.gameObject.SetActive(false);
			stats.gameObject.SetActive(true);

			damage.GetComponent<TextMeshPro>().text = weapon.GiveEffectiveDamage().ToString();
			armor.GetComponent<TextMeshPro>().text = weapon.GiveEffectiveArmor().ToString();
		}
		description.GetComponent<TextMeshPro>().text = weapon.description;
	}

	public void ClearWeapon()
	{
		image_1.GetComponent<SpriteRenderer>().sprite = null;
		image_2.GetComponent<SpriteRenderer>().sprite = null;

		icon.GetComponent<SpriteRenderer>().sprite = null;

		title.GetComponent<TextMeshPro>().text = "";
		
		point_stats.gameObject.SetActive(true);
		stats.gameObject.SetActive(true);

		point_damage.GetComponent<TextMeshPro>().text = "";
		point_armor.GetComponent<TextMeshPro>().text = "";
		points.GetComponent<TextMeshPro>().text = "";
		
		damage.GetComponent<TextMeshPro>().text = "";
		armor.GetComponent<TextMeshPro>().text = "";
		description.GetComponent<TextMeshPro>().text = "";
	}
}
