using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TypeEffects))]
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
    public MainController.Choise type;
    public int damage;
    public int armor;
    [HideInInspector] public int real_damage;
    [HideInInspector] public int real_armor;
    public string name;
    public string description;
    public Sprite sprite;
	[HideInInspector] public List<Sprite> tiers = new List<Sprite>();
	public int tier = 0;

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
	public UnityEvent damage_modifier;
	public UnityEvent heal_modifier;

    public UnityEvent unequipped;

    public UnityEvent on_pick;
    public UnityEvent on_death;

    private bool loop_stopper = false; //Helps counteract infinite loops 

    //Needed for achievements
    [HideInInspector] public bool used_this_game;

    //Displayed maybe when picked
    public List<string> pick_barks;
    public string executioner_comment;
	public string favourite;

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
		if(player) player_owner = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
		if(GetComponent<TypeEffects>())
		{
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
				default: break;
			}	
		}
    }

    public bool? GetVictory()
    {
        return GameObject.Find("EventSystem").GetComponent<MainController>().won;
    }

    public bool? GetDead()
    {
        return false;
    }

    public int GiveEffectiveDamage()
    {
        int damage_bonus = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            damage_bonus += transform.GetChild(i).GetComponent<Buff>().damage_buff;
        }
        int effective_damage = damage + damage_bonus;
        if(effective_damage < 0) effective_damage = 0;
        return effective_damage;
    }

    public int GiveEffectiveArmor()
    {
        int armor_bonus = 0;
        for(int i = 0; i < transform.childCount; i++)
        {
            armor_bonus += transform.GetChild(i).GetComponent<Buff>().armor_buff;
        }
        int effective_armor = armor + armor_bonus;
        if (effective_armor < 0) effective_armor = 0;
        return effective_armor;
    }

    public void TakeDamage(int amount)
    {
        int realDamage = amount;
        HandleDamageTaking(realDamage, true);
    }

    public void DealDamage(Weapon target)
    {
        int damage_bonus = GiveEffectiveDamage();
        target.TakeDamage(damage_bonus);
    }

    public void EffectDamage(int amount)
    {
		if(player)
		{
			if(penetrating || GetComponent<EffectDamage>().armor_piercing) GameObject.Find("Table").GetComponent<TableController>().enemy_direct_damage += amount;
			else GameObject.Find("Table").GetComponent<TableController>().enemy_damage += amount;
			
		} else
		{
			if(penetrating || GetComponent<EffectDamage>().armor_piercing) GameObject.Find("Table").GetComponent<TableController>().player_direct_damage += amount;
			else GameObject.Find("Table").GetComponent<TableController>().player_damage += amount;
		}
    }

    //Used in effects. Doesn't trigger enemies damage effects
    public void SelfDamage(int amount)
    {
        int realDamage = amount;
        TableController TC = GameObject.Find("Table").GetComponent<TableController>();
        if (realDamage > 0)
        {
            if (player)
            {
                if(penetrating || GetComponent<EffectDamage>().armor_piercing) TC.player_direct_damage += realDamage;
				else TC.player_damage += realDamage;
            }
            else
            {
				if(penetrating || GetComponent<EffectDamage>().armor_piercing) TC.enemy_direct_damage += realDamage;
                else TC.enemy_damage += realDamage;
            }
        }
    }

    public void HandleDamageTaking(int realDamage, bool effect)
    {
        TableController TC = GameObject.Find("Table").GetComponent<TableController>();
        if (realDamage > 0)
        {
            if (player)
            {
                if(opponent.penetrating) TC.player_direct_damage += realDamage;
				else TC.player_damage += realDamage;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().damage_taken = true;
            }
            else
            {
				if(opponent.penetrating) TC.enemy_direct_damage += realDamage;
                else TC.enemy_damage += realDamage;
                GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().damage_taken = true;
            }
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
                GameObject infoHolder = GameObject.Find("enemy weapon rack");
				infoHolder.GetComponent<WeaponInfoRack>().TrueReset();
                infoHolder.GetComponent<WeaponInfoRack>().ClearInfoRack();
                GameObject.Find("EventSystem").GetComponent<MainController>().Win();
                if(on_death != null) on_death.Invoke();
                hb.dead = false;
                if (dead)
                {
                    if(opponent != null) opponent.victory.Invoke();
                }
            }
        }
        else
        {
            HealthBar hb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB;
            dead = hb.GetComponent<HealthBar>().CheckIfDead();

            if(dead) on_death.Invoke();
			//Tick down temporary buffs
			List<Weapon> weapons = GetComponent<Weapon>().player_owner.GetWeapons();
			for(int i = 0; i < weapons.Count; i++)
			{
				GameObject weapon = weapons[i].gameObject;
				if (weapon.transform.childCount > 0)
				{
					for(int j = 0; j < weapon.transform.childCount; j++)
					{
						if(weapon.transform.GetChild(j).GetComponent<Buff>().timer > 0)
						{
							weapon.transform.GetChild(j).GetComponent<Buff>().TickDown();
						}
					}
				}
			}

            if(dead)
            {
                GameObject.Find("EventSystem").GetComponent<MainController>().Loose();
            }
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
    
    public GameObject? GetCertainBuff(string name)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.GetComponent<Buff>().id == name)
            {
                return transform.GetChild(i).gameObject;
            }
        }
        return null;
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
