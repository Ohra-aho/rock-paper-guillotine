using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NonUIButton : MonoBehaviour
{
    public UnityEvent press;
    public UnityEvent over;
    public UnityEvent exit;
    public float hoverTint = 0.5f;
    public bool interactable = true;

    private void OnMouseDown()
    {
        if(press != null && interactable)
        {
            press.Invoke();
        }
    }

    private void OnMouseOver()
    {
        if(over != null)
        {
            over.Invoke();
            GetComponent<SpriteRenderer>().color = new Color(hoverTint, hoverTint, hoverTint);
        }
    }

    private void OnMouseExit()
    {
        if(exit != null)
        {
            exit.Invoke();
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
    }
}
