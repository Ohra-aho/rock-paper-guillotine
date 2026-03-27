using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaper : MonoBehaviour
{
    bool won = false;
    int debuff = 0;
    public void Win()
    {
        won = true;
    }

    public void DebuffDamage()
    {
        if(won)
        {
            GetComponent<Weapon>().damage--;
            if (GetComponent<Weapon>().damage < 0) GetComponent<Weapon>().damage = 0;
            else debuff++;
            won = false;
        }
    }

    public void ResetDamage()
    {
        GetComponent<Weapon>().damage += debuff;
    }
}
