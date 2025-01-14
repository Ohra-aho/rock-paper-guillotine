using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CHoisePanel : MonoBehaviour
{
    /*[HideInInspector] public char[] characters = {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
        'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'å', 'ä', 'ö'
    };*/
    [HideInInspector] public string weapon_name;
    [HideInInspector] public Sprite[] character_sheet;

    // Start is called before the first frame update
    void Start()
    {
        //DisplayName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayName()
    {
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
        for(int i = 0; i < divided_name.Length; i++)
        {
            //Debug.Log(divided_name[i]);
        }
        for (int i = 0; i < divided_name.Length; i++)
        {
            int index = Array.IndexOf(characters, divided_name[i]);
            transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = character_sheet[index];
            transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
    }
}
