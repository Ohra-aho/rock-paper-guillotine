using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkCreator : MonoBehaviour
{
    public GameObject bark;

    private void Awake()
    {
        Instantiate(bark, GameObject.Find("BarkHolder").transform);
        GetComponent<StoryEvent>().over = true;
    }
}
