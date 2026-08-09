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

	void Awake()
	{
		MC = GameObject.Find("EventSystem").GetComponent<MainController>();
	}

	private void Update() {
		if(MC.game_state == MainController.State.in_battle)
		{
			if(!weakness && !bleed)
			{
				int x = GetPoisons();
				if(x > 0)
				{
					if(GetComponent<Image>().color.a != 1)
					{
						GetComponent<Image>().color = new Color(1,1,1,1);
						transform.GetChild(2).GetComponent<TextMeshProUGUI>().color = new Color(0.5f,0.5f,0.5f,1);
					}
					transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Poison: "+x.ToString();
					transform.GetChild(1).gameObject.SetActive(true);
					transform.GetChild(0).gameObject.SetActive(false);
				} else
				{
					if(GetComponent<Image>().color.a != 0)
					{
						GetComponent<Image>().color = new Color(1,1,1,0);
						transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Poison: "+0;
						transform.GetChild(2).GetComponent<TextMeshProUGUI>().color = new Color(0,0,0,0);
						transform.GetChild(1).gameObject.SetActive(false);
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
						GetComponent<Image>().color = new Color(1,1,1,1);
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(0.5f,0.5f,0.5f,1);
					}
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Weakness: "+x.ToString();
					transform.GetChild(0).gameObject.SetActive(true);
				} else
				{
					if(GetComponent<Image>().color.a != 0)
					{
						GetComponent<Image>().color = new Color(1,1,1,0);
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Weakness: "+0;
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(0,0,0,0);	
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
						GetComponent<Image>().color = new Color(1,1,1,1);
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(0.5f,0.5f,0.5f,1);
						transform.GetChild(0).gameObject.SetActive(true);
					}
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Bleed: "+x.ToString();
				} else
				{
					if(GetComponent<Image>().color.a != 0)
					{
						GetComponent<Image>().color = new Color(1,1,1,0);
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Bleed: "+0;
						transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(0,0,0,0);	
						transform.GetChild(0).gameObject.SetActive(false);
					}
				}
			}
		}
		else if(MC.game_state == MainController.State.re_arming || MC.game_state == MainController.State.reward)
		{
			if(!weakness && !bleed)
			{
				HealthBar HB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
				if(GetComponent<Image>().color.a != 1)
				{
					GetComponent<Image>().color = new Color(1,1,1,1);
					transform.GetChild(2).GetComponent<TextMeshProUGUI>().color = new Color(0.5f,0.5f,0.5f,1);
					transform.GetChild(0).gameObject.SetActive(true);
					transform.GetChild(1).gameObject.SetActive(false);
				}
				int current = HB.GiveCurrentHealth();
				int max = HB.GiveMaxHealth();
				if(max > HB.HP_gap) max = HB.HP_gap;
				transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Health: "+current+"/"+max;	

			} else
			{
				if(GetComponent<Image>().color.a != 0)
				{
					GetComponent<Image>().color = new Color(1,1,1,0);
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(0.5f,0.5f,0.5f,1);
					transform.GetChild(0).gameObject.SetActive(false);
				}
			}
		} else
		{
			if(!weakness && !bleed)
			{
				if(GetComponent<Image>().color.a != 0)
				{
					GetComponent<Image>().color = new Color(1,1,1,0);
					transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
					transform.GetChild(2).GetComponent<TextMeshProUGUI>().color = new Color(0.5f,0.5f,0.5f,1);
					transform.GetChild(0).gameObject.SetActive(false);
					transform.GetChild(1).gameObject.SetActive(false);
				}
			} else
			{
				if(GetComponent<Image>().color.a != 0)
				{
					GetComponent<Image>().color = new Color(1,1,1,0);
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
					transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(0.5f,0.5f,0.5f,1);
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
