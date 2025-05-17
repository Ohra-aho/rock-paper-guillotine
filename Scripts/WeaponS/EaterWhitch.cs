using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaterWhitch : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().special = Heal;
        GetComponent<BuffController>().victory = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }

    public void Heal(Weapon weapon)
    {
        GetComponent<Healing>().Heal();
    }
}
