using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madman : MonoBehaviour
{
    public GameObject buff;
    string name = "Madman";

    public void Chosen()
    {
        //ApplyBuff();
    }

	int amount = 0;

    public void ApplyBuff()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
		List<Weapon> weapons = player.GetComponent<PlayerContoller>().GetWeapons();
		amount = 0;

		for(int i = 0; i < weapons.Count; i++)
		{
			if(weapons[i].GiveEffectiveType() == MainController.Choise.useless)
			{
				amount++;
			}
		}
		
		if(amount > 0)
		{
			player.GetComponent<PlayerContoller>().HB.GiveTemporaryHealth(amount * 2, true);
		}
    }

	public void RemoveBuff()
	{
        GameObject player = GameObject.FindGameObjectWithTag("Player");
		//player.GetComponent<PlayerContoller>().HB.RemoveTemporaryHealth(amount * 2);
		amount = 0;
	}
}
