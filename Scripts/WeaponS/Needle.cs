using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Healing>().amount = 1;
    }

    public void Heal()
    {
        GetComponent<Healing>().Heal();
    }
}
