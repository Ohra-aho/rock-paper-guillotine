using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaper : MonoBehaviour
{
    public GameObject buff;
    bool won = false;
    public void Win()
    {
        won = true;
    }

    public void Debuff()
    {
        if (won) 
        {
            Buff new_buff = Instantiate(buff, transform).GetComponent<Buff>();
            new_buff.id = GetComponent<Weapon>().name + "_debuff";
            new_buff.damage_buff = -1;
            new_buff.temporary = true;
            new_buff.timer = 1000;
            new_buff.AddBuff();
        }
        won = false;
    }
}
