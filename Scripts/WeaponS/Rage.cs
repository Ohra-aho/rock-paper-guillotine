using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().lose = true;
        GetComponent<BuffController>().special = GainStack;
    }

    public void GainStack(Weapon w)
    {
        GetComponent<Stacking>().IncreaseStacks(1);
        if(GetComponent<Stacking>().stacks >= 3)
        {
            GetComponent<Weapon>().type = MainController.Choise.voittamaton;
        }
    }

    public void UseStaks()
    {
        GetComponent<Stacking>().DecreaseStacks(3);
        if (GetComponent<Stacking>().stacks < 3)
        {
            GetComponent<Weapon>().type = MainController.Choise.sakset;
        }
    }
}
