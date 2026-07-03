using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycler : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != "Scrap"; };
        GetComponent<BuffController>().onDestruction = true;
        GetComponent<BuffController>().special = GainScrap;
    }

    public void GainScrap(Weapon w)
    {
        GetComponent<WeaponSpawner>().SpawnRandomWeapon();
    }
}
