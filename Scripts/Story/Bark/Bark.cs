using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public string trigger;
    public bool triggered;

    public string bark;

    string true_bark;

    public bool on_startbutton_activate;
    public bool on_startbutton_de_activate;
    public bool immediate = false;
    public bool priority = false;


    private void Awake()
    {
       
    }

    public void Inisiate()
    {
        TrueBark();
        SetUpTrigger();
        if (immediate) TheBark();
    }

    private void Update()
    {
        if(triggered)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if(on_startbutton_activate)
        {
            try
            {
                GameObject.Find(trigger).GetComponent<NonUIButton>().press.RemoveListener(TheBark);
            }
            catch
            {
                Debug.Log("No trigger or something");
            }
        }
        if(on_startbutton_de_activate)
        {
            try
            {
                GameObject.Find(trigger).GetComponent<NonUIButton>().press.RemoveListener(StartButtonDectivate);
            }
            catch
            {
                Debug.Log("No trigger or something");
            }
        }
    }

    public void SetUpTrigger()
    {
        if(on_startbutton_activate)
        {
            GameObject.Find(trigger).GetComponent<NonUIButton>().press.AddListener(TheBark);
        }
        if(on_startbutton_de_activate)
        {
            GameObject.Find(trigger).GetComponent<NonUIButton>().press.AddListener(StartButtonDectivate);
        }
    }

    //Plays the bark without conditions
    public void TheBark()
    {
        GameObject.Find("man").GetComponent<ManAnimator>().CreateABark(true_bark, priority);
        triggered = true;
    }

    //Activates if start button deactivates
    public void StartButtonDectivate()
    {
        if(!GameObject.Find("StartButton").GetComponent<StartButton>().isActive)
        {
            GameObject.Find("man").GetComponent<ManAnimator>().CreateABark(true_bark, priority);
            triggered = true;
        }
    }

    //Remenant of worse days
    private void TrueBark()
    {
        true_bark = bark;
    }

    public string GiveTrueBark()
    {
        if (true_bark != null) return true_bark;
        else return "";
    }

    public void SetTrueBark(string new_true_bark)
    {
        true_bark = new_true_bark;
    }
}
