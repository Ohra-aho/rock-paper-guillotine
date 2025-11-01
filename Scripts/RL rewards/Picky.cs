using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picky : MonoBehaviour
{
    public void Chosen()
    {
        GameObject.Find("Reward reroll").GetComponent<RewardReroll>().unlocked = true;
    }
}
