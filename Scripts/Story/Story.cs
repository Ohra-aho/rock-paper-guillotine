using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public List<GameObject> events;
    //public Narrative narrative;

    StoryCheckList SCL;
    StoryController SC;

    private void Awake()
    {
        SCL = transform.parent.GetComponent<StoryCheckList>();
        SC = transform.parent.GetComponent<StoryController>();
    }

}
