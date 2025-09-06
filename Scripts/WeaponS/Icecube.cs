using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icecube : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = Dectrease;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != GetComponent<Weapon>().name; };
    }

    public void Dectrease(Weapon w)
    {
        GetComponent<Stacking>().DecreaseStacks(1);
    }

    public void Used()
    {
        if(GetComponent<Stacking>().stacks == 0)
        {
            GetComponent<SelfDestruct>().Destruct();
        } else
        {
            GetComponent<Stacking>().IncreaseStacks(1);
        }
    }
}
