using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = AddPoints;
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().gain_points = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.GetComponent<Stacking>(); };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
    }

    public void AddPoints(Weapon w)
    {
        w.GetComponent<Stacking>().stacks += 2;
        if(w.GetComponent<Stacking>().stack_limit > 0 && w.GetComponent<Stacking>().stacks > w.GetComponent<Stacking>().stack_limit)
        {
            w.GetComponent<Stacking>().stacks = w.GetComponent<Stacking>().stack_limit;
        }
    }
}
