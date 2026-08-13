using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class CHoisePanel : MonoBehaviour
{
    public string weapon_name = "";
    public int index;
    [HideInInspector] public Sprite[] character_sheet;
    public GameObject character;
    public Weapon weapon;
    MainController MC;
	
	bool buff_on = false;
	bool debuff_on = false;

    public List<Sprite> icons;
	private GameObject lights;

    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
		lights = transform.GetChild(3).gameObject;
    }

    private void Update()
    {
        if(MC.game_state == MainController.State.in_battle && (weapon != null || weapon_name != ""))
        {
            GetComponent<NonUIButton>().interactable = true;
        } else
        {
            GetComponent<NonUIButton>().interactable = false;
        }
    }

    public void DisplayName()
    {
        if (weapon == null)
        {
            weapon_name = "";
            transform.GetChild(1).GetComponent<Test>().PlayAnimation("SilentHide");
        } else
        {
            transform.GetChild(1).GetComponent<Test>().PlayAnimation("Reveal");
        }

        if(weapon_name.Length > 0)
        {
            GetComponent<NonUIButton>().interactable = true;

            if (transform.GetChild(2).childCount <= 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    GameObject chr = Instantiate(character, transform.GetChild(2));
                }
            }
            character_sheet = Resources.LoadAll<Sprite>("aakkosto");

            char[] characters = {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '�', '�', '�'
            };
            char[] divided_name = weapon_name.ToLower().ToCharArray();
            for (int i = 0; i < transform.GetChild(2).childCount; i++)
            {
                transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            }
            for (int i = 0; i < divided_name.Length; i++)
            {
                try
                {
                    int index = Array.IndexOf(characters, divided_name[i]);
                    transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = character_sheet[index];
                }
                catch
                {
                    if(i < transform.GetChild(2).childCount)
                    {
                        transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                    }
                }
            }
        } else
        {
            GetComponent<NonUIButton>().interactable = false;
            if (transform.GetChild(2).childCount <= 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    GameObject chr = Instantiate(character, transform.GetChild(2));
                    transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                }
            } else
            {
                SilentClear();
            }
        }
    }

    public void ClearName()
    {
        if (MC.game_state != MainController.State.re_arming)
        {
            transform.GetChild(1).GetComponent<Test>().PlayAnimation("Hide");
        }
        else TrueClear();
    }

	public void SilentClear()
	{
		if (MC.game_state != MainController.State.re_arming)
        {
            transform.GetChild(1).GetComponent<Test>().PlayAnimation("SilentHide");
        }
        else TrueClear();
	}

    public void TrueClear()
    {
        if(weapon_name == "")
        {
            for (int i = 0; i < transform.GetChild(2).childCount; i++)
            {
                transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }

    public void PlayAudio()
    {
        if(MC.game_state == MainController.State.re_arming)
        {
            transform.GetChild(1).GetComponent<Test>().PlayAudio(0);
        }
    }

    public void Choise()
    {
        if(!transform.parent.gameObject.GetComponent<PlayerContoller>().spinning && MC.game_state == MainController.State.in_battle)
        {
            if (weapon_name != "" && weapon_name != null)
            {
                transform.parent.GetComponent<PlayerContoller>().MakeAChoise(index);
                GetComponent<Hover>().hoverExit.Invoke();
                transform.parent.gameObject.GetComponent<PlayerContoller>().spinning = true;
            }
        }
    }

    public void DisplayInfo()
    {
        if(weapon_name != "" && weapon_name != null)
        {
            GameObject info = GameObject.Find("Canvas").transform.GetChild(10).gameObject;
            info.GetComponent<WeaponInfo>().weapon = weapon;
            info.SetActive(true);
        }
    }

    public void DissapearInfo()
    {
        if (weapon_name != "" && weapon_name != null)
        {
            GameObject info = GameObject.Find("Canvas").transform.GetChild(10).gameObject;
            info.SetActive(false);
            info.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            info.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            info.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            info.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(144f, 40f);
            info.transform.GetChild(1).GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
            info.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
            info.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            info.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
        }
    }

	public void ResetBuffing()
	{
		buff_on = false;
		debuff_on = false;
	}

	public void DisplayBuffing()
	{
		
		bool buff_found = false;
		bool debuff_found = false;

		for(int i = 0; i < weapon.transform.childCount; i++)
		{
			if(weapon.transform.GetChild(i).GetComponent<Buff>().visible_buff)
			{
				buff_found = true;
			}
			if(weapon.transform.GetChild(i).GetComponent<Buff>().visible_debuff)
			{
				debuff_found = true;
			}
		}

		if(buff_found != buff_on || debuff_found != debuff_on)
		{
			if(buff_found && debuff_found)
			{
				lights.GetComponent<Test>().PlayAnimation("buff_and_debuff_on");
			} else if(buff_found)
			{
				lights.GetComponent<Test>().PlayAnimation("buff_on");
			} else if(debuff_found)
			{
				lights.GetComponent<Test>().PlayAnimation("debuff_on");
			} else
			{
				TurnOffBuffIndicator();
			}
			buff_on = buff_found;
			debuff_on = debuff_found;	
		}
	}

	public void TurnOffBuffIndicator()
	{
		if(buff_on && debuff_on)
		{
			lights.GetComponent<Test>().PlayAnimation("buff_and_debuff_off");
		} else if(buff_on)
		{
			lights.GetComponent<Test>().PlayAnimation("buff_off");
		} else if(debuff_on)
		{
			lights.GetComponent<Test>().PlayAnimation("debuff_off");
		}
		ResetBuffing();
	}
}
