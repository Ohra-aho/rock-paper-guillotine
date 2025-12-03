using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaper : MonoBehaviour
{
    bool won = false;
    public void Win()
    {
        won = true;
    }

    public void DebuffDamage()
    {
        if(won)
        {
            GetComponent<Weapon>().damage--;
            won = false;
        }
    }

    public void ResetDamage()
    {
        GetComponent<Weapon>().damage++;
    }
}
