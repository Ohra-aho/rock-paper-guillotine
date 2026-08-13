using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerContoller : MonoBehaviour
{
	public GameObject buff;
    public MainController MC;
    private EnemyController currentEnemy;
    public HealthBar HB;

    private int maxHealth = 2;
    [HideInInspector] public int damage = 0;
    [HideInInspector] public int armor = 0;


    //Weapons
    public List<GameObject> weapons;

    public GameObject chosenWeapon;

    public int unlocked_wheel = 0;
    public List<GameObject> PlayerWheels;
    public GameObject weaponDetector;
    public GameObject TrueWeaponHolder;
    public GameObject TrueInventory;
    public GameObject WheelHolder;
    public GameObject choise_panel;

    public bool defeat = false;

    public bool spinning; //used to disable choise panels during wheelspin

    GameObject RI;

    [HideInInspector] public bool damage_taken = false;

    private void Start()
    {
        RI = GameObject.FindGameObjectWithTag("RI");
        for (int i = 0; i < 6; i++)
        {
            GameObject panel = Instantiate(choise_panel, transform);
            panel.transform.GetChild(0).GetComponent<SpriteMask>().frontSortingOrder = i;
            panel.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = i;
        }
        InstanciateRealWeapons();
		InstanciateEquippedWeapons();
        //LoadPlayerData();
    }

    public void DisplayChoises()
    {
        for(int i = 0; i < 6; i++)
        {
            if(PlayerWheels[unlocked_wheel].transform.childCount-1 > i)
            {
                if (PlayerWheels[unlocked_wheel].transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
                {
                    transform.GetChild(i).GetComponent<CHoisePanel>().weapon =
                        PlayerWheels[unlocked_wheel].transform.GetChild(i).GetChild(0)
                            .GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>();

                    transform.GetChild(i).GetComponent<CHoisePanel>().weapon_name =
                        PlayerWheels[unlocked_wheel].transform.GetChild(i).GetChild(0)
                            .GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().name;

                    transform.GetChild(i).GetComponent<CHoisePanel>().index = i;
                } else
                {
                    transform.GetChild(i).GetComponent<CHoisePanel>().weapon = null;
                }
            }
            transform.GetChild(i).GetComponent<CHoisePanel>().DisplayName();
        }
    }

    public void MakeAChoise(int choise)
    {
        GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>().damage_taken = false;
        damage_taken = false;

        MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        currentEnemy = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        if(PlayerWheels[unlocked_wheel].transform.GetChild(choise).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
        {
            PlayerWheels[unlocked_wheel].GetComponent<Test>().UnPauseAnimation();
            PlayerWheels[unlocked_wheel].GetComponent<Test>().PlayAudio(0);
            PlayerWheels[unlocked_wheel].GetComponent<Test>().PlayAudio(1);

            Weapon weapon = PlayerWheels[unlocked_wheel].transform.GetChild(choise)
                .GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>();

            MC.playerChoise = weapon;
            chosenWeapon = PlayerWheels[unlocked_wheel].transform.GetChild(choise)
                .GetChild(0).GetComponent<WeaponSprite>().weapon;

            weaponDetector.GetComponent<WeaponDetector>().detectionCount = 0;
            weaponDetector.GetComponent<WeaponDetector>().weaponToDetect = choise+1;

            ChoisePhase();

            MC.enemyChoise = currentEnemy.EnemyChoise(weapon.GiveEffectiveType());

            MC.Resolve();
        }
    }

    public void InstanciateRealWeapons()
    {
        GetComponent<PlayerInventory>().AddAllWeapons();
        //TrueInventory.GetComponent<WeaponController>().LoadPlayerWeapons();

        for (int i = 0; i < GetComponent<PlayerInventory>().items.Count; i++)
        {
            GameObject weapon = Instantiate(GetComponent<PlayerInventory>().items[i], TrueInventory.transform);
            weapon.GetComponent<Weapon>().player = true;
            weapon.GetComponent<Weapon>().player_owner = GetComponent<PlayerContoller>();
            if (weapon.GetComponent<BuffController>()) weapon.GetComponent<BuffController>().Inisiate();
            weapon.GetComponent<Weapon>().InisiateTypeEffects();
			LoadBuffs(0, i, weapon);
        }
        GetComponent<PlayerInventory>().items.Clear();
        for (int i = 0; i < TrueInventory.transform.childCount; i++)
        {
            GetComponent<PlayerInventory>().items.Add(TrueInventory.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < weapons.Count; i++)
        {
            GameObject new_weapon = Instantiate(weapons[i], TrueInventory.transform);
			new_weapon.GetComponent<Weapon>().player = true;
            new_weapon.GetComponent<Weapon>().player_owner = GetComponent<PlayerContoller>();
			new_weapon.GetComponent<Weapon>().InisiateTypeEffects();
			if(new_weapon.GetComponent<BuffController>()) new_weapon.GetComponent<BuffController>().Inisiate();
			LoadBuffs(1, i, new_weapon);
			WheelHolder.GetComponent<PlayerWheelHolder>().EquipWeapon(new_weapon);
        }
		WheelHolder.GetComponent<PlayerWheelHolder>().InvokeAllEquipped();
    }

	public void LoadBuffs(int index_1, int index_2, GameObject weapon)
	{
		if(GetComponent<PlayerInventory>().loaded_weapons != null)
		{
			BuffData[] buffs = GetComponent<PlayerInventory>().loaded_weapons[index_1][index_2].buffs;
			if(weapon.GetComponent<Stacking>()) weapon.GetComponent<Stacking>().stacks = GetComponent<PlayerInventory>().loaded_weapons[index_1][index_2].stacks;
			if(buffs != null)
			{
				for(int i = 0; i < buffs.Length; i++)
				{
					if(!weapon.GetComponent<Weapon>().FindCertainBuff(buffs[i].id) && !buffs[i].special)
					{
						Buff old_buff = Instantiate(buff, weapon.transform).GetComponent<Buff>();
						old_buff.id = buffs[i].id;
						old_buff.damage_buff = buffs[i].damage_buff;
						old_buff.armor_buff = buffs[i].armor_buff;
						old_buff.effect_damage_buff = buffs[i].effect_damage_buff;
						old_buff.toughness_buff = buffs[i].toughness_buff;
						old_buff.AddBuff();	
					}
				}		
			}

			if (weapon.GetComponent<HealthIncrease>())
			{
				weapon.GetComponent<HealthIncrease>().amount = GetComponent<PlayerInventory>().loaded_weapons[index_1][index_2].health_increase;
			}
			if(weapon.GetComponent<Stacking>())
			{
				weapon.GetComponent<Stacking>().stacks = GetComponent<PlayerInventory>().loaded_weapons[index_1][index_2].stacks;
				weapon.GetComponent<Stacking>().LoadFunction.Invoke();
			}
			if(GetComponent<PlayerInventory>().loaded_weapons[index_1][index_2].copy)
			{
				weapon.GetComponent<Weapon>().name += " (Copy)";
			}
		}
	}

	public void InstanciateEquippedWeapons()
	{
		for(int i = 0; i < weapons.Count; i++)
		{
			//WheelHolder.GetComponent<PlayerWheelHolder>().EquipWeapon(weapons[i]);
		}
	}

    public void ClearTrueWeaponHolder()
    {
        for(int i = TrueWeaponHolder.transform.childCount; i > 0; i--)
        {
            Destroy(TrueWeaponHolder.transform.GetChild(0).gameObject);
        }
    }

    public List<Weapon> GetWeapons()
    {
        List<Weapon> temp = new List<Weapon>();

        GameObject wheel = transform.parent
            .GetChild(0).GetChild(0).gameObject;

        for(int i = 0; i < wheel.transform.childCount-1; i++)
        {
            if(wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
            {
                temp.Add(
                    wheel.transform.GetChild(i).GetChild(0)
                        .GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>()
                );
            } 
        }
        return temp;
    }

    public void ChangeWheel(bool start)
    {
        DisableAllWheels();
        PlayerWheels[unlocked_wheel].SetActive(true);
        PlayerWheels[unlocked_wheel].transform.SetAsFirstSibling();
        GameObject.Find("PlayerWeaponDetector").GetComponent<WeaponDetector>().weaponWheel = PlayerWheels[unlocked_wheel];
        maxHealth = unlocked_wheel + 1;
		HB.removed_damage = 0;
        HB.IncreaseHealthBar(1, false);
        HB.HealToFull();
		if(!start) MC.GetComponent<SaveHub>().SaveAll();
    }

    private void DisableAllWheels()
    {
        for(int i = 0; i < PlayerWheels.Count; i++)
        {
            UnequipAllWeaponsFromGear(PlayerWheels[i]);
            PlayerWheels[i].SetActive(false);
        }
    }

    private void UnequipAllWeaponsFromGear(GameObject gear)
    {
        for(int i = 0; i < gear.transform.childCount; i++)
        {
            if (gear.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>())
            {
                if(gear.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
                {
                    gear.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().Unequip();
                }
            }
        }
    }

    public void ActivateFirstTurnEffects()
    {
        ActivateUnequippedEffects();

        List<Weapon> equipped_weapons = GetWeapons();
        for(int i = 0; i < equipped_weapons.Count; i++)
        {
			equipped_weapons[i].first_turn.Invoke();
			equipped_weapons[i].heal_modifier.Invoke();
			equipped_weapons[i].damage_modifier.Invoke();
        }
    }

    private void ActivateUnequippedEffects()
    {
		bool bleed_damage = false;
        List<Weapon> equipped_weapons = GetWeapons();
        for (int i = 0; i < RI.transform.childCount; i++)
        {
			if(!equipped_weapons.Contains(RI.transform.GetChild(i).GetComponent<Weapon>()))
			{
				//Prevents bleed damage from stacking
				if(RI.transform.GetChild(i).GetComponent<Weapon>().name.Contains("Bleed"))
				{
					RI.transform.GetChild(i).GetComponent<Bleed>().TakeDamage(!bleed_damage);
					bleed_damage = true;	
				} else
				{
					RI.transform.GetChild(i).GetComponent<Weapon>().unequipped.Invoke();
				}
			}
        }

		for(int i = 0; i < MC.GetComponent<RLController>().chosen_buffs.Count; i++)
		{
			if(MC.GetComponent<RLController>().chosen_buffs[i].GetComponent<Relentless>())
			{
				MC.GetComponent<RLController>().chosen_buffs[i].GetComponent<Relentless>().DealDamage();
			}
			if(MC.GetComponent<RLController>().chosen_buffs[i].GetComponent<Unyielding>())
			{
				MC.GetComponent<RLController>().chosen_buffs[i].GetComponent<Unyielding>().ApplyBuff();
			}
		}
    }

    //Combat functions

    public void Draw()
    {

    }

    public void RecoverAllHealth()
    {
        HB.HealToFull();
    }

    public void Die()
    {
        HB.InstaKill();
    }

	public void DisplayBuffs()
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			if(transform.GetChild(i).GetComponent<CHoisePanel>().weapon != null)
			{
				transform.GetChild(i).GetComponent<CHoisePanel>().DisplayBuffing();
			} else
			{
				transform.GetChild(i).GetComponent<CHoisePanel>().TurnOffBuffIndicator();
			}
		}
	}

	public void HideBuffing()
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).GetComponent<CHoisePanel>().TurnOffBuffIndicator();
		}
	}

	public void DestructionHide(string name)
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			if(transform.GetChild(i).GetComponent<CHoisePanel>().weapon_name == name)
			{
				transform.GetChild(i).GetComponent<CHoisePanel>().TurnOffBuffIndicator();
			}
		}
	}

    //Equipping
    public void EquipWeapon(Weapon weapon)
    {
        weapon.equip.Invoke();
        weapon.player = true;
    }

    public void UnequipWeapon(Weapon weapon)
    {
        weapon.unEquip.Invoke();
        weapon.player = false;
    }


    public int GiveCurrentHealth()
    {
        return HB.GetComponent<HealthBar>().GiveCurrentHealth();
    }

    // Rock, Paper, scissors

    public void ChoisePhase()
    {
        //Does things when choise is made
        chosenWeapon.GetComponent<Weapon>().choisePhase.Invoke();
    }

    public void ResultPhase()
    {
       if(chosenWeapon != null) chosenWeapon.GetComponent<Weapon>().resultPhase.Invoke();
    }

    public void EndPhase()
    {
        if (chosenWeapon != null) chosenWeapon.GetComponent<Weapon>().endPhase.Invoke();
    }


    //Save functions

    public void SavePlayerData()
    {
        PlayerData data = new PlayerData(this);
        SaveSystem.SavePlayerData(data);
    }

    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayerData();
		
        if (data != null)
        {
            //Set health
            unlocked_wheel = data.gear;
            HB.SetMaxHealth(data.max_health);
            HB.SetCurrentHealth(data.current_health);
			HB.removed_damage= data.removed_damage;

            //Set correct wheel
            PlayerWheels[0].SetActive(false);
            PlayerWheels[unlocked_wheel].SetActive(true);
            PlayerWheels[unlocked_wheel].transform.SetAsFirstSibling();
            GameObject.Find("PlayerWeaponDetector").GetComponent<WeaponDetector>().weaponWheel = PlayerWheels[unlocked_wheel];

        }
        else
        {
            HB.SetMaxHealth(maxHealth);
            HB.SetCurrentHealth(maxHealth);
            ChangeWheel(true);
        }
    }

    private void LoadBuffData()
    {
        for(int i = 0; i < TrueInventory.transform.childCount; i++)
        {
            Weapon weapon = TrueInventory.transform.GetChild(i).GetComponent<Weapon>();
            if(weapon.buff_data.Length > 0)
            {
                for(int j = 0; j < weapon.buff_data.Length; j++)
                {
                    Buff target_buff = FindBuffById(weapon.buff_data[j].id, weapon.gameObject);
                }
            }
        }
    }

    private Buff FindBuffById(string id, GameObject target_weapon)
    {
        for(int i = 0; i < target_weapon.transform.childCount; i++)
        {
            Buff buff = target_weapon.transform.GetChild(i).GetComponent<Buff>();
            if(buff.id == id)
            {
                return buff;
            }
        }
        Debug.Log("Correct buff not found");
        return null;
    }

    public GameObject FindWeaponFromIntentory(string name)
    {
        for(int i = 0; i < TrueInventory.transform.childCount; i++)
        {
            if(TrueInventory.transform.GetChild(i).GetComponent<Weapon>().name == name)
            {
                return TrueInventory.transform.GetChild(i).gameObject;
            }
        }
        return null;
    }

    public void RemoveWeaponByName(string name)
    {
        for (int i = 0; i < GetComponent<PlayerInventory>().items.Count; i++)
        {
            if (GetComponent<PlayerInventory>().items[i].GetComponent<Weapon>().name == name)
            {
                GetComponent<PlayerInventory>().items.RemoveAt(i);
                break;
            }
        }
    }
}
