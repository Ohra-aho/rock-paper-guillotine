using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CHoisePanel : MonoBehaviour
{
    public string weapon_name;
    public int index;
    [HideInInspector] public Sprite[] character_sheet;
    public GameObject character;
    public Weapon weapon;

    private void Update()
    {
        GetComponent<NonUIButton>().individual_interactable 
            = transform.parent.parent.parent.GetComponent<Machine>().choise_panel_active;
    }

    public void DisplayName()
    {
        if(weapon_name != null && weapon_name != "")
        {
            if (transform.childCount <= 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    GameObject chr = Instantiate(character, transform);
                }
            }
            character_sheet = Resources.LoadAll<Sprite>("aakkosto");

            char[] characters = {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'å', 'ä', 'ö'
            };
            char[] divided_name = weapon_name.ToLower().ToCharArray();
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            }
            for (int i = 0; i < divided_name.Length; i++)
            {
                try
                {
                    int index = Array.IndexOf(characters, divided_name[i]);
                    transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = character_sheet[index];
                }
                catch
                {
                    if(i < transform.childCount)
                    {
                        transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                    }
                }
            }
        } else
        {
            if (transform.childCount <= 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    GameObject chr = Instantiate(character, transform);
                    transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                }
            }
        }
    }

    public void ClearName()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    public void Choise()
    {
        if(weapon_name != "" && weapon_name != null)
        {
            transform.parent.GetComponent<PlayerContoller>().MakeAChoise(index);
        }
    }

    public void DisplayInfo()
    {
        if(weapon_name != "" && weapon_name != null)
        {
            GameObject info = GameObject.Find("Canvas").transform.GetChild(8).gameObject;
            info.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon_name;
            info.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.damage.ToString();
            info.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.armor.ToString();
            info.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = weapon.description;
            info.SetActive(true);
        }
    }

    public void DissapearInfo()
    {
        if (weapon_name != "" && weapon_name != null)
        {
            GameObject info = GameObject.Find("Canvas").transform.GetChild(8).gameObject;
            info.SetActive(false);
            info.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            info.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            info.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            info.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "";
        }
    }
}
