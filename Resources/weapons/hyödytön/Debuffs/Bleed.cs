using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : MonoBehaviour
{
    public void TakeDamage()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.TakeDamage(1);
    }
}
