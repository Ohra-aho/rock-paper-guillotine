using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposableHead : MonoBehaviour
{
    public MainController.Choise og_type;
    int previous_amount = 0;

    private void Awake()
    {
        og_type = GetComponent<Weapon>().type;
    }

    public void Lose()
    {
        if(GetComponent<Weapon>().type == MainController.Choise.hyödytön)
        {
            GetComponent<SelfDestruct>().Destruct();
        } else
        {
            GetComponent<Weapon>().type = MainController.Choise.hyödytön;
        }
    }

    private int CountDheads()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        int amount = 0;
        for (int i = 0; i < RIE.transform.childCount; i++)
        {
            if (RIE.transform.GetChild(i).GetComponent<DisposableHead>())
            {
                amount++;
            }
        }

        return amount;
    }

    public void CalculateDamage()
    {
        int amount = CountDheads();
        if(amount != previous_amount)
        {
            GetComponent<Weapon>().damage -= previous_amount;
            GetComponent<Weapon>().damage += amount;
            previous_amount = amount;
        }
    }
}
