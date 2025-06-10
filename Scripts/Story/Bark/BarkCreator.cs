using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkCreator : MonoBehaviour
{
    public GameObject bark;

    private void Awake()
    {
        GameObject new_bark = Instantiate(bark, GameObject.Find("BarkHolder").transform);
        new_bark.GetComponent<Bark>().Inisiate();
        GetComponent<StoryEvent>().over = true;
    }
}
