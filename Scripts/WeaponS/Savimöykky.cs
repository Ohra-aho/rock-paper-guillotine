using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savimöykky : MonoBehaviour
{
	void Awake()
	{
		GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
		GetComponent<BuffController>().temporary = true;
		GetComponent<BuffController>().timer = 2;
		GetComponent<BuffController>().endPhase = true;
		GetComponent<BuffController>().special = CopyWeapon;
		GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().reminder = "After use, gives you a copy of itself.";
	}

	public void Activate()
	{
		if(GetComponent<Stacking>().stacks >= 5)
		{
			GetComponent<Stacking>().DecreaseStacks(5);
			GetComponent<BuffController>().Equip();
		}
	}

	public void CopyWeapon(Weapon w)
	{
		GameObject copy = Instantiate(w.gameObject, GameObject.FindGameObjectWithTag("RI").transform);
		copy.GetComponent<Weapon>().player = true;
		copy.GetComponent<Weapon>().name += " (Copy)";

		copy.GetComponent<Weapon>().InisiateTypeEffects();
		PlayerInventory PI = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
		PI.items.Add(copy);
		
		PI.AddBuffToNewWeapon(copy);
		GameObject event_system = GameObject.Find("EventSystem");
		event_system.GetComponent<RLController>().CheckCollector();
		event_system.GetComponent<RLController>().CheckForNeurotic();
		event_system.GetComponent<RLController>().CheckForPicky();
		event_system.GetComponent<RLController>().ApplyBuffs();

		if(GameObject.FindGameObjectWithTag("Inventory") != null)
		{
			InventoryMenu IM = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryMenu>();
			IM.ReconstructInventory();
		}
	
	}
}
