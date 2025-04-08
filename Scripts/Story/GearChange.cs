using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearChange : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().unlocked_wheel++;
        GameObject.Find("Machine").GetComponent<Test>().PlayAnimation("gearChange");
    }
}
