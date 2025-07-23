using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public BuffData[] buff_data; //Used in buff loading

    [HideInInspector] public bool player;
    [HideInInspector] public Weapon opponent;
    [HideInInspector] public bool penetrating = false;
    [HideInInspector] public bool dead;
    public MainController.Choise type;
    public int damage;
    public int armor;
    [HideInInspector] public int real_damage;
    [HideInInspector] public int real_armor;
    public string name;
    public string description;
    public Sprite sprite;
    //public int stacks;

    public UnityEvent choisePhase;
    public UnityEvent resultPhase;
    public UnityEvent endPhase;
    public UnityEvent victory;

    public UnityEvent takeDamage;
    public UnityEvent dealDamage;
    public UnityEvent takeNoDamage;
    public UnityEvent win;
    public UnityEvent lose;
    public UnityEvent draw;
    public UnityEvent heal;

    public UnityEvent equip;
    public UnityEvent unEquip;

    public UnityEvent constant;
    public UnityEvent onDestruction;
    public UnityEvent eachTurn;

    private bool loop_stopper = false; //Helps counteract infinite loops 

    //Types iguess
    public bool self_destructive; //Weapons which synergize with self destruction
    public bool healing; //Weapons which heal or synergice with it
    public bool health; //Weapons which give health or care about it
    public bool kivi_synegry; //Weapons which synergize with other stones
    public bool paperi_synergy;
    public bool sakset_synergy;
    public bool points; //Weapons which collect points or synergize with them.

    private void Awake()
    {
        real_armor = armor;
        real_damage = damage;
        endPhase.AddListener(ToggleLoopStropper);
    }

    private void Update()
    {
        if (constant != null) constant.Invoke();
    }

    public bool? GetVictory()
    {
        return GameObject.Find("EventSystem").GetComponent<MainController>().won;
    }

    public bool? GetDead()
    {
        //return GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().dead;
        return false;
    }

    public void TakeDamage(int amount)
    {
        int realDamage;
        if(!opponent.penetrating)
        {
            realDamage = amount - armor;
            if (realDamage < 0) realDamage = 0;
        } else
        {
            realDamage = amount;
            if (realDamage < 0) realDamage = 0;
        }

        HandleDamageTaking(realDamage, true);
    }

    public void DealDamage(Weapon target)
    {
        target.TakeDamage(damage);
        CheckUp();
    }

    public void EffectDamage(int amount)
    {
        opponent.TakeDamage(amount);
        CheckUp();
    }

    //Used in effects. Doesn't trigger enemies damage effects
    public void SelfDamage(int amount)
    {
        int realDamage;
        if (penetrating)
        {
            realDamage = amount - armor;
            if (realDamage < 0) realDamage = 0;
        }
        else
        {
            realDamage = amount;
            if (realDamage < 0) realDamage = 0;
        }

        HandleDamageTaking(realDamage, false);
        
    }

    public void HandleDamageTaking(int realDamage, bool effect)
    {
        if (realDamage > 0)
        {
            if (player)
            {
                HealthBar hb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
                hb.TakeDamage(realDamage);
                if(!loop_stopper)
                {
                    if (effect) opponent.dealDamage.Invoke();
                    takeDamage.Invoke();
                }
                dead = hb.GetComponent<HealthBar>().CheckIfDead();
            }
            else
            {
                HealthBar hb = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;
                hb.TakeDamage(realDamage);
                if(!loop_stopper)
                {
                    if (effect) opponent.dealDamage.Invoke();
                    takeDamage.Invoke();
                }
                dead = hb.GetComponent<HealthBar>().CheckIfDead();
                GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().TakeDamage();

            }
            loop_stopper = true;
        }
        else
        {
            if(!loop_stopper)
            {
                takeNoDamage.Invoke();
            }
            loop_stopper = true;
        }
    }

    public void ToggleLoopStropper()
    {
        loop_stopper = false;
    } 

    public void CheckUp()
    {
        bool dead = false;
        if (player)
        {
            HealthBar hb = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;
            dead = hb.GetComponent<HealthBar>().CheckIfDead();
        }
        else
        {
            HealthBar hb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
            dead = hb.GetComponent<HealthBar>().CheckIfDead();
        }
        if (dead)
        {
            victory.Invoke();
        }
    }

    public void HandleDraw()
    {
        draw.Invoke();
    }

    private void OnDestroy()
    {
        
    }

    //Could be useful
    public void ResetStats()
    {
        armor = real_armor;
        damage = real_damage;
    }
}
