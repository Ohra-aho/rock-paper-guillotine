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
    private Vector2 starting_position;
    private Vector2 end_position;

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

    private void CalculateHeight()
    {
        float child_height = 0;
        if (scrollable.transform.childCount > 0) {
            child_height = scrollable.GetComponent<GridLayoutGroup>().cellSize.y;
        };

        scrollable.GetComponent<RectTransform>().sizeDelta = new Vector2(
            scrollable.GetComponent<RectTransform>().sizeDelta.x,
            child_height * ((scrollable.transform.childCount/2) + scrollable.transform.childCount % 2)
        );

        scrollable.GetComponent<RectTransform>().position 
            = new Vector2(
                scrollable.GetComponent<RectTransform>().position.x,
                -scrollable.GetComponent<RectTransform>().sizeDelta.y / 2f + child_height
            );

        starting_position = scrollable.GetComponent<RectTransform>().position;
        end_position = new Vector2(
            scrollable.GetComponent<RectTransform>().position.x,
            -starting_position.y - GetComponent<RectTransform>().sizeDelta.y / 2
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        CalculateHeight();
    }

    // Update is called once per frame
    void Update()
    {

        if (active)
        {
           
            scroll_direction = -scroll.ReadValue<Vector2>();
            float current_y = scrollable.GetComponent<RectTransform>().position.y;

            if (current_y == starting_position.y)
            {
                if(scroll_direction.y > 0)
                {
                    scrollable.GetComponent<RectTransform>().position
                        = new Vector2(
                            scrollable.GetComponent<RectTransform>().position.x,
                            current_y + scroll_direction.y * scroll_speed
                          );
                }
            } else if(current_y == end_position.y)
            {
                if(scroll_direction.y < 0)
                {
                    scrollable.GetComponent<RectTransform>().position
                        = new Vector2(
                            scrollable.GetComponent<RectTransform>().position.x,
                            current_y + scroll_direction.y * scroll_speed
                            );
                }
            } else
            {
                scrollable.GetComponent<RectTransform>().position
                    = new Vector2(
                        scrollable.GetComponent<RectTransform>().position.x,
                        current_y + scroll_direction.y * scroll_speed
                        );
            }

            
        }
        if (scrollable.GetComponent<RectTransform>().position.y > end_position.y)
        {
            scrollable.GetComponent<RectTransform>().position = end_position;
        }
        if (scrollable.GetComponent<RectTransform>().position.y < starting_position.y)
        {
            scrollable.GetComponent<RectTransform>().position = starting_position;
        }
        

    }
}
