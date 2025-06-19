using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    MainController MC;

    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
    }

    public void DetachingWheel()
    {
        if(!MC.CompareState(MainController.State.re_arming))
        {
            MC.SetNewState(MainController.State.re_arming);
        }
    }

    public void AttachingWheel()
    {
        if (!MC.CompareState(MainController.State.idle))
        {
            MC.SetNewState(MainController.State.idle);
        }
    }
}
