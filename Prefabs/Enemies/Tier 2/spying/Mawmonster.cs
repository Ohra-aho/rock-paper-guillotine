using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mawmonster : MonoBehaviour
{
	public GameObject buff;
    public void TapIn()
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
		Weapon choise = GameObject.Find("EventSystem").GetComponent<MainController>().playerChoise;
		for(int i = 0; i < RI.transform.childCount; i++)
		{
			if(RI.transform.GetChild(i).GetComponent<Weapon>() != choise)
			{
				if(!RI.transform.GetChild(i).GetComponent<Weapon>().FindCertainBuff(GetComponent<Weapon>().name))
				{
					Buff new_buff = Instantiate(buff, RI.transform.GetChild(i)).GetComponent<Buff>();
					new_buff.type_change = MainController.Choise.useless;
					new_buff.temporary = true; 
					new_buff.timer = 2;
					new_buff.id = GetComponent<Weapon>().name;
					new_buff.AddBuff();	
				} else
				{
					RI.transform.GetChild(i).GetComponent<Weapon>().GetCertainBuff(GetComponent<Weapon>().name).GetComponent<Buff>().timer = 2;
				}
			}
		}
	}
}
