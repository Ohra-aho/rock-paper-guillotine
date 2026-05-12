using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
	List<GameObject> collection = new List<GameObject>();
    private void Awake()
    {
        GetComponent<BuffController>().special = AddWeapon;
        GetComponent<BuffController>().onDestruction = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
    }

	public void AddWeapon(Weapon w)
	{
		collection.Add(Instantiate(w.gameObject));
	}

	public void GiveWeaponsBack()
	{
		for(int i = 0; i < collection.Count; i++)
		{
			GetComponent<Weapon>().player_owner.GetComponent<PlayerInventory>().AddItem(collection[i]);
			Destroy(collection[i]);
		}
		GetComponent<SelfDestruct>().Destruct();
	}
}
