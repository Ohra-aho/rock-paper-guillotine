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
        healthy = false;
        GetComponent<Test>().PlayAnimation("LoseLife");
    }

    public void heal()
    {
        healthy = true;
        GetComponent<Test>().PlayAnimation("Heal");
    }

	public void HeavyDamage()
	{
		healthy = false;
        GetComponent<Test>().PlayAnimation("HeavyDamage");
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

	public void HeavyDamageMan()
	{
		GameObject man = GameObject.Find("man");
		bool left = false;
		if(transform.parent.name == "PlayerHealth")
		{
			left = true;
		}
		if(left) man.GetComponent<SpriteRenderer>().sprite = man.GetComponent<ManAnimator>().damage_reactions[0];
		else man.GetComponent<SpriteRenderer>().sprite = man.GetComponent<ManAnimator>().damage_reactions[1];
	}

	public void HeavyDamageManEnd()
	{
		GameObject man = GameObject.Find("man");
		man.GetComponent<SpriteRenderer>().sprite = man.GetComponent<ManAnimator>().man_sheet[6];
	}
}
