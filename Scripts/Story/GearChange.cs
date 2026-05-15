using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearChange : MonoBehaviour
{
    MainController MC;
    private void Update()
    {
		if(GameObject.Find("PlayerWheelHolder").GetComponent<PlayerWheelHolder>().detached)
		{
			GameObject.Find("Inventory").GetComponent<Button>().onClick.Invoke();
		}

        if(MC.game_state == MainController.State.idle)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().unlocked_wheel++;
            GameObject.Find("Machine").GetComponent<Test>().PlayAnimation("gearChange");
            GetComponent<StoryEvent>().over = true;
        }
    }
    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
    }
}
