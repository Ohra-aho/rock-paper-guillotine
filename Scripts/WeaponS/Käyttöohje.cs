using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Käyttöohje : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return weapon.gameObject.GetComponent<SelfDestruct>(); };
    }
}
