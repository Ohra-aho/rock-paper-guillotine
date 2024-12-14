using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    Color full = Color.red;
    Color empty = Color.gray;

    public bool healthy = true;

    private void Start()
    {
        heal();
        //damage();
    }

    public void damage()
    {
        this.GetComponent<Image>().color = empty;
        healthy = false;
    }

    public void heal()
    {
        this.GetComponent<Image>().color = full;
        healthy = true;
    }
}
