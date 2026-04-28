using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smite : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().special = (Weapon w) =>
        {
            GetComponent<EffectDamage>().amount++;
            GetComponent<Stacking>().IncreaseStacks(1);
        };
    }
}
