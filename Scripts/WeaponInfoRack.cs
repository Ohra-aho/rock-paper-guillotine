using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfoRack : MonoBehaviour
{
    public GameObject info;

    public void SpawnWeaponInfo(Weapon weapon)
    {
        GameObject infoBox = Instantiate(info, transform);
        infoBox.GetComponent<EnemyWeaponInfo>().weapon = weapon;
        infoBox.GetComponent<EnemyWeaponInfo>().Initiate();
    }

    public void ClearInfoRack()
    {
        if(transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

}
