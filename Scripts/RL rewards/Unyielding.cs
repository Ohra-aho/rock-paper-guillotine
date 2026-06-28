using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unyielding : MonoBehaviour
{
    public GameObject buff;
    string name = "Unyielding";

    public void Chosen()
    {
        ApplyBuff();
    }

    public void ApplyBuff()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for (int i = 0; i < RI.transform.childCount; i++)
        {
            
			GameObject weapon = RI.transform.GetChild(i).gameObject;
			if(!FindOwnBuff(weapon.GetComponent<Weapon>()))
			{
				GameObject new_buff = Instantiate(buff, weapon.transform);
				new_buff.GetComponent<Buff>().id = name;
				new_buff.GetComponent<Buff>().heal = true;
				new_buff.GetComponent<Buff>().special = (Weapon w) =>
				{
					GiveTempBuffs();
				};
				new_buff.GetComponent<Buff>().AddBuff();
			}
        }
    }

	public void GiveTempBuffs()
	{
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
		for (int i = 0; i < RI.transform.childCount; i++)
        {
			GameObject weapon = RI.transform.GetChild(i).gameObject;
			GameObject new_buff = Instantiate(buff, weapon.transform);
			new_buff.GetComponent<Buff>().id = name + "_buff";
			new_buff.GetComponent<Buff>().armor_buff = 1;
			new_buff.GetComponent<Buff>().temporary = true;
			new_buff.GetComponent<Buff>().timer = 2;
			new_buff.GetComponent<Buff>().AddBuff();
        }
	}

    private bool FindOwnBuff(Weapon weapon)
    {
        for (int i = 0; i < weapon.transform.childCount; i++)
        {
            if (weapon.transform.GetChild(i).GetComponent<Buff>().id == name)
            {
                return true;
            }
        }
        return false;
    }
}
