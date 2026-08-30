using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllWeaponBox : MonoBehaviour
{
	public List<GameObject> rocks;
	public List<GameObject> papers;
	public List<GameObject> scissors;
	public List<GameObject> unbeatables;
	public List<GameObject> useless;

	[HideInInspector] public List<GameObject> visible_weapons;

	private GameObject table_box;

	[SerializeField] GameObject WeaponPref;
    // Start is called before the first frame update
	MainController MC;


    public void Inisiate()
	{
		table_box = GameObject.Find("Weapon box");
		table_box.SetActive(false);
		SortInventory();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateHeight();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateStartAndEndPoint();
        transform.GetChild(0).GetComponent<NonUIScroll>().DetermineInitialLocation();
		MC = GameObject.Find("EventSystem").GetComponent<MainController>();	
	}

	public void Close()
	{
		GameObject.Find("Inventory").GetComponent<InventoryButton>().OpenDrawer();
		GameObject.Find("EventSystem").GetComponent<MainController>().game_state = MainController.State.idle;
		table_box.SetActive(true);
		Destroy(this.gameObject);
	}

	private void displayWeapons()
    {
		for(int i = visible_weapons.Count-1; i >= 0; i--)
		{
			if(visible_weapons[i] == null)
			{
				visible_weapons.RemoveAt(i);
			}
		}
        for (int i = 0; i < visible_weapons.Count; i++)
        {
			if(visible_weapons[i] != null)
			{
				if(visible_weapons[i].GetComponent<Weapon>())
				{
					GameObject temp = Instantiate(WeaponPref, transform.GetChild(0).GetChild(1));
					temp.GetComponent<FWeapon>().weapon = visible_weapons[i];
					temp.GetComponent<FWeapon>().DispalyWeapon();
				}	
			}
        }
    }

    private void clearInventory()
    {
        GameObject items = transform.GetChild(0).GetChild(1).gameObject;

        // Collect children to destroy
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < items.transform.childCount; i++)
        {
            children.Add(items.transform.GetChild(i));
        }

        // Destroy them
        foreach (Transform child in children)
        {
            DestroyImmediate(child.gameObject);
        }   
    }

    public void ReconstructInventory()
    {
        clearInventory();
        displayWeapons();
		transform.GetChild(0).GetComponent<NonUIScroll>().CalculateHeight();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateStartAndEndPoint();
    }

	public void SortInventory()
	{
		visible_weapons.Clear();
		visible_weapons.AddRange(rocks);
		visible_weapons.AddRange(papers);
		visible_weapons.AddRange(scissors);
		visible_weapons.AddRange(unbeatables);
		visible_weapons.AddRange(useless);

		ReconstructInventory();
	}
	public void ShowRocks()
	{
		visible_weapons.Clear();
		visible_weapons.AddRange(rocks);

		ReconstructInventory();
	}
	public void ShowPapers()
	{
		visible_weapons.Clear();
		visible_weapons.AddRange(papers);

		ReconstructInventory();
	}
	public void ShowScissors()
	{
		visible_weapons.Clear();
		visible_weapons.AddRange(scissors);

		ReconstructInventory();
	}
	public void ShowUnbeatables()
	{
		visible_weapons.Clear();
		visible_weapons.AddRange(unbeatables);

		ReconstructInventory();
	}
	public void ShowUseless()
	{
		visible_weapons.Clear();
		visible_weapons.AddRange(useless);

		ReconstructInventory();
	}
}
