using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public List<GameObject> possible_weapons;
    public void Chosen()
    {
        GainRandomWeapon();   
    }

    private void GainRandomWeapon()
    {
        GameObject.Find("EventSystem").GetComponent<MainController>().collector = true;
    }
}
