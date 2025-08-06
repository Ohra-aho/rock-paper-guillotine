using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructEnforcer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Hand>())
        {
            collision.GetComponent<Hand>().ClearWeapon();
        }
    }
}
