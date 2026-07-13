using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sepeli : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.type == MainController.Choise.sakset; };
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().endPhase = true;
		GetComponent<BuffController>().destructive = true;
		GetComponent<BuffController>().special = GivePoints;
		GetComponent<BuffController>().reminder = "After use, the weapon with least points gains 2 points and this weapon destroys itself.";
    }

	 public void GivePoints(Weapon w)
    {
        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
        Weapon least = null;
        for(int i = 0; i < weapons.Count; i++)
        {
            if(weapons[i].GetComponent<Stacking>())
            {
                if(least == null)
                {
                    least = weapons[i];
                } else if(least.GetComponent<Stacking>().stacks > weapons[i].GetComponent<Stacking>().stacks)
                {
                    least = weapons[i];
                }
            }
        }
		int amount = 2;
        if(least != null)
        {
            least.GetComponent<Stacking>().IncreaseStacks(amount);
        }
    }
}
