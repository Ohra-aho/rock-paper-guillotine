using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    int previous_index = -1;
    public GameObject buff;

	private void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().choisePhase = true;
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().special = GiveBuff;
		GetComponent<BuffController>().special_apply = true;
	}

    public void GiveBuff(Weapon w)
    {
        int index = Random.Range(0, 3);
        while(index == previous_index)
        {
            index = Random.Range(0, 3);
        }
        previous_index = index;
        switch(index)
        {
            case 0:
                GameObject new_buff = Instantiate(buff, w.transform);
                new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name + "_2";
                new_buff.GetComponent<Buff>().damage_buff = 3;
                new_buff.GetComponent<Buff>().temporary = true;
                new_buff.GetComponent<Buff>().timer = 1;
                new_buff.GetComponent<Buff>().AddBuff();
                break;
            case 1:
                GameObject new_buff_2 = Instantiate(buff, w.transform);
                new_buff_2.GetComponent<Buff>().id = GetComponent<Weapon>().name + "_2";
                new_buff_2.GetComponent<Buff>().type_change = MainController.Choise.voittamaton;
                new_buff_2.GetComponent<Buff>().temporary = true;
                new_buff_2.GetComponent<Buff>().timer = 1;
                new_buff_2.GetComponent<Buff>().AddBuff();
                break;
            case 2:
                GameObject new_buff_3 = Instantiate(buff, w.transform);
                new_buff_3.GetComponent<Buff>().id = GetComponent<Weapon>().name + "_2";
				new_buff_3.GetComponent<Buff>().armor_buff = 2;
                new_buff_3.GetComponent<Buff>().temporary = true;
                new_buff_3.GetComponent<Buff>().timer = 1;
                new_buff_3.GetComponent<Buff>().AddBuff();
                break;
        }
    }

    public Weapon GetRandomEquippedWeapon()
    {
        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
		int index = Random.Range(0, weapons.Count);
		while(weapons[index].name == GetComponent<Weapon>().name)
		{
			index = Random.Range(0, weapons.Count);
		}
        return weapons[index];
    }
}
