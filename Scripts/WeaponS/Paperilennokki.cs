using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paperilennokki : MonoBehaviour
{
    private void Update()
    {
        if(!GetComponent<Weapon>().penetrating) GetComponent<Weapon>().penetrating = true;
    }
    private void Awake()
    {
        GetComponent<Weapon>().penetrating = true;
    }
}
