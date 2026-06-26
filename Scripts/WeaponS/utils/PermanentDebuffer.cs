using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PermanentDebuffer : MonoBehaviour
{
	public bool trigger_ones = false;
	bool triggered = false;
    GameObject buff;

    private void Awake()
    {
        buff = Resources.Load<GameObject>("buff/buff");
    }

	private bool HandleTrgger()
	{
		if(!trigger_ones)
		{
			return true;
		}
		else if(!triggered)
		{
			triggered = true;
			return true;
		} else
		{
			return false;
		}
	}

    public void DebuffOpposingWeaponDamage(int amount)
    {
		if(HandleTrgger())
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.damage_buff = -amount;
			new_buff.id = GetComponent<Weapon>() + "_debuff";
			new_buff.AddBuff();	
		}
    }

    public void DebuffOpposingWeaponArmor(int amount)
    {
		if(HandleTrgger())
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.armor_buff = -amount;
			new_buff.id = GetComponent<Weapon>() + "_debuff";
			new_buff.AddBuff();	
		}
    }

	public void BuffOpposingWeaponArmor(int amount)
    {
		if(HandleTrgger())
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.armor_buff = amount;
			new_buff.id = GetComponent<Weapon>() + "_buff";
			new_buff.AddBuff();	
		}
    }

	public void BuffOpposingWeaponDamage(int amount)
    {
		if(HandleTrgger())
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.damage_buff = amount;
			new_buff.id = GetComponent<Weapon>() + "_buff";
			new_buff.AddBuff();	
		}
    }

    public void MakeOpposingWeaponUselessTemporarily(int turns)
    {
		if(HandleTrgger())
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name + "_debuff";
			new_buff.type_change = MainController.Choise.useless;
			new_buff.temporary = true;
			new_buff.timer = turns;
			new_buff.reminder = "Made \"useless\".";
			new_buff.AddBuff();	
		}
    }

	public void MakeOpposingWeaponUselessUntilUsed()
    {
		if(HandleTrgger())
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name + "_debuff";
			new_buff.type_change = MainController.Choise.useless;
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.until_used = true;
			new_buff.reminder = "\"Useless\" until used again or until end of the fight.";
			new_buff.AddBuff();	
		}
    }

    public void DecreaseOpposingHealth(int amount)
    {
		if(HandleTrgger())
		{
        	GetComponent<Weapon>().opponent.player_owner.HB.DecreaseHealthBar(amount, true);
		}
    }

	public void IncreaseOpposingHealth(int amount)
    {
		if(HandleTrgger())
		{
        	GetComponent<Weapon>().opponent.player_owner.HB.IncreaseHealthBar(amount, true);
		}
    }

    public void MakeOpposingWeaponSelfDestructive(int turns)
    {
		if(HandleTrgger())
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name + "_debuff";
			new_buff.destructive = true;
			new_buff.desruction_buffer = true;
			new_buff.reminder = "After use, destroys itself.";
			if(turns > 0)
			{
				new_buff.temporary = true;
				new_buff.timer = turns;
			}
			new_buff.AddBuff();	
		}
    }

    public void MakeOpposingWeaponUseless()
    {
		if(HandleTrgger())
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name + "_debuff";
			new_buff.type_change = MainController.Choise.useless;
			new_buff.AddBuff();	
		}
    }

	public void DestroyOpposingWeapon()
	{
		if(HandleTrgger())
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			opponent.AddComponent<SelfDestruct>();
			opponent.GetComponent<SelfDestruct>().Destruct();	
		}
	}

	public void DebuffOpposingDamageTemporarily(int amount)
    {
		if(HandleTrgger())
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.damage_buff = -amount;
			new_buff.id = GetComponent<Weapon>() + "_debuff";
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.reminder = "-"+amount+" to damage until the end of the fight.";
			new_buff.AddBuff();	
		}
    }

    public void DebuffOpposingArmorTemporarily(int amount)
    {
		if(HandleTrgger())
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.armor_buff = -amount;
			new_buff.id = GetComponent<Weapon>() + "_debuff";
			new_buff.temporary = true;
			new_buff.timer = 1000;
			new_buff.reminder = "-"+amount+" to armor until the end of the fight.";
			new_buff.AddBuff();	
		}
    }

	public void ChangeOpposingWeaponType(int type)
	{
		if(HandleTrgger())
		{
			Weapon opponent = GetComponent<Weapon>().opponent;
			Buff new_buff = Instantiate(buff, opponent.transform).GetComponent<Buff>();
			new_buff.id = GetComponent<Weapon>().name + "_debuff";
			switch(type)
			{
				case 1: new_buff.type_change = MainController.Choise.kivi; break;
				case 2: new_buff.type_change = MainController.Choise.paperi; break;
				case 3: new_buff.type_change = MainController.Choise.sakset; break;
				case 4: new_buff.type_change = MainController.Choise.voittamaton; break;
				case 5: new_buff.type_change = MainController.Choise.useless; break;
			}
			
			new_buff.AddBuff();	
		}
	}

}
