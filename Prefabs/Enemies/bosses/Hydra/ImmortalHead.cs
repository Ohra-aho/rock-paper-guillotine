using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmortalHead : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().special = Healing;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
    }

    public void Healing(Weapon w)
    {
        GetComponent<Healing>().Heal();
    }

    public void Regrow()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");

        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            GameObject child = RIE.transform.GetChild(i).gameObject;
            if(child.GetComponent<Weapon>().type == MainController.Choise.hyödytön)
            {
                child.GetComponent<Weapon>().type = child.GetComponent<DisposableHead>().og_type;
                break;
            }
        }
    }
}
