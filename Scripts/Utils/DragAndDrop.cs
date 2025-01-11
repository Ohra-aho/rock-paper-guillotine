using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    Image image;
    GameObject Parent;
    [HideInInspector] public Transform OGParent;
    Vector2 offset;
    public bool remove = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("draggg");

        OGParent = transform.parent;
        Parent = transform.parent.parent.parent.parent.parent.gameObject;
        transform.SetParent(Parent.transform);
        Parent.transform.GetChild(0).GetComponent<InventoryMenu>().removeWeapon(OGParent.transform.GetSiblingIndex());
        image = GetComponent<Image>();
        image.raycastTarget = false;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            GetComponent<RectTransform>(), 
            eventData.position,
            eventData.pressEventCamera, 
            out offset
        );
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            GetComponent<RectTransform>().parent as RectTransform, 
            eventData.position, 
            eventData.pressEventCamera, 
            out Vector2 localPos
        );
        GetComponent<RectTransform>().localPosition = localPos - offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!remove)
        {
            Parent.transform.GetChild(0).GetComponent<InventoryMenu>()
                .addWeapon(this.gameObject.GetComponent<ClaimedWeapon>().weapon);
            remove = false;
        }
        Destroy(this.gameObject);

    }
    
}
