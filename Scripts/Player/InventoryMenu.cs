using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] GameObject WeaponPref;
    // Start is called before the first frame update
	MainController MC;

	List<GameObject> weapons = new List<GameObject>();
	private State current = State.all;
	private enum State
	{
		rock,
		paper,
		scissors,
		other,
		all
	}

	void Awake()
	{
		weapons.AddRange(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().items);
		displayWeapons();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateHeight();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateStartAndEndPoint();
        transform.GetChild(0).GetComponent<NonUIScroll>().DetermineInitialLocation();
        transform.parent.GetComponent<Test>().PlayAnimation("OpenDrawer");
		MC = GameObject.Find("EventSystem").GetComponent<MainController>();	
	}

	void Update()
	{
		if(
			MC.game_state != MainController.State.reward && 
			MC.game_state != MainController.State.re_arming && 
			MC.game_state != MainController.State.favourite_pick
			)
		{
			//MC.game_state = MainController.State.re_arming;
		}
	}

	private void displayWeapons()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;

		List<GameObject> rocks = new List<GameObject>();
		List<GameObject> papers = new List<GameObject>();
		List<GameObject> scissors = new List<GameObject>();
		List<GameObject> unbeatables = new List<GameObject>();
		List<GameObject> useless = new List<GameObject>();
		List<GameObject> debuffs = new List<GameObject>();

		weapons.Clear();
		weapons.AddRange(player.GetComponent<PlayerInventory>().items);

		switch(current)
		{
			case State.all: 
					
					for(int i = 0; i < weapons.Count; i++)
					{
						switch(weapons[i].GetComponent<Weapon>().og_type)
						{
							case MainController.Choise.kivi: rocks.Add(weapons[i]); break;
							case MainController.Choise.paperi: papers.Add(weapons[i]); break;
							case MainController.Choise.sakset: scissors.Add(weapons[i]); break;
							case MainController.Choise.voittamaton: unbeatables.Add(weapons[i]); break;
							case MainController.Choise.useless: 
								if(weapons[i].GetComponent<Weapon>().name != "Weakness" && weapons[i].GetComponent<Weapon>().name != "Poison" && weapons[i].GetComponent<Weapon>().name != "Bleed")
								{
									useless.Add(weapons[i]); 
								} else
								{
									debuffs.Add(weapons[i]);
								}
							break;
						}
					}
					
					weapons.Clear();

					weapons.AddRange(rocks);
					weapons.AddRange(papers);
					weapons.AddRange(scissors);
					weapons.AddRange(unbeatables);
					weapons.AddRange(useless);
					weapons.AddRange(debuffs);
				break;
			case State.rock: 

				for(int i = 0; i < weapons.Count; i++)
				{
					switch(weapons[i].GetComponent<Weapon>().og_type)
					{
						case MainController.Choise.kivi: rocks.Add(weapons[i]); break;
					}
				}
				weapons.Clear();
				weapons.AddRange(rocks);
			break;
			case State.paper:

				for(int i = 0; i < weapons.Count; i++)
				{
					switch(weapons[i].GetComponent<Weapon>().og_type)
					{
						case MainController.Choise.paperi: rocks.Add(weapons[i]); break;
					}
				}
				weapons.Clear();
				weapons.AddRange(rocks);
			break;
			case State.scissors:

				for(int i = 0; i < weapons.Count; i++)
				{
					switch(weapons[i].GetComponent<Weapon>().og_type)
					{
						case MainController.Choise.sakset: rocks.Add(weapons[i]); break;
					}
				}
				weapons.Clear();
				weapons.AddRange(rocks);
			break;
			case State.other:

				for(int i = 0; i < weapons.Count; i++)
				{
					switch(weapons[i].GetComponent<Weapon>().og_type)
					{
						case MainController.Choise.voittamaton: unbeatables.Add(weapons[i]); break;
						case MainController.Choise.useless: 
							if(weapons[i].GetComponent<Weapon>().name != "Weakness" && weapons[i].GetComponent<Weapon>().name != "Poison" && weapons[i].GetComponent<Weapon>().name != "Bleed")
							{
								useless.Add(weapons[i]); 
							} else
							{
								debuffs.Add(weapons[i]);
							}
						break;
					}
				}
				weapons.Clear();

				weapons.AddRange(unbeatables);
				weapons.AddRange(useless);
				weapons.AddRange(debuffs);
			break;
		}
        List<GameObject> items = weapons;
		for(int i = items.Count-1; i >= 0; i--)
		{
			if(items[i] == null)
			{
				items.RemoveAt(i);
			}
		}
        for (int i = 0; i < items.Count; i++)
        {
			if(items[i] != null)
			{
				if(items[i].GetComponent<Weapon>())
				{
					GameObject temp = Instantiate(WeaponPref, transform.GetChild(0).GetChild(1));
					temp.GetComponent<ClaimedWeapon>().weapon = items[i];
					temp.GetComponent<ClaimedWeapon>().DispalyWeapon();
				}	
			}
        }
    }

    public void addWeapon(GameObject weapon)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerInventory>().items.Add(weapon);
        weapons.Clear();
		weapons.AddRange(player.GetComponent<PlayerInventory>().items);
        clearInventory();
        displayWeapons();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateHeight();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateStartAndEndPoint();
    }

    /*public void removeWeapon(int weapon)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerInventory>().items.RemoveAt(weapon);
		weapons.Clear();
		weapons.AddRange(player.GetComponent<PlayerInventory>().items);
        clearInventory();
        displayWeapons();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateHeight();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateStartAndEndPoint();
    }*/
	public void removeWeapon(GameObject weapon)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerInventory>().items.Remove(weapon);
		weapons.Clear();
		weapons.AddRange(player.GetComponent<PlayerInventory>().items);
        clearInventory();
        displayWeapons();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateHeight();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateStartAndEndPoint();
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
		current = State.all;
		ReconstructInventory();
	}

	public void ShowRocks()
	{
		current = State.rock;
		ReconstructInventory();
	}
	public void ShowPapers()
	{
		current = State.paper;
		ReconstructInventory();
	}
	public void ShowScissors()
	{
		current = State.scissors;
		ReconstructInventory();
	}

	public void SortOther()
	{
		current = State.other;
		ReconstructInventory();
	}
}


