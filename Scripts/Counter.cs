using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
	MainController MC;

	void Awake()
	{
		MC = GameObject.Find("EventSystem").GetComponent<MainController>();
	}

	private void Update() {
		if(MC.game_state == MainController.State.in_battle)
		{
			int x = GetPoisons();
			if(x > 0)
			{
				if(GetComponent<Image>().color.a != 1)
				{
					GetComponent<Image>().color = new Color(1,1,1,1);
					transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.5f,0.5f,0.5f,1);
				}
				transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Poison: "+x.ToString();
			} else
			{
				if(GetComponent<Image>().color.a != 0)
				{
					GetComponent<Image>().color = new Color(1,1,1,0);
					transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Poison: "+0;
					transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0,0,0,0);	
				}
			}
		}
		else if(MC.game_state == MainController.State.re_arming || MC.game_state == MainController.State.reward)
		{
			HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
			if(GetComponent<Image>().color.a != 1)
			{
				GetComponent<Image>().color = new Color(1,1,1,1);
				transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.5f,0.5f,0.5f,1);
			}
			int current = HB.GiveCurrentHealth();
			int max = HB.GiveMaxHealth();
			transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Health: "+current+"/"+max;
		} else
		{
			if(GetComponent<Image>().color.a != 0)
			{
				GetComponent<Image>().color = new Color(1,1,1,0);
				transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
				transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.5f,0.5f,0.5f,1);	
			}
		}
	}

	private int GetPoisons()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		int amount = 0;
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			if(RI.transform.GetChild(i).GetComponent<Weapon>().name == "Poison")
			{
				amount++;
			}
		}
		return amount;
	}
}
