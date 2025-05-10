using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kirous : MonoBehaviour
{
    public void IncreaseStack()
    {
        GetComponent<Weapon>().damage++;
    }
}
