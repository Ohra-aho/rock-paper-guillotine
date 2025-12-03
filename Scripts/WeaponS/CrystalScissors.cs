using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScissors : MonoBehaviour
{
    public void HalfDamage()
    {
        if(GetComponent<Weapon>().damage <= 1)
        {
            GetComponent<SelfDestruct>().Destruct();
        } else
        {
            GetComponent<Weapon>().damage = GetComponent<Weapon>().damage / 2;
        }
    }
}
