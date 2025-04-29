using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardIncrease : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>().reward_tier++;
        GetComponent<StoryEvent>().over = true;
    }
}
