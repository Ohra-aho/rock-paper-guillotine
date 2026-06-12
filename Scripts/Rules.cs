using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    bool revealed = false;

	public void Press()
	{
		if(revealed)
		{
			GetComponent<Test>().PlayAnimation("Hide");
			revealed = false;
		} else
		{
			GetComponent<Test>().PlayAnimation("Reveal");
			revealed = true;
		}
	}
}
