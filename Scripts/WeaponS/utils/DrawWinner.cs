using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWinner : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Weapon>().draw.AddListener(WinDraws);
    }

    public void WinDraws()
    {
        GetComponent<Weapon>().opponent.TakeDamage(
                GetComponent<Weapon>().damage
            );
        if(GetComponent<Weapon>().win != null) GetComponent<Weapon>().win.Invoke();
    }
}
