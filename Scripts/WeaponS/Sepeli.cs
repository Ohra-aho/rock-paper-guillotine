using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sepeli : MonoBehaviour
{
    GameObject ri;

    private void Awake()
    {
        ri = GameObject.Find("Real inventory");
    }

    public void CalculateDamage()
    {
        int amount = 0;
        for(int i = 0; i < ri.transform.childCount; i++)
        {
            if(ri.transform.GetChild(i).GetComponent<Weapon>().type == MainController.Choise.kivi)
            {
                amount++;
            }
        }
        GetComponent<Weapon>().damage = 1 + amount / 3;
    }
}
