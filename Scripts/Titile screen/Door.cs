using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject musicPlayer;

    public void Interact()
    {
        if(GameObject.Find("EventSystem").GetComponent<StoryCheckList>().executioner_dead)
        {
            transform.parent.parent.GetComponent<Test>().PlayAnimation("start_2");
        }
        else
        {
            transform.parent.parent.GetComponent<Test>().PlayAnimation("start");
        }
    }

}
