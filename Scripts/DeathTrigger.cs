using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void Awake()
    {
        GameObject.Find("The Q").GetComponent<Test>().PlayAnimation("Lose");
        GetComponent<StoryEvent>().over = true;
    }
}
