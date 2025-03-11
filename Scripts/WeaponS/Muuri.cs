using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muuri : MonoBehaviour
{
    GameObject ri;

    private void Awake()
    {
        ri = GameObject.Find("Real inventory");
    }

    //might need some altering when passive buffs come to play
    public void CalculateArmor()
    {
        int amount = 0;
        for (int i = 0; i < ri.transform.childCount; i++)
        {
            if (ri.transform.GetChild(i).GetComponent<Weapon>().type == MainController.Choise.kivi)
            {
                amount++;
            }
        }
        GetComponent<Weapon>().armor = amount / 3;
    }
}
