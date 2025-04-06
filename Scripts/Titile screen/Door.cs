using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject musicPlayer;

    public void Interact()
    {
        transform.parent.parent.GetComponent<Test>().PlayAnimation("start");
    }

}
