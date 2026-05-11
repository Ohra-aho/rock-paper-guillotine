using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = Activate;
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }


    public void Activate(Weapon w)
    {
        GetComponent<Stacking>().IncreaseStacks(1);
    }

	public void Use()
	{
		if(GetComponent<Stacking>().stacks >= 3)
        {
            List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
            int index = Random.Range(0, weapons.Count);
            weapons[index].damage++;
			GetComponent<Stacking>().DecreaseStacks(3);
        }
	}
}
