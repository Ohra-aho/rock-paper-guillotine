using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rend : MonoBehaviour
{
    public void IncreaseDamage()
    {
        GetComponent<Weapon>().damage++;
    }
}
