using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FWeapon : MonoBehaviour
{
    public GameObject weapon;
    private GameObject visibleInfo;
    public GameObject Info;
	public GameObject reminder;
    public List<Sprite> symbols;
    public List<Sprite> tiers;

    public bool disabled;

	[HideInInspector] public MainController MC;

    private void Awake()
    {
		MC = GameObject.Find("EventSystem").GetComponent<MainController>();
		
    }

    public void DispalyWeapon()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<Weapon>().sprite;
        transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<Weapon>().sprite;
		GetComponent<SpriteRenderer>().sprite = tiers[weapon.GetComponent<Weapon>().GetAscension()];
        switch(weapon.GetComponent<Weapon>().type)
        {
            case MainController.Choise.kivi:
                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = symbols[0];
                break;
            case MainController.Choise.paperi:
                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = symbols[1];
                break;
            case MainController.Choise.sakset:
                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = symbols[2];
                break;
            case MainController.Choise.useless:
                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = symbols[3];
                break;
            case MainController.Choise.voittamaton:
                transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = symbols[4];
                break;
        }
    }

    public void DisplayInfo()
    {
        
        if(GameObject.Find("EventSystem").GetComponent<MainController>().buttons_active)
        {
            //transform.parent.parent.GetComponent<NonUIScroll>().Activate(); //Crude but works

            visibleInfo = Instantiate(Info, GameObject.Find("Canvas").transform);
            visibleInfo.transform.position =
                Camera.main.ScreenToWorldPoint(
                    new Vector3(
                        Input.mousePosition.x + 100,
                        Input.mousePosition.y,
                        Camera.main.nearClipPlane
                    )
                );

            //Display actual info into the popup

            visibleInfo.transform.GetChild(0)
                .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().name;

            visibleInfo.transform.GetChild(1).GetChild(0)
                .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().GiveEffectiveDamage().ToString();
            visibleInfo.transform.GetChild(1).GetChild(1)
                .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().GiveEffectiveArmor().ToString();
            if(weapon.GetComponent<Stacking>())
            {
                visibleInfo.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
                visibleInfo.GetComponent<RectTransform>().GetChild(1).localScale = new Vector2(0.9f, 0.9f);
                visibleInfo.transform.GetChild(1).GetChild(2)
                    .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Stacking>().stacks.ToString();
            }

            visibleInfo.transform.GetChild(2)
                .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().description;
			
			if(weapon.transform.childCount > 0)
			{
				for(int i = 0; i < weapon.transform.childCount; i++)
				{
					if(weapon.transform.GetChild(0).GetComponent<Buff>().reminder != "")
					{
						GameObject new_reminder =  Instantiate(reminder, visibleInfo.transform.GetChild(4));
						new_reminder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.transform.GetChild(0).GetComponent<Buff>().reminder;
					}
				}
			}
        }

    }

    public void DestroyInfo()
    {
        Destroy(visibleInfo);
        //transform.parent.parent.GetComponent<NonUIScroll>().Deactivate(); //Crude but works
    }


    private void OnMouseDown()
    {
		Pick();
		DestroyInfo();
		Destroy(this.gameObject);
    }

	private void Pick()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().AddItem(weapon);
		transform.parent.GetComponent<FavouriteMenu>().WeaponPicked();
	}
}
