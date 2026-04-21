using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanaticWeapons : MonoBehaviour
{
    public void TurnGranadeUseless()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Weapon>().name == "Granade")
            {
                RIE.transform.GetChild(i).GetComponent<Weapon>().type = MainController.Choise.hyödytön;
                break;
            }
        }
    }
}
