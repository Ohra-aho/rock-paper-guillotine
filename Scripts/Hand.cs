using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Sprite weapon_sprite;
    public List<Sprite> icons;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<WeaponSprite>())
        {
            if(collision.GetComponent<WeaponSprite>().weapon.GetComponent<SelfDestruct>())
            {
                weapon_sprite = collision.GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().sprite;
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon_sprite;
                switch(collision.GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().type)
                {
                    case MainController.Choise.kivi: transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = icons[0]; break;
                    case MainController.Choise.paperi: transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = icons[1]; break;
                    case MainController.Choise.sakset: transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = icons[2]; break;
                    case MainController.Choise.hyödytön: transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = icons[3]; break;
                    case MainController.Choise.voittamaton: transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = icons[4]; break;
                }
                
                collision.GetComponent<WeaponSprite>().weapon.GetComponent<SelfDestruct>().TrueDestruct();
            }
        }
    }
}
