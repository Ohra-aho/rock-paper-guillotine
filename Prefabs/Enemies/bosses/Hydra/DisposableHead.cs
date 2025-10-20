using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposableHead : MonoBehaviour
{
    public int ID = 0;
    public MainController.Choise og_type;
    int previous_amount = 0;

    private void Awake()
    {
        og_type = GetComponent<Weapon>().type;
    }

    private void Update()
    {
        /*GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<DisposableHead>())
            {
                if (RIE.transform.GetChild(i).gameObject == this.gameObject) Debug.Log("This found");
            }
        }*/
    }

    public void Lose()
    {
        if(GetComponent<Weapon>().type == MainController.Choise.hy�dyt�n)
        {
            GetComponent<SelfDestruct>().Destruct();
        } else
        {
            GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
            GetComponent<Weapon>().type = MainController.Choise.hy�dyt�n;
            for(int i = 0; i < RIE.transform.childCount; i++)
            {
                if(RIE.transform.GetChild(i).gameObject == this.gameObject)
                {
                    for(int j = 0; j < RIE.transform.GetChild(i).transform.childCount; j++)
                    {
                        Debug.Log(RIE.transform.GetChild(i).GetChild(j).GetComponent<Buff>().id);
                        if (RIE.transform.GetChild(i).GetChild(j).GetComponent<Buff>().id == "Poison breath")
                        {
                            RIE.transform.GetChild(i).GetChild(j).GetComponent<Buff>().RemoveBuff();
                            Destroy(RIE.transform.GetChild(i).GetChild(j).gameObject);
                            Debug.Log("Que?");
                            break;
                        }
                    }
                    break;
                }
                
            }
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
