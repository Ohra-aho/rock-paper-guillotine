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
    public bool individual_interactable = true;
    private MainController MC;

    private void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();
        individual_interactable = true;
    }

    private void Update()
    {
        if(MC == null)
        {
            MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        }
        /*if(interactable != MC.buttons_active)
        {
            Debug.Log("Que");
            interactable = MC.buttons_active;
        }*/
        /*if(!individual_interactable)
        {
            interactable = false;
        }*/
    }

    private void OnMouseDown()
    {
        if(press != null && interactable)
        {
            press.Invoke();
        } else if(!individual_interactable)
        {
            Debug.Log("Uninteractable");
        }
    }

    private void OnMouseOver()
    {
        if(over != null && interactable)
        {
            over.Invoke();
            GetComponent<SpriteRenderer>().color = new Color(hoverTint, hoverTint, hoverTint);
        } else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
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
