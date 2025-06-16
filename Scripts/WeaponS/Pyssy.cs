using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyssy : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Stacking>().stack_limit = 6;
    }
    public void IncreaseStack()
    {
        //if(GetComponent<Stacking>().stacks <= 6)
        //{
            GetComponent<Stacking>().IncreaseStacks(1);
            CalculateDamage();
            /*if (GetComponent<Weapon>().damage < 0)
            {
                GetComponent<Weapon>().damage = 0;
            }*/

            if(GetComponent<Weapon>().player)
            {
                if (GetComponent<Weapon>().damage == 0)
                {
                    GetComponent<SelfDestruct>().Destruct();
                }
            }
            
        //}
    }

    public void CalculateDamage()
    {
        GetComponent<Weapon>().damage = 6 - GetComponent<Stacking>().stacks;
    }
}
