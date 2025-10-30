using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RLReward : MonoBehaviour
{
    public UnityEvent buffing;
    public UnityEvent victory_effect;

    public void DisableReward()
    {
        Destroy(GetComponent<BoxCollider2D>());
    }

    public void EnableReward()
    {
        this.gameObject.AddComponent<BoxCollider2D>();
    }

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
