using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm : MonoBehaviour
{
    public GameObject buff;
    public void MakeSmiteUnbeatable()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            if(RIE.transform.GetChild(i).GetComponent<Smite>())
            {
                Buff new_buff = Instantiate(buff, RIE.transform.GetChild(i)).GetComponent<Buff>();
                new_buff.id = GetComponent<Weapon>().name;
                new_buff.type_change = MainController.Choise.voittamaton;
                new_buff.until_used = true;
                new_buff.temporary = true;
                new_buff.AddBuff();
                break;
            }
        }
    }
}
