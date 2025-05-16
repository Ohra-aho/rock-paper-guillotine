using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Healing>().amount = 1;
        GetComponent<BuffController>().special = Heal;
        GetComponent<BuffController>().onDestruction = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void Heal(Weapon weapon)
    {
        GetComponent<Healing>().Heal();
    }
}
