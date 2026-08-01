using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painkiller : MonoBehaviour
{
    private void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().onDestruction = true;
		GetComponent<BuffController>().special = (Weapon w) => { GetComponent<Healing>().Heal(); };
	}
}
