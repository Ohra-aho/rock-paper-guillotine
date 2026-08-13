using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Rules : MonoBehaviour
{
	public GameObject rulesheet;
	public GameObject rulesheet_table;

	public GameObject weapon_box;
	public GameObject box_holder;
	public GameObject inventory_button;

    bool revealed = false;

	public void TablePress()
	{
		rulesheet.SetActive(true);
		GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
		gameObject.SetActive(false);
	}

	public void SheetPress()
	{
		rulesheet_table.SetActive(true);
		GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
		gameObject.SetActive(false);
	}


	public void FolderPress()
	{
		MainController MC = GameObject.Find("EventSystem").GetComponent<MainController>();
		GameObject new_weapon_box = Instantiate(weapon_box, box_holder.transform);
		new_weapon_box.GetComponent<AllWeaponBox>().Inisiate();

		if(GameObject.FindGameObjectWithTag("Inventory") == null) inventory_button.GetComponent<InventoryButton>().Press();
		
	}

}
