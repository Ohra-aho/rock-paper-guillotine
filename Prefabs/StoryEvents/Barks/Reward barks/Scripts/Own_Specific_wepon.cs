using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Own_Specific_wepon : MonoBehaviour
{
    public string name;
    private void Awake()
    {
        GetComponent<RewardBark>().trigger_req = OwnIt;
    }

    public bool OwnIt()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        for(int i = 0; i < RI.transform.childCount; i++)
            if(RI.transform.GetChild(i).GetComponent<Weapon>().name == name)
                return true;

        return false;
    }

}
