using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStreak : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = Stacking;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void Stacking(Weapon w)
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        if(MC.won != null)
        {
            if(MC.won == true)
            {
                GetComponent<Stacking>().IncreaseStacks(1);
                if (GetComponent<Stacking>().stacks == 3)
                {
                    GetComponent<EffectDamage>().DealDamage(w);
                    GetComponent<Stacking>().stacks = 0;
                }
            } else {
                GetComponent<Stacking>().stacks = 0;
            }
        } else
        {
            GetComponent<Stacking>().stacks = 0;
        }

    }
}
