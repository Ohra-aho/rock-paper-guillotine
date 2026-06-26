using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealitySmasher : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().destructive = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 2;
        GetComponent<BuffController>().special_apply = true;
		GetComponent<BuffController>().reminder = "After use, destroys itself.";
    }

    private void OnDestroy()
    {
        GetComponent<BuffController>().Unequip();
    }
}
