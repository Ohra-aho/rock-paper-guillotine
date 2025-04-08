using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CHoisePanel : MonoBehaviour
{
    public string weapon_name;
    public int index;
    [HideInInspector] public Sprite[] character_sheet;
    public GameObject character;

    public void DisplayName()
    {
        if(weapon_name != null)
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
                    transform.GetChild(i - 1).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                    break;
                }
            }
        } else
        {
            if (transform.childCount <= 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    GameObject chr = Instantiate(character, transform);
                    transform.GetChild(i - 1).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                }
            }
        }
    }

    public void Choise()
    {
        if(weapon_name != "" && weapon_name != null)
        {
            Debug.Log(index);
            transform.parent.GetComponent<PlayerContoller>().MakeAChoise(index);
        }
    }
}
