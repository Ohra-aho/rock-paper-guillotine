using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    public int amount;

    public void Victory()
    {
        amount--;
        Debug.Log(amount);
        if(amount <= 0)
        {
            GetComponent<StoryEvent>().over = true;
        }
    }
}
