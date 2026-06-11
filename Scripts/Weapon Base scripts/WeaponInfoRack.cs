using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfoRack : MonoBehaviour
{
    public GameObject info;
	public bool open = false;
	bool to_be_cleared = false;
    // Start is called before the first frame update

	public void ToggleOpen()
	{
		open = !open;
	}
    public void SpawnWeaponInfo(Weapon weapon)
    {
		for(int i = 0; i < transform.childCount; i++)
		{
			if(transform.GetChild(i).GetComponent<WeaponWard>().weapon == null)
			{
				transform.GetChild(i).GetComponent<WeaponWard>().weapon = weapon;
				transform.GetChild(i).GetComponent<WeaponWard>().DisplayWeapon();
				break;
			}
		}
    }

    public void ClearInfoRack()
    {
		//to_be_cleared = true;
    }

	public void TrueClear()
	{
		if(to_be_cleared)
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				transform.GetChild(i).GetComponent<WeaponWard>().ClearWeapon();
			}
		}
		to_be_cleared = false;
	}

	public void TelegraphWeapons(List<int> pair)
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			if(transform.GetChild(i).GetComponent<WeaponWard>().telegraphing)
			{
				for(int j = 0; j < pair.Count; j++)
				{
					if(i != pair[j])
					{
						transform.GetChild(i).GetComponent<WeaponWard>().ResetTelegraph();
						break;
					}
				}
			}
		}
		for(int i = 0; i < pair.Count; i++)
		{
			transform.GetChild(pair[i]).GetComponent<WeaponWard>().Telegraph();
		}
	}

	public void ResetTelegraphs()
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			if(transform.GetChild(i).GetComponent<WeaponWard>().telegraphing)
			{
				transform.GetChild(i).GetComponent<WeaponWard>().ResetTelegraph();
			}
		}
	}

}
