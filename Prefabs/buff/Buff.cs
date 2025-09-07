using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buff : MonoBehaviour
{
    public Weapon weapon;
    public string id;

    public int damage_buff;
    public int armor_buff;
    public int effect_damage_buff;
    public bool used = false;

    public BuffController.Special special;
    public BuffController.Special special_removal;

    //To where put special
    public bool choisePhase;
    public bool resultPhase;
    public bool endPhase;
    public bool victory;

    public bool takeDamage;
    public bool takeNoDamage;
    public bool dealDamage;
    public bool draw;
    public bool win;
    public bool lose;
    public bool heal;

    public bool equip;
    public bool unEquip;

    public bool constant;

    public bool awake;
    public bool onDestruction;

    public bool temporary;
    public int timer;

    public bool penetrating;
    public bool draw_winner;

    private bool og_pen;
    private bool og_draw_winner;
    private bool og_destructive;

    //Debuffs
    public bool destructive;

    public MainController.Choise og_type;
    public MainController.Choise? type_change;

    private void Awake()
    {
        weapon = transform.parent.GetComponent<Weapon>();
        if(awake) special(weapon);
    }

    public void AddBuff()
    {
        if (damage_buff != 0)
        {
            if(damage_buff < 0 && -damage_buff > transform.parent.GetComponent<Weapon>().damage)
            {
                damage_buff = -transform.parent.GetComponent<Weapon>().damage;
            }
            transform.parent.GetComponent<Weapon>().damage += damage_buff;
        }

        if (armor_buff != 0)
        {
            if (armor_buff < 0 && -armor_buff > transform.parent.GetComponent<Weapon>().armor)
            {
                armor_buff = -transform.parent.GetComponent<Weapon>().armor;
            }
            transform.parent.GetComponent<Weapon>().armor += armor_buff;
        }

        if (effect_damage_buff != 0)
        {
            if (effect_damage_buff < 0 && -effect_damage_buff > transform.parent.GetComponent<EffectDamage>().amount)
            {
                effect_damage_buff = -transform.parent.GetComponent<EffectDamage>().amount;
            }
            transform.parent.GetComponent<EffectDamage>().amount += effect_damage_buff;
        }

        GetOGs();

        if(choisePhase)
            transform.parent.GetComponent<Weapon>().choisePhase.AddListener(() => special(weapon));
        if (resultPhase)
            transform.parent.GetComponent<Weapon>().resultPhase.AddListener(() => special(weapon));
        if (endPhase)
            transform.parent.GetComponent<Weapon>().endPhase.AddListener(() => special(weapon));
        if (victory)
            transform.parent.GetComponent<Weapon>().victory.AddListener(() => special(weapon));
        if (takeDamage)
            transform.parent.GetComponent<Weapon>().takeDamage.AddListener(() => special(weapon));
        if (takeNoDamage)
            transform.parent.GetComponent<Weapon>().takeNoDamage.AddListener(() => special(weapon));
        if (dealDamage)
            transform.parent.GetComponent<Weapon>().dealDamage.AddListener(() => special(weapon));
        if (draw)
            transform.parent.GetComponent<Weapon>().draw.AddListener(() => special(weapon));
        if (heal)
            transform.parent.GetComponent<Weapon>().heal.AddListener(() => special(weapon));
        if (constant)
            transform.parent.GetComponent<Weapon>().constant.AddListener(() => special(weapon));
        if (onDestruction)
            transform.parent.GetComponent<Weapon>().onDestruction.AddListener(() => special(weapon));
        if (awake)
            special(weapon);
        if(win)
            transform.parent.GetComponent<Weapon>().win.AddListener(() => special(weapon));
        if (lose)
            transform.parent.GetComponent<Weapon>().lose.AddListener(() => special(weapon));
        if(type_change != null)
            transform.parent.GetComponent<Weapon>().type = type_change ?? og_type;   
        if (penetrating)
            transform.parent.GetComponent<Weapon>().penetrating = true;
        if (draw_winner)
            transform.parent.GetComponent<Weapon>().draw_winner = true;
        if (destructive)
        {
            transform.parent.gameObject.AddComponent<SelfDestruct>();
            transform.parent.GetComponent<Weapon>().endPhase.AddListener(transform.parent.GetComponent<SelfDestruct>().Destruct);
        }
            
    }

    public void RemoveBuff()
    {
        if (damage_buff != 0)
        {
            if(transform.parent.GetComponent<Weapon>().damage < damage_buff)
            {
                damage_buff = transform.parent.GetComponent<Weapon>().damage;
            }
            transform.parent.GetComponent<Weapon>().damage -= damage_buff;

        }

        if (armor_buff != 0)
        {
            if(transform.parent.GetComponent<Weapon>().armor < armor_buff)
            {
                armor_buff = transform.parent.GetComponent<Weapon>().armor;
            }
            transform.parent.GetComponent<Weapon>().armor -= armor_buff;
        }

        if (effect_damage_buff != 0)
        {
            if (transform.parent.GetComponent<EffectDamage>().amount < effect_damage_buff)
            {
                effect_damage_buff = transform.parent.GetComponent<EffectDamage>().amount;
            }
            transform.parent.GetComponent<EffectDamage>().amount -= effect_damage_buff;
        }

        if (choisePhase)
            transform.parent.GetComponent<Weapon>().choisePhase.RemoveListener(() => special(weapon));
        if (resultPhase)
            transform.parent.GetComponent<Weapon>().resultPhase.RemoveListener(() => special(weapon));
        if (endPhase)
            transform.parent.GetComponent<Weapon>().endPhase.RemoveListener(() => special(weapon));
        if (victory)
            transform.parent.GetComponent<Weapon>().victory.RemoveListener(() => special(weapon));
        if (takeDamage)
            transform.parent.GetComponent<Weapon>().takeDamage.RemoveListener(() => special(weapon));
        if (takeNoDamage)
            transform.parent.GetComponent<Weapon>().takeNoDamage.RemoveListener(() => special(weapon));
        if (dealDamage)
            transform.parent.GetComponent<Weapon>().dealDamage.RemoveListener(() => special(weapon));
        if (draw)
            transform.parent.GetComponent<Weapon>().draw.RemoveListener(() => special(weapon));
        if (heal)
            transform.parent.GetComponent<Weapon>().heal.RemoveListener(() => special(weapon));
        if (constant)
            transform.parent.GetComponent<Weapon>().constant.RemoveListener(() => special(weapon));
        if (onDestruction)
            transform.parent.GetComponent<Weapon>().onDestruction.RemoveListener(() => special(weapon));
        if (win)
            transform.parent.GetComponent<Weapon>().win.RemoveListener(() => special(weapon));
        if (lose)
            transform.parent.GetComponent<Weapon>().lose.RemoveListener(() => special(weapon));
        if (type_change != null)
            transform.parent.GetComponent<Weapon>().type = og_type;
        if (penetrating)
            transform.parent.GetComponent<Weapon>().penetrating = og_pen;
        if (draw_winner)
            transform.parent.GetComponent<Weapon>().draw_winner = og_draw_winner;
        if (destructive && !og_destructive)
        {
            transform.parent.GetComponent<Weapon>().endPhase.RemoveListener(transform.parent.GetComponent<SelfDestruct>().Destruct);
            Destroy(transform.parent.gameObject.GetComponent<SelfDestruct>());
        }


        if (special_removal != null) special_removal(weapon);
    }

    public void TickDown()
    {
        if(temporary)
        {
            timer--;
            if (timer <= 0)
            {
                RemoveBuff();
                Destroy(this.gameObject);
            }
        }
    }

    private void GetOGs()
    {
        og_type = transform.parent.GetComponent<Weapon>().type;
        og_draw_winner = transform.parent.GetComponent<Weapon>().draw_winner;
        og_pen = transform.parent.GetComponent<Weapon>().penetrating;
        if (transform.parent.GetComponent<SelfDestruct>()) og_destructive = true;
    }
}
