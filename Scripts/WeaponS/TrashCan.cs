using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = AddWeapon;
        GetComponent<BuffController>().onDestruction = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
    }

	public void AddWeapon(Weapon w)
	{
		if(GetComponent<Stacking>().stacks > 0)
		{
			GetComponent<Stacking>().DecreaseStacks(1);
			GetComponent<WeaponSpawner>().weapons.Add(Instantiate(w.gameObject));
			GetComponent<WeaponSpawner>().SpawnOnlyWeapon();
			GetComponent<WeaponSpawner>().weapons.Clear();
		}
	}
}
