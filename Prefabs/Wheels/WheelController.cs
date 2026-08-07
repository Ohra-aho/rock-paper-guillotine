using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    MainController MC;

    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
    }

    public void DetachingWheel()
    {
        if(!MC.CompareState(MainController.State.re_arming) && !MC.CompareState(MainController.State.favourite_pick))
        {
            MC.SetNewState(MainController.State.re_arming);
        }
    }

    public void AttachingWheel()
    {
        if (!MC.CompareState(MainController.State.idle))
        {
            MC.SetNewState(MainController.State.idle);
        }
    }

	public void HighLight()
	{
		for(int i = 0; i < transform.childCount-1; i++)
		{
			transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().HighLight();
		}
	}

	public void EndHighLight()
	{
		for(int i = 0; i < transform.childCount-1; i++)
		{
			transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().EndHighLight();
		}
	}
}
