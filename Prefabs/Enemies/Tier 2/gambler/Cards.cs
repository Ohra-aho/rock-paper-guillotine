using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public void ChangeType()
    {
        int type = Random.Range(1, 4);

        switch(type)
        {
            case 1:
                GetComponent<Weapon>().type = MainController.Choise.paperi;
                break;
            case 2:
                GetComponent<Weapon>().type = MainController.Choise.hyödytön;
                break;
            case 3:
                GetComponent<Weapon>().type = MainController.Choise.voittamaton;
                break;
        }
    }
}
