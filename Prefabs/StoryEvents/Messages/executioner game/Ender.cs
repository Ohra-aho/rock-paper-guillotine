using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ender : MonoBehaviour
{
	void Awake()
	{
		End();
	}

	public void End()
	{
		Debug.Log("QUEEEEEEEEE");
		GameObject.Find("StartButton").GetComponent<StartButton>().end = true;
		GameObject.Find("EventSystem").GetComponent<MainController>().SetNewState(MainController.State.favourite_pick);
	}
}
