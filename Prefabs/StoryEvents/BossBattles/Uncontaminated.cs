using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncontaminated : MonoBehaviour
{
    public void UnlockRamdonStartingWeapon()
    {
        if (GameObject.Find("EventSystem").GetComponent<RLController>().picks == 0)
        {
            GameObject.Find("EventSystem").GetComponent<RLController>().picks++;
        }
    }
}
