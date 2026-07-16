using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Rules : MonoBehaviour
{
	public GameObject rulesheet;
	public GameObject rulesheet_table;
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

}
