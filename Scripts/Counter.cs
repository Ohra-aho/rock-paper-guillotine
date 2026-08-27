using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
	MainController MC;
	public bool weakness;
	public bool bleed;
	public bool poison;

	Color text_color = new Color(0f,0f,0f,1);
	Color background_color = new Color(1,1,1,0.3f);
	Color transparent = new Color(1,1,1,0);

	void Awake()
	{
		MC = GameObject.Find("EventSystem").GetComponent<MainController>();
	}

	private void Update() {
		if(MC.game_state == MainController.State.in_battle)
		{
			if(poison)
			{
				int x = GetPoisons();
				if(x > 0)
				{
					if(GetComponent<Image>().color.a != 1)
					{
						GetComponent<Image>().color = background_color;
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = text_color;
					}
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = x.ToString();
					transform.GetChild(0).gameObject.SetActive(true);
				} else
				{
					if(GetComponent<Image>().color.a != 0)
					{
						GetComponent<Image>().color = transparent;
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = 0.ToString();
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = transparent;
						transform.GetChild(0).gameObject.SetActive(false);	
					}
				}	
			} else if(weakness)
			{
				int x = GetWeakness();
				if(x > 0)
				{
					if(GetComponent<Image>().color.a != 1)
					{
						GetComponent<Image>().color = background_color;
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = text_color;
					}
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = x.ToString();
					transform.GetChild(0).gameObject.SetActive(true);
				} else
				{
					if(GetComponent<Image>().color.a != 0)
					{
						GetComponent<Image>().color = transparent;
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = 0.ToString();
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = transparent;	
						transform.GetChild(0).gameObject.SetActive(false);
					}
				}	
			} else if(bleed)
			{
				int x = GetBleed();
				if(x > 0)
				{
					if(GetComponent<Image>().color.a != 1)
					{
						GetComponent<Image>().color = background_color;
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = text_color;
						transform.GetChild(0).gameObject.SetActive(true);
					}
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = x.ToString();
				} else
				{
					if(GetComponent<Image>().color.a != 0)
					{
						GetComponent<Image>().color = transparent;
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = 0.ToString();
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = transparent;	
						transform.GetChild(0).gameObject.SetActive(false);
					}
				}
			}
		}
		else if(MC.game_state == MainController.State.re_arming || MC.game_state == MainController.State.reward)
		{
			if(!weakness && !bleed && !poison)
			{
				HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
				if(GetComponent<Image>().color.a != 1)
				{
					GetComponent<Image>().color = background_color;
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = text_color;
					transform.GetChild(0).gameObject.SetActive(true);
				}
				int current = HB.GiveCurrentHealth();
				int max = HB.GiveMaxHealth();
				transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = current+"/"+max;	

			} else
			{
				if(GetComponent<Image>().color.a != 0)
				{
					GetComponent<Image>().color = transparent;
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = text_color;
					transform.GetChild(0).gameObject.SetActive(false);
				}
			}
		} else
		{
			if(!weakness && !bleed && !poison)
			{
				if(GetComponent<Image>().color.a != 0)
				{
					GetComponent<Image>().color = transparent;
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = text_color;
					transform.GetChild(0).gameObject.SetActive(false);
				}
			} else
			{
				if(GetComponent<Image>().color.a != 0)
				{
					GetComponent<Image>().color = transparent;
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = text_color;
					transform.GetChild(0).gameObject.SetActive(false);
				}
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
	private int GetWeakness()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		int amount = 0;
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			if(RI.transform.GetChild(i).GetComponent<Weapon>().name == "Weakness")
			{
				amount++;
			}
		}
		return amount;
	}
	private int GetBleed()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		int amount = 0;
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			if(RI.transform.GetChild(i).GetComponent<Weapon>().name == "Bleed")
			{
				amount++;
			}
		}
		return amount;
	}
}
