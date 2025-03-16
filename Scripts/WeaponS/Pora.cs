using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pora : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Weapon>().penetrating = true;
    }
}
