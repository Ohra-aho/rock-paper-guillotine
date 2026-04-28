using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public BuffData[] buff_data; //Used in buff loading

    [HideInInspector] public BasicEnemy owner;
    [HideInInspector] public PlayerContoller player_owner;

    [HideInInspector] public bool player;
    [HideInInspector] public Weapon opponent;
    public bool penetrating = false;
    public bool draw_winner = false;
    public bool spammable = false; //For enemy behaviour
    [HideInInspector] public bool dead;
    public MainController.Choise type;
    public int damage;
    public int armor;
    [HideInInspector] public int real_damage;
    [HideInInspector] public int real_armor;
    public string name;
    public string description;
    public Sprite sprite;

    public UnityEvent first_turn;
    public UnityEvent end_of_fight;

    public UnityEvent choisePhase;
    public UnityEvent resultPhase;
    public UnityEvent endPhase;
    public UnityEvent victory;

    public UnityEvent takeDamage;
    public UnityEvent dealDamage;
    public UnityEvent deal_effect_damage;
    public UnityEvent takeNoDamage;
    public UnityEvent win;
    public UnityEvent lose;
    public UnityEvent draw;
    public UnityEvent heal;
    public UnityEvent gain_points;

    public UnityEvent equip;
    public UnityEvent unEquip;

    public UnityEvent constant;
    public UnityEvent onDestruction;
    public UnityEvent eachTurn;

    public UnityEvent unequipped;

    public UnityEvent on_pick;
    public UnityEvent on_death;

    private bool loop_stopper = false; //Helps counteract infinite loops 

    //Types iguess
    public bool self_destructive; //Weapons which synergize with self destruction
    public bool healing; //Weapons which heal or synergice with it
    public bool health; //Weapons which give health or care about it
    public bool kivi_synegry; //Weapons which synergize with other stones
    public bool paperi_synergy;
    public bool sakset_synergy;
    public bool points; //Weapons which collect points or synergize with them.

    //Needed for achievements
    [HideInInspector] public bool used_this_game;

    //Displayed maybe when picked
    public List<string> pick_barks;
    public string executioner_comment;

    [HideInInspector] public int damage_soft_cap = 7;

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

    public void InisiateTypeEffects()
    {
        if (player)
        {
            player_owner = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
            gameObject.AddComponent<TypeEffects>();
            switch (type)
            {
                case MainController.Choise.kivi:
                    GetComponent<TypeEffects>().InisiateRock();
                    break;
                case MainController.Choise.paperi:
                    GetComponent<TypeEffects>().InisiatePaper();
                    break;
                case MainController.Choise.sakset:
                    GetComponent<TypeEffects>().InisiateScissors();
                    break;
            }
        }
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

    public int GiveEffectiveDamage()
    {
        int damage_bonus = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            damage_bonus += transform.GetChild(i).GetComponent<Buff>().damage_buff;
        }
        return damage + damage_bonus;
    }

    public int GiveEffectiveArmor()
    {
        int armor_bonus = 0;
        for(int i = 0; i < transform.childCount; i++)
        {
            armor_bonus += transform.GetChild(i).GetComponent<Buff>().armor_buff;
        }
        return armor + armor_bonus;
    }

    public void TakeDamage(int amount)
    {
        int armor_bonus = GiveEffectiveArmor();
       
        int realDamage = 0;
        if(!opponent.penetrating)
        {
            realDamage = amount - (armor+armor_bonus);
            if (realDamage < 0) realDamage = 0;
        } else
        {
            realDamage = amount;
            if (realDamage < 0) realDamage = 0;
        }
        HandleDamageTaking(realDamage, true);
        //if (dead) on_death.Invoke(); //Place to Table controller
    }

    public void DealDamage(Weapon target)
    {
        int damage_bonus = GiveEffectiveDamage();
        target.TakeDamage(damage_bonus);
    }

    public void EffectDamage(int amount)
    {
        if(opponent != null)
        {
            if(GetComponent<EffectDamage>())
            {
                if (GetComponent<EffectDamage>().armor_piercing || GetComponent<Weapon>().penetrating)
                {
                    amount += opponent.GiveEffectiveArmor();
                }
            }
            opponent.TakeDamage(amount);
        } else
        {
            if(player)
            {
                GameObject.Find("Table").GetComponent<TableController>().enemy_damage += amount;
            }
        }
    }

    //Used in effects. Doesn't trigger enemies damage effects
    public void SelfDamage(int amount)
    {
        int realDamage;
        if (!penetrating)
        {
            realDamage = amount - GiveEffectiveArmor();
            if (realDamage < 0) realDamage = 0;
        } 
        else if(GetComponent<EffectDamage>())
        {
            if(!GetComponent<EffectDamage>().armor_piercing && !GetComponent<Weapon>().penetrating)
            {
                realDamage = amount - GiveEffectiveArmor();
                if (realDamage < 0) realDamage = 0;
            } else
            {
                realDamage = amount;
                if (realDamage < 0) realDamage = 0;
            }
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
        TableController TC = GameObject.Find("Table").GetComponent<TableController>();
        if (realDamage > 0)
        {
            if (player)
            {
                TC.player_damage += realDamage;
                if (effect) opponent.dealDamage.Invoke();
                takeDamage.Invoke();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().damage_taken = true;
            }
            else
            {
                TC.enemy_damage += realDamage;
                if (effect) opponent.dealDamage.Invoke();
                takeDamage.Invoke();
                GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().damage_taken = true;
            }
        }
        else
        {
            takeNoDamage.Invoke();
        }
    }

    public void ToggleLoopStropper()
    {
        loop_stopper = false;
    } 

    public void CheckUp()
    {
        bool dead = false;
        if (!player)
        {
            HealthBar hb = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().HB;
            dead = hb.GetComponent<HealthBar>().CheckIfDead();
            if (dead)
            {
                GameObject infoHolder = GameObject.Find("EnemyWeaponInfo");
                infoHolder.GetComponent<WeaponInfoRack>().ClearInfoRack();
                GameObject.Find("EventSystem").GetComponent<MainController>().Win();
                if(on_death != null) on_death.Invoke();
                hb.dead = false;
            }
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
        if(GetComponent<BuffController>())
        {
            if(!GetComponent<BuffController>().temporary)
            {
                GetComponent<BuffController>().Unequip();
            }
        }
    }

    public bool FindCertainBuff(string name)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.GetComponent<Buff>().id == name)
            {
                return true;
            }
        }
        return false;
    } 

    //Could be useful
    public void ResetStats()
    {
        armor = real_armor;
        damage = real_damage;
    }

    public void Balance()
    {
        owner.GetComponent<BasicEnemy>().Balance();
    }

    public void OffBalance()
    {
        owner.GetComponent<BasicEnemy>().OffBalance();
    }
}
