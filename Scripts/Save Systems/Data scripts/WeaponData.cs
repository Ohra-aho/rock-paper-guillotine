using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public string name;
    public string type;

    public WeaponData(Weapon weapon)
    {
        name = weapon.name;
        switch(weapon.type)
        {
            case MainController.Choise.kivi: type = "kivi"; break;
            case MainController.Choise.paperi: type = "paperi"; break;
            case MainController.Choise.sakset: type = "sakset"; break;
            case MainController.Choise.hyödytön: type = "hyödytön"; break;
            case MainController.Choise.voittamaton: type = "voittamaton"; break;
        }

    }
}
