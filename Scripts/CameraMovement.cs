using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float pan_limit = 0.3f;
    float speed = 0.02f;
    float move_trigger = 7f;

    public bool disabled = false;
    // Update is called once per frame
    void Update()
    {
        if(!disabled)
        {
            float m_x = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition).x;
            float m_y = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition).y;
            if (m_x > move_trigger || m_x < -move_trigger || m_y > move_trigger || m_y < -move_trigger)
            {
                float distance = Mathf.Sqrt((m_x * m_x + m_y * m_y));
                if (m_x > move_trigger && transform.position.x < pan_limit)
                {
                    transform.position = new Vector3(transform.position.x + m_x / distance * (speed / 2), transform.position.y, transform.position.z);
                }
                else if (m_x < -move_trigger && transform.position.x > -pan_limit)
                {
                    transform.position = new Vector3(transform.position.x + m_x / distance * (speed / 2), transform.position.y, transform.position.z);
                }
            }
            else if (m_x < move_trigger && m_x > -move_trigger && transform.position != new Vector3(0, 0, -1))
            {
                float distance = Mathf.Sqrt((m_x * m_x + m_y * m_y));
                transform.position = new Vector3(transform.position.x - transform.position.x * speed, transform.position.y - transform.position.y * speed, transform.position.z);
            }
        }
        
    }
}
