using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonIgnoreChildren : Button
{
    //Add to gameObject instead of the button component
    public override void OnPointerClick(PointerEventData eventData)
    {
        // Check if the click target is the button itself and not a child
        if (eventData.pointerEnter == gameObject)
        {
            base.OnPointerClick(eventData);
        }
    }
}
