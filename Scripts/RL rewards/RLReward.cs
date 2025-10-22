using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RLReward : MonoBehaviour
{
    public bool continuous;
    public UnityEvent buffing;
    public bool CheckIfCanBePicked()
    {
        RLController rlc = GameObject.Find("EventSystem").GetComponent<RLController>();
        if (rlc.chosen_buffs.Count < rlc.picks)
        {
            return true;
        }
        else return false;
    }
}
