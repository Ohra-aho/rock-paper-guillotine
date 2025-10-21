using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncontaminated : MonoBehaviour
{
    public void UnlockRamdonStartingWeapon()
    {
        GameObject.Find("EventSystem").GetComponent<RLController>().achievements.Add("decontaminated");
    }
}
