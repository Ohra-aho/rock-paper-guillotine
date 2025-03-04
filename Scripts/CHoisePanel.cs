using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CHoisePanel : MonoBehaviour
{
    [HideInInspector] public string weapon_name;
    [HideInInspector] public Sprite[] character_sheet;
    public GameObject character;

    public void DisplayName()
    {
        if(transform.childCount <= 0)
        {
            for (int i = 0; i < 16; i++)
            {
                GameObject chr = Instantiate(character, transform);
                //chr.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 4;
            }
        }
        character_sheet = Resources.LoadAll<Sprite>("aakkosto");

        char[] characters = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '�', '�', '�'
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
                //transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 4;
            } catch
            {
                transform.GetChild(i-1).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                break;
            }
        }
    }
}
