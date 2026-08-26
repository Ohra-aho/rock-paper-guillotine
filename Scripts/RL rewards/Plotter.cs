using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plotter : MonoBehaviour
{
	public GameObject buff;
    public void Chosen()
    {
        //ApplyBuff();
    }

    public void ApplyBuff()
    {
		
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for (int i = 0; i < RI.transform.childCount; i++)
        {
            GameObject weapon = RI.transform.GetChild(i).gameObject;
            if (weapon.GetComponent<EffectDamage>())
            {
				Buff new_buff = Instantiate(buff, RI.transform.GetChild(i)).GetComponent<Buff>();
                new_buff.effect_damage_buff = 1;
				new_buff.temporary = true;
				new_buff.id = "Plotter";
				new_buff.deal_effect_damage = true;
				new_buff.timer = 1000;
				new_buff.reminder = "+1 effect damage until used.";
				new_buff.special = (Weapon w) =>
				{
					new_buff.RemoveBuff();
					Destroy(new_buff.gameObject);
				};
				new_buff.AddBuff();
            }
        }
    }
}

