using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragNDrop : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;

    private Vector3 originalPosition;

    public bool destroyOnDrop;
    public bool resetOnDrop;

    public UnityEvent onBeginDrag;
    public UnityEvent onEndDrag;

    private bool over = false;
    private GameObject objectOver;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        // Calculate the offset between the mouse position and the object's position
        offset = transform.position - GetMouseWorldPosition();
        originalPosition = transform.position;
        PlayAudio(0);
    }

    private void OnMouseDrag()
    {
        if(onBeginDrag != null) onBeginDrag.Invoke();

        // Update the object's position to follow the mouse, adjusted by the offset
        transform.position = GetMouseWorldPosition() + offset;
    }

    private void OnMouseUp()
    {
        if (destroyOnDrop)
        {
            Destroy(this.gameObject);
        } else if(resetOnDrop)
        {
            transform.position = originalPosition;
        }

        if (onEndDrag != null) onEndDrag.Invoke();
        if (objectOver != null)
        {
            objectOver.GetComponent<DropDetector>().OnDrop();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<DropDetector>())
        {
            over = true;
            objectOver = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<DropDetector>())
        {
            over = false;
            objectOver = null;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<DropDetector>())
        {
            over = true;
            objectOver = other.gameObject;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z); // Set Z to camera's distance
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }

    private int LastIndex()
    {
        int index = transform.childCount - 1;
        if (index < 0) index = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Stupid>())
            {
                return i;
            }
        }
        return index;
    }

    public void PlayAudio(int clip)
    {
        transform.GetChild(LastIndex()).GetChild(clip).GetComponent<AudioPlayer>().PlayClip();
    }
}
