using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject weapon_to_destroy;
    Sprite weapon_sprite;
    public List<Sprite> icons;
    MainController.State previous_state = MainController.State.in_battle;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<WeaponSprite>())
        {
            if(collision.GetComponent<WeaponSprite>().weapon == weapon_to_destroy)
            {
                weapon_sprite = collision.GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().sprite;
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon_sprite;
                switch (collision.GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().type)
                {
                    case MainController.Choise.kivi: transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = icons[0]; break;
                    case MainController.Choise.paperi: transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = icons[1]; break;
                    case MainController.Choise.sakset: transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = icons[2]; break;
                    case MainController.Choise.hyödytön: transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = icons[3]; break;
                    case MainController.Choise.voittamaton: transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = icons[4]; break;
                }
                
                //Required if weapon to destroy doesn't have SelfDestruct (Possible with debuffs)
                if(collision.GetComponent<WeaponSprite>().weapon.GetComponent<SelfDestruct>())
                {
                    collision.GetComponent<WeaponSprite>().weapon.GetComponent<SelfDestruct>().TrueDestruct();
                }
                else
                {
                    if (collision.GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().player)
                    {
                        GameObject.Find("PlayerWheelHolder").GetComponent<PlayerWheelHolder>()
                            .RemoveWeapon(collision.GetComponent<WeaponSprite>().weapon);
                    }
                    else
                    {
                        GameObject.Find("Wheel holder").GetComponent<EnemyWheelHolder>()
                            .RemoveWeapon(collision.GetComponent<WeaponSprite>().weapon);
                    }
                }
            }
        }
    }

    public void PlayGrabAudio()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<Stupid>())
            {
                transform.GetChild(i).GetChild(0).GetComponent<AudioPlayer>().PlayClip();
            }
        }
    }

    public void ClearWeapon()
    {
        weapon_sprite = null;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
    }

    public void ChangeState(int i)
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        switch(i)
        {
            case 1:
                previous_state = MC.game_state;
                MC.game_state = MainController.State.transition;
                break;
            case 2:
                if(MC.game_state != MainController.State.dead)
                {
                    MC.game_state = previous_state;
                }
                break;
        }
    }
}
