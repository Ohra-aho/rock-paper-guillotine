using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantScissors : MonoBehaviour
{
	public Buff buff;
    int previous_equips = 0;
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void DebuffGiantScissors()
    {
        List<Weapon> weapons = player.GetComponent<PlayerContoller>().GetWeapons();
        for(int i = 0; i < weapons.Count; i++)
		{
			if(weapons[i].name == "Giant Scissors")
			{
				Buff new_buff = Instantiate(buff, weapons[i].transform);
				new_buff.id = GetComponent<Weapon>().name;
				new_buff.damage_buff = -4;
				new_buff.temporary = true;
				new_buff.timer = 1000;
				new_buff.AddBuff();
			}
		}
    }
}
