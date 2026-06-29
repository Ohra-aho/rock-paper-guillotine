using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traditionalist : MonoBehaviour
{
    public void Chosen()
    {
		MainController MC = GameObject.Find("EventSystem").GetComponent<MainController>();
		List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		int i = Random.Range(0, weapons.Count);

		string type = "";
		string name = "";
		if(MC.playerChoise != null)
		{
			switch(MC.playerChoise.type)
			{
				case MainController.Choise.kivi: type = "k"; break;
				case MainController.Choise.paperi: type = "p"; break;
				case MainController.Choise.sakset: type = "s"; break;
				case MainController.Choise.voittamaton: type = "v"; break;
				case MainController.Choise.useless: type = "h"; break;
			}
			name = type+MC.playerChoise.gameObject.name.Replace("(Clone)", "");
		} else
		{
			switch(weapons[i].type)
			{
				case MainController.Choise.kivi: type = "k"; break;
				case MainController.Choise.paperi: type = "p"; break;
				case MainController.Choise.sakset: type = "s"; break;
				case MainController.Choise.voittamaton: type = "v"; break;
				case MainController.Choise.useless: type = "h"; break;
			}
			name = type+weapons[i].gameObject.name.Replace("(Clone)", "");
		}

		if(weapons.Count > 0)
		{
			GameObject.Find("EventSystem").GetComponent<RLController>().achievements.Add(name);	
		}
    }
}
