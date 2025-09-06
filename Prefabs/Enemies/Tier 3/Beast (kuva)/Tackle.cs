using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackle : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().penetrating = true;
        GetComponent<BuffController>().draw_winner = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != this.GetComponent<Weapon>().name; };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 1;
    }

    public void ApplyBuffs()
    {
        GetComponent<BuffController>().Equip();
    }
}
