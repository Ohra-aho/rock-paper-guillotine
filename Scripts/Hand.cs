using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Sprite weapon_sprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<WeaponSprite>())
        {
            if(collision.GetComponent<WeaponSprite>().weapon.GetComponent<SelfDestruct>())
            {
                weapon_sprite = collision.GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().sprite;
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon_sprite;
                collision.GetComponent<WeaponSprite>().weapon.GetComponent<SelfDestruct>().TrueDestruct();
            }
        }
    }
}
