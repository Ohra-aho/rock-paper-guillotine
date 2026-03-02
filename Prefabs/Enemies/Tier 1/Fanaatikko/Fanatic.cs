using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fanatic : MonoBehaviour
{
    public int curse_timer = 0;
    bool curse_armor_bonus = false;
    bool off_balance_triggered = false;

    GameObject RIE;
    private void Awake()
    {
        RIE = GameObject.FindGameObjectWithTag("RIE");
    }
}
