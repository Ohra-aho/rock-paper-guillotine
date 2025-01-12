using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NonUIScroll : MonoBehaviour
{
    public InputAction scroll;
    public GameObject scrollable;
    public float scroll_speed;

    private bool active = false;

    private Vector2 scroll_direction;
    private Vector2 starting_localPosition;
    private Vector2 end_localPosition;

    private void OnEnable()
    {
        scroll.Enable();
    }

    private void OnDisable()
    {
        scroll.Disable();
    }

    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }

    public bool IsActive()
    {
        return active;
    }

    public void CalculateHeight()
    {
        float child_height = 0;
        if (scrollable.transform.childCount > 0) {
            child_height = scrollable.GetComponent<GridLayoutGroup>().cellSize.y;
        };

        scrollable.GetComponent<RectTransform>().sizeDelta = new Vector2(
            scrollable.GetComponent<RectTransform>().sizeDelta.x,
            child_height * ((scrollable.transform.childCount/2) + scrollable.transform.childCount % 2)
        );

        scrollable.GetComponent<RectTransform>().localPosition 
            = new Vector2(
                scrollable.GetComponent<RectTransform>().localPosition.x,
                -scrollable.GetComponent<RectTransform>().sizeDelta.y / 2f + child_height*2
            );

        starting_localPosition = scrollable.GetComponent<RectTransform>().localPosition;

        end_localPosition = new Vector2(
            scrollable.GetComponent<RectTransform>().localPosition.x,
            -starting_localPosition.y - GetComponent<RectTransform>().sizeDelta.y / 2 + child_height * 2
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        //CalculateHeight();
    }

    // Update is called once per frame
    void Update()
    {

        if (active)
        {
           
            scroll_direction = -scroll.ReadValue<Vector2>();
            float current_y = scrollable.GetComponent<RectTransform>().localPosition.y;

            if (current_y == starting_localPosition.y)
            {
                
                if(scroll_direction.y > 0)
                {
                    scrollable.GetComponent<RectTransform>().localPosition
                        = new Vector2(
                            scrollable.GetComponent<RectTransform>().localPosition.x,
                            current_y + scroll_direction.y * scroll_speed
                          );
                    //Debug.Log(scrollable.GetComponent<RectTransform>().localPosition);
                }
            } else if(current_y == end_localPosition.y)
            {
                if(scroll_direction.y < 0)
                {
                    scrollable.GetComponent<RectTransform>().localPosition
                        = new Vector2(
                            scrollable.GetComponent<RectTransform>().localPosition.x,
                            current_y + scroll_direction.y * scroll_speed
                            );
                }
            } else
            {
                scrollable.GetComponent<RectTransform>().localPosition
                    = new Vector2(
                        scrollable.GetComponent<RectTransform>().localPosition.x,
                        current_y + scroll_direction.y * scroll_speed
                        );
            }

            
        }
        if (scrollable.GetComponent<RectTransform>().localPosition.y > end_localPosition.y)
        {
            scrollable.GetComponent<RectTransform>().localPosition = end_localPosition;
        }
        if (scrollable.GetComponent<RectTransform>().localPosition.y < starting_localPosition.y)
        {
            scrollable.GetComponent<RectTransform>().localPosition = starting_localPosition;
        }
        

    }
}
