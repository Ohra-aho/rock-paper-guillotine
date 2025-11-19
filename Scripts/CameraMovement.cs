using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float pan_limit = 0.3f;
    float speed = 0.003f;
    float move_trigger = 3f;

    public bool disabled = false;
    // Update is called once per frame

    GameObject background;

    private void Start()
    {
        background = GameObject.Find("main screen background");
    }

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
                    Vector3 pos = new Vector3(transform.position.x + m_x / distance/3 * (speed * Time.deltaTime * Screen.width), transform.position.y, transform.position.z);
                    transform.position = pos;
                    background.transform.position = new Vector3(pos.x*0.3f, background.transform.position.y, 0);
                }
                else if (m_x < -move_trigger && transform.position.x > -pan_limit)
                {
                    Vector3 pos = new Vector3(transform.position.x + m_x / distance/3 * (speed*Time.deltaTime*Screen.width), transform.position.y, transform.position.z);
                    transform.position = pos;
                    background.transform.position = new Vector3(pos.x*0.3f, background.transform.position.y, 0);
                }
            }
            else if (m_x < move_trigger && m_x > -move_trigger && transform.position != new Vector3(0, 0, -1))
            {
                Vector3 pos = new Vector3(transform.position.x - transform.position.x * (speed * Time.deltaTime * Screen.width), transform.position.y - transform.position.y * speed, transform.position.z);
                transform.position = pos;
                background.transform.position = new Vector3(pos.x*0.3f, background.transform.position.y, 0);
            }
        }
        
    }
}
