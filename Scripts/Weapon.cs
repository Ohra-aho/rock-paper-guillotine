using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [HideInInspector] public bool player;
    [HideInInspector] public Weapon opponent;
    [HideInInspector] public bool penetrating = false;
    [HideInInspector] public bool dead;
    public MainController.Choise type;
    public int damage;
    public int armor;
    public string name;
    public string description;
    public Sprite sprite;
    public int stacks;

    public UnityEvent choisePhase;
    public UnityEvent resultPhase;
    public UnityEvent endPhase;
    public UnityEvent victory;

    public UnityEvent takeDamage;
    public UnityEvent dealDamage;
    public UnityEvent draw;
    public UnityEvent heal;

    public UnityEvent equip;
    public UnityEvent unEquip;

    public UnityEvent constant;
    public UnityEvent onDestruction;

    //Types
    public bool self_destructive; //Weapons which synergize with self destruction
    public bool healing; //Weapons which heal or synergice with it
    public bool health; //Weapons which give health or care about it
    public bool kivi_synegry; //Weapons which synergize with other stones
    public bool paperi_synergy;
    public bool sakset_synergy;
    public bool points; //Weapons which collect points or synergize with them.
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

    public void TakeDamage(HealthBar HB, int amount)
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

        if(realDamage > 0)
        {
            if (HB == null)
            {
                if (player)
                {
                    HealthBar hb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
                    hb.TakeDamage(realDamage);
                    opponent.dealDamage.Invoke();
                    takeDamage.Invoke();
                    dead = hb.GetComponent<HealthBar>().CheckIfDead();
                }
                else
                {
                    HealthBar hb = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;
                    hb.TakeDamage(realDamage);
                    opponent.dealDamage.Invoke();
                    takeDamage.Invoke();
                    dead = hb.GetComponent<HealthBar>().CheckIfDead();
                }
            }
            else
            {
                HB.TakeDamage(realDamage);
                opponent.dealDamage.Invoke();
                takeDamage.Invoke();
                dead = HB.GetComponent<HealthBar>().CheckIfDead();
                if(!player)
                {
                    GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().TakeDamage();
                }
            }
        }

        
    }

    public void DealDamage(Weapon target, HealthBar opponent_hb)
    {
        target.TakeDamage(opponent_hb, damage);
        //dealDamage.Invoke();
        bool dead = opponent_hb.GetComponent<HealthBar>().CheckIfDead();
        if(dead)
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
        onDestruction.Invoke();
    }
}
