using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
	public void Chosen()
    {
        GainRandomWeapon();   
    }

    private void GainRandomWeapon()
    {
        GameObject.Find("EventSystem").GetComponent<MainController>().winner = true;
    }
}
