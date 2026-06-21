using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siili : MonoBehaviour
{
	public void Breatch()
	{
		GetComponent<Weapon>().damage++;
	}

	
}
