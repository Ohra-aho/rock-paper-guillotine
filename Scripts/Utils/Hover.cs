using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hover : MonoBehaviour
{
    public UnityEvent hoverEnter;
    public UnityEvent hoverExit;

    private bool hovering;

    private void OnMouseEnter()
    {
        if(!hovering)
        {
            hovering = true;
            hoverEnter.Invoke();
        }
    }

    private void OnMouseExit()
    {
        if (hovering)
        {
            hovering = false;
            hoverExit.Invoke();
        }
    }

    private void OnMouseOver()
    {
    }
}
