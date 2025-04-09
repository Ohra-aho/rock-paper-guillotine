using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hover : MonoBehaviour
{
    public bool disabled = false;
    public UnityEvent hoverEnter;
    public UnityEvent hoverExit;

    private bool hovering;

    private void Update()
    {
        if(disabled && hovering)
        {
            hoverExit.Invoke();
            hovering = false;
        }
    }

    private void OnMouseEnter()
    {
        if(!disabled)
        {
            if (!hovering)
            {
                hovering = true;
                hoverEnter.Invoke();
            }
        }
    }

    private void OnMouseExit()
    {
        if (!disabled)
        {
            if (hovering)
            {
                hovering = false;
                hoverExit.Invoke();
            }
        }
    }

    
}
