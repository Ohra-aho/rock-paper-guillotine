using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] GameObject WeaponPref;
    // Start is called before the first frame update
	MainController MC;
    void Start()
    {
        displayWeapons();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateHeight();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateStartAndEndPoint();
        transform.GetChild(0).GetComponent<NonUIScroll>().DetermineInitialLocation();
        transform.parent.GetComponent<Test>().PlayAnimation("OpenDrawer");
		MC = GameObject.Find("EventSystem").GetComponent<MainController>();
    }

	void Update()
	{
		if(MC.game_state != MainController.State.reward && MC.game_state != MainController.State.re_arming && MC.game_state != MainController.State.favourite_pick)
		{
			MC.game_state = MainController.State.re_arming;
		}
	}

	private void displayWeapons()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        List<GameObject> items = player.GetComponent<PlayerInventory>().items;

        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].GetComponent<Weapon>())
            {
                GameObject temp = Instantiate(WeaponPref, transform.GetChild(0).GetChild(1));
                temp.GetComponent<ClaimedWeapon>().weapon = items[i];
                temp.GetComponent<ClaimedWeapon>().DispalyWeapon();
            }
        }
    }

    public void addWeapon(GameObject weapon)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerInventory>().items.Add(weapon);
        
        clearInventory();
        displayWeapons();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateHeight();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateStartAndEndPoint();
    }

    public void removeWeapon(int weapon)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerInventory>().items.RemoveAt(weapon);
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
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        List<GameObject> items = player.GetComponent<PlayerInventory>().items;

		List<GameObject> rocks = new List<GameObject>();
		List<GameObject> papers = new List<GameObject>();
		List<GameObject> scissors = new List<GameObject>();
		List<GameObject> unbeatables = new List<GameObject>();
		List<GameObject> useless = new List<GameObject>();
		List<GameObject> debuffs = new List<GameObject>();

		for(int i = 0; i < items.Count; i++)
		{
			switch(items[i].GetComponent<Weapon>().og_type)
			{
				case MainController.Choise.kivi: rocks.Add(items[i]); break;
				case MainController.Choise.paperi: papers.Add(items[i]); break;
				case MainController.Choise.sakset: scissors.Add(items[i]); break;
				case MainController.Choise.voittamaton: unbeatables.Add(items[i]); break;
				case MainController.Choise.useless: 
					if(items[i].GetComponent<Weapon>().name != "Weakness" && items[i].GetComponent<Weapon>().name != "Poison" && items[i].GetComponent<Weapon>().name != "Bleed")
					{
						useless.Add(items[i]); 
					} else
					{
						debuffs.Add(items[i]);
					}
				break;
			}
		}

		player.GetComponent<PlayerInventory>().items.Clear();
		player.GetComponent<PlayerInventory>().items.AddRange(rocks);
		player.GetComponent<PlayerInventory>().items.AddRange(papers);
		player.GetComponent<PlayerInventory>().items.AddRange(scissors);
		player.GetComponent<PlayerInventory>().items.AddRange(unbeatables);
		player.GetComponent<PlayerInventory>().items.AddRange(useless);
		player.GetComponent<PlayerInventory>().items.AddRange(debuffs);

		ReconstructInventory();
	}
}
