using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traditionalist : MonoBehaviour
{
    public void Chosen()
    {
		List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		if(weapons.Count > 0)
		{
			GameObject.Find("EventSystem").GetComponent<RLController>().achievements.Add(
				weapons[Random.Range(0, weapons.Count)].name
			);	
		}
    }
}
