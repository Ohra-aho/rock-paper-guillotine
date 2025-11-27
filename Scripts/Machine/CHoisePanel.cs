using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class CHoisePanel : MonoBehaviour
{
    public string weapon_name;
    public int index;
    [HideInInspector] public Sprite[] character_sheet;
    public GameObject character;
    public Weapon weapon;
    MainController MC;

    public List<Sprite> icons;

    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
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
            transform.GetChild(1).GetComponent<Test>().PlayAnimation("Hide");
        } else
        {
            transform.GetChild(1).GetComponent<Test>().PlayAnimation("Reveal");
        }

        if(weapon_name != null && weapon_name != "")
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
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'å', 'ä', 'ö'
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
                ClearName();
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
            GameObject info = GameObject.Find("Canvas").transform.GetChild(9).gameObject;
            info.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon_name;
            info.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.GiveEffectiveDamage().ToString();
            info.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.GiveEffectiveArmor().ToString();
            if (weapon.GetComponent<Stacking>()) {
                info.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(200f, 40f);
                info.transform.GetChild(1).GetComponent<RectTransform>().localScale = new Vector2(0.75f, 0.75f);
                info.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
                info.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Stacking>().stacks.ToString(); 
            } else
            {
                info.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(144f, 40f);
                info.transform.GetChild(1).GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
                info.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
            }
            info.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = weapon.description;

            switch(weapon.type)
            {
                case MainController.Choise.kivi:
                    info.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[0];
                    break;
                case MainController.Choise.paperi:
                    info.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[1];
                    break;
                case MainController.Choise.sakset:
                    info.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[2];
                    break;
                case MainController.Choise.hyödytön:
                    info.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[3];
                    break;
                case MainController.Choise.voittamaton:
                    info.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[4];
                    break;
            }

            info.SetActive(true);
        }
    }

    public void DissapearInfo()
    {
        if (weapon_name != "" && weapon_name != null)
        {
            GameObject info = GameObject.Find("Canvas").transform.GetChild(9).gameObject;
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
}
