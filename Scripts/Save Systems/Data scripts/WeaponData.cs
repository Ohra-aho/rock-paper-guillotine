using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public string name;

    public WeaponData(Weapon weapon)
    {
        name = weapon.name;
    }
}
