using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Weapon>().penetrating = true;
        GetComponent<BuffController>().special = SelfDamage;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
    }

    public void SelfDamage(Weapon weapon)
    {
        GetComponent<Weapon>().opponent = this.GetComponent<Weapon>();
        GetComponent<Weapon>().TakeDamage(1);
    }
}
