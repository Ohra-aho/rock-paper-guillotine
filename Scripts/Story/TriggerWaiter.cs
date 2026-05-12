using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerWaiter : MonoBehaviour
{
    // Find button by name and attaches a ItsOver event to it.

    public string name;
    void Awake()
    {
        GameObject.Find(name).GetComponent<NonUIButton>().press.AddListener(ItsOver);
		if(name == "PlayerWheelHolder") GameObject.Find("Inventory").GetComponent<Button>().onClick.AddListener(ItsOver);
    }

    public void ItsOver()
    {
        GameObject.Find(name).GetComponent<NonUIButton>().press.RemoveListener(ItsOver);
		if(name == "PlayerWheelHolder") GameObject.Find("Inventory").GetComponent<Button>().onClick.AddListener(ItsOver);
        GetComponent<StoryEvent>().over = true;
    }
}
