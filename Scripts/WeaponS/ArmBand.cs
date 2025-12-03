using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBand : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().armor_bonus = 1;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.type == MainController.Choise.hyödytön; };
    }
}
