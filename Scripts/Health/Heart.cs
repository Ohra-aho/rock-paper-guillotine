using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class Heart : MonoBehaviour
{

    public bool healthy = true;

    MainController MC;

    private void Start()
    {
        MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
    }

    private void Update()
    {
        if(MC.game_state == MainController.State.in_battle)
        {
            if (healthy)
            {
                if (transform.GetChild(0).GetComponent<Light2D>().intensity == 0)
                {
                    heal();
                }
            }
            else
            {
                if (transform.GetChild(0).GetComponent<Light2D>().intensity == 2)
                {
                   damage();
                }
            }
        }
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

    public void UtilEmpty()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.39f, 0.39f, 0.39f);
        transform.GetChild(0).GetComponent<Light2D>().intensity = 0;
        healthy = false;
    }

    public void UtilFull()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
        transform.GetChild(0).GetComponent<Light2D>().intensity = 2;
        healthy = true;
    }
}
