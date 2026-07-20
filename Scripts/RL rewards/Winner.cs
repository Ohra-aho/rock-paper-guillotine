using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
	public GameObject favourites;
    public void Buff()
	{
		GameObject temp = Instantiate(favourites, transform.parent);
		temp.GetComponent<RectTransform>().position = new Vector2(0, 0);
	}
}
