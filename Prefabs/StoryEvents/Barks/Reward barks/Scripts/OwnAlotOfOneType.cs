using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnAlotOfOneType : MonoBehaviour
{
    public MainController.Choise type;
    public int threshold = 0;
    public bool exact = false;
    private void Awake()
    {
        GetComponent<RewardBark>().trigger_req = OwnThem;
    }

    public bool OwnThem()
    {
        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        int amount = 0;
        for(int i = 0; i < RI.transform.childCount; i++)
            if (RI.transform.GetChild(i).GetComponent<Weapon>().type == type)
                amount++;
        
        if (exact && amount == threshold) return true;
        return amount >= threshold;
    }
}
