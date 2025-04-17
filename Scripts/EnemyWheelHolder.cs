using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWheelHolder : MonoBehaviour
{
    public void RemoveWeapon(GameObject weapon)
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            GameObject weaponHolder = transform.GetChild(0).GetChild(i).gameObject;
            if (weaponHolder.transform.GetChild(0).GetComponent<WeaponSprite>())
            {
                if (weaponHolder.transform.GetChild(0).GetComponent<WeaponSprite>().weapon == weapon)
                {
                    Destroy(weaponHolder.transform.GetChild(0).GetComponent<WeaponSprite>().weapon);
                    weaponHolder.transform.GetChild(0).GetComponent<WeaponSprite>().RemoveSprite();
                }
            }
        }
    }
}
