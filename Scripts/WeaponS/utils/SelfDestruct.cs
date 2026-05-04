using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    //[HideInInspector] public bool used_ones = true;
    [HideInInspector] public bool destroyed = false;
    [HideInInspector] public bool disabled = false;
    [HideInInspector] public int toughness = 0;

    public void Destruct()
    {
        if(!disabled && GetComponent<Weapon>().name != "Diamond")
        {
            bool nessessary = false;
            bool play_animation = true;
            if (GetComponent<Weapon>().player)
            {
                if(!GetComponent<Weapon>().player_owner.HB.dead) nessessary = true;
            } else
            {
                if (!GetComponent<Weapon>().owner.HB.dead) nessessary = true;

                for (int i = 0; i < GetComponent<Weapon>().owner.weapons.Count; i++)
                {
                    if(GetComponent<Weapon>().owner.weapons[i] != null)
                    {
                        if (GetComponent<Weapon>().owner.weapons[i].GetComponent<Weapon>().name != GetComponent<Weapon>().name)
                        {
                            play_animation = true;
                            break;
                        }
                    } else
                    {
                        play_animation = false;
                    }
                }
            }

            if (toughness > 0) nessessary = false;

            if (nessessary)
            {
                GetComponent<Weapon>().onDestruction.Invoke();

                if (GetComponent<Weapon>().player)
                {
                    GameObject.Find("Destruction hand").GetComponent<Hand>().weapon_to_destroy = this.gameObject;
                    GameObject.Find("Destruction hand").GetComponent<Test>().PlayAnimation("grab");
                    destroyed = true;
                }
                else
                {
                    if (!GetComponent<Weapon>().owner.HB.dead)
                    {
                        if(play_animation) GameObject.Find("Destruction hand e").GetComponent<Hand>().weapon_to_destroy = this.gameObject;
                        if(play_animation) GameObject.Find("Destruction hand e").GetComponent<Test>().PlayAnimation("grab2");
                        destroyed = true;
                    }
                }
            }
            toughness--;
        }
    }

    public void TrueDestruct()
    {
        if(GetComponent<Weapon>().player)
        {
            GameObject.Find("PlayerWheelHolder").GetComponent<PlayerWheelHolder>()
                .RemoveWeapon(this.gameObject);

            //Check if player is left starnded
            MainController MC = GameObject.Find("EventSystem").GetComponent<MainController>();
            GameObject wheel = GameObject.Find("PlayerWheelHolder").transform.GetChild(0).gameObject;
            bool empty = true;
            for (int i = 0; i < wheel.transform.childCount - 1; i++)
            {
                GameObject w = wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon;
                if (w != null)
                {
                    if (w.GetComponent<SelfDestruct>())
                    {
                        if (!w.GetComponent<SelfDestruct>().destroyed)
                        {
                            empty = false;
                            break;
                        }
                    }
                    else
                    {
                        empty = false;
                        break;
                    }
                }
            }
            if (empty && !MC.victory)
            {
                GameObject.Find("EventSystem").GetComponent<MainController>().EndGame();
            }
            
        } else
        {
            GameObject.Find("Wheel holder").GetComponent<EnemyWheelHolder>()
                .RemoveWeapon(this.gameObject);
        }
    }

    private Buff FindCertainBuff(string name)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<Buff>().id == name)
            {
                return transform.GetChild(i).GetComponent<Buff>();
            }
        }
        return null;
    }
}
