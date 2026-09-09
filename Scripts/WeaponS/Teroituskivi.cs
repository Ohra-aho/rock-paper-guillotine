using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teroituskivi : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.GiveEffectiveType() == MainController.Choise.sakset; };
		GetComponent<BuffController>().draw = true;
		GetComponent<BuffController>().special = (Weapon w) => { w.GetComponent<EffectDamage>().DealSetDamage(1); };
    }

}
