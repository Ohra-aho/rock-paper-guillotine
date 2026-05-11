using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScissors : MonoBehaviour
{
    public void HalfDamage()
    {
        if(GetComponent<Weapon>().damage > 0)
		{
			GetComponent<Weapon>().damage--;
			GetComponent<WeaponSpawner>().SpawnOnlyWeapon();
		}
		if(GetComponent<Weapon>().damage <= 0)
		{
			GetComponent<SelfDestruct>().Destruct();
		}
    }
}
