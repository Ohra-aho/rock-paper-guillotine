using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class WeaponSprite : MonoBehaviour
{
    public List<Sprite> symbols;
	public List<Sprite> tiers;
	public Sprite highlight;
    public GameObject weapon;
    public int id;

    private GameObject visibleInfo;
    public GameObject Info;
	public GameObject reminder;

	public void HighLight()
	{
		if(weapon == null)
		{
			GetComponent<SpriteRenderer>().sprite = highlight;
			GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0.5f);
		}
	}

	public void EndHighLight()
	{
		if(weapon == null)
		{
			GetComponent<SpriteRenderer>().sprite = null;
			GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 1f);
		}
	}

    public void displaySprite()
    {
        if(weapon != null)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<Weapon>().sprite;
            transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<Weapon>().sprite;
			GetComponent<SpriteRenderer>().sprite = tiers[weapon.GetComponent<Weapon>().GetAscension()];
			if(GameObject.Find("EventSystem").GetComponent<StoryController>().museum_active) GetComponent<SpriteRenderer>().sprite = tiers[0];
            switch(weapon.GetComponent<Weapon>().og_type)
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
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().DisplayChoises();
        } else
        {
            GetComponent<SpriteRenderer>().sprite = null;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = null;
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().DisplayChoises();
        }
		ActivateAnyEquips();
    }

    //Annoying, but nessessary
    public void RemoveSprite()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = null;
    }

    void OnMouseDown()
    {
        GameObject wheelHolder = transform.parent.parent.parent.gameObject;
        if (wheelHolder.GetComponent<PlayerWheelHolder>().detached && weapon != null)
        {
            Unequip();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.GiveAwarning();
        }
    }

    public void Unequip()
    {
        PlayerContoller player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
        if (GameObject.Find("InventoryMenu(Clone)"))
        {
            GameObject.Find("InventoryMenu(Clone)").GetComponent<InventoryMenu>().addWeapon(weapon);
        } else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().items.Add(weapon);
        }
        player.UnequipWeapon(weapon.GetComponent<Weapon>());
        weapon = null;
        //player.DisplayChoises();
        displaySprite();
        DestroyInfo();
        transform.parent.GetChild(1).GetComponent<DropDetector>().PlayAudio(6);
    }

    public void DisplayInfo()
    {
        GameObject wheelHolder = transform.parent.parent.parent.gameObject;

        if (wheelHolder.GetComponent<PlayerWheelHolder>().detached && weapon != null)
        {
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

            if (weapon != null)
            {
                visibleInfo.transform.GetChild(0)
                    .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().name;
                visibleInfo.transform.GetChild(1).GetChild(0)
                    .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().GiveEffectiveDamage().ToString();
                visibleInfo.transform.GetChild(1).GetChild(1)
                    .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().GiveEffectiveArmor().ToString();

                if (weapon.GetComponent<Stacking>())
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
    }

    public void DestroyInfo()
    {
        if(visibleInfo != null) Destroy(visibleInfo);
    }

	public void ActivateAnyEquips()
	{
		GameObject wheel = transform.parent.parent.gameObject;
		for(int i = 0; i < wheel.transform.childCount-1; i++)
		{
			if(wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
			{
				wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().any_equip.Invoke();	
			}
		}
	}
}
