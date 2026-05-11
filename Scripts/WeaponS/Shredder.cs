using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
    }

    public void AddBuff()
	{
		Buff new_buff = Instantiate(GetComponent<BuffController>().buff, transform).GetComponent<Buff>();
		new_buff.damage_buff = 1;
		new_buff.temporary = true;
		new_buff.timer = 1000;
		new_buff.AddBuff();
	}
}
