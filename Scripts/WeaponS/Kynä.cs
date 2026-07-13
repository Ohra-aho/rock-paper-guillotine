using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kynä : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.type == MainController.Choise.paperi; };
		GetComponent<BuffController>().draw = true;
		GetComponent<BuffController>().special = Extend;
    }

	public void Extend(Weapon w)
	{
		GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for (int i = 0; i < RI.transform.childCount; i++)
        {
			GameObject buff = RI.transform.GetChild(i).GetComponent<Weapon>().GetCertainBuff(w.name + "_base");
            buff.GetComponent<Buff>().timer += 1;
			buff.GetComponent<Buff>().reminder = "+1 armor.";
        }
	}
}
