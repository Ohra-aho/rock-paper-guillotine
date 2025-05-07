using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolveri : MonoBehaviour
{
    public void Debuff()
    {
        GetComponent<Weapon>().damage -= 2;
        if(GetComponent<Weapon>().damage < 0)
        {
            GetComponent<Weapon>().damage = 0;
        }
    }
}
