using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class Heart : MonoBehaviour
{

    public bool healthy = true;

    private void Start()
    {
        heal();
    }

    public void damage()
    {
        GetComponent<Test>().PlayAnimation("LoseLife");
        healthy = false;
    }

    public void heal()
    {
        GetComponent<Test>().PlayAnimation("Heal");
        healthy = true;
    }
}
