using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penetrating : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Weapon>().penetrating = true;
    }
}
