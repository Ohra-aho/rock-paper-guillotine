using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public List<GameObject> weapons;

    public void SpawnRandomWeapon()
    {
        int index = Random.Range(0, weapons.Count);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(weapons[index]);
    }

    public void SpawnSpecificWeapon(int i)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(weapons[i]);
    }

    public void SpawnOnlyWeapon()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(weapons[0]);
    }
}
