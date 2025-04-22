using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leka : MonoBehaviour
{
    // Start is called before the first frame update
    public void WinDraws()
    {
        GetComponent<Weapon>().opponent.TakeDamage(
                GetComponent<Weapon>().damage
            );
    }
}
