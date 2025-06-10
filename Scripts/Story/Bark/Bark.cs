using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public string trigger;
    public bool triggered;

    public int bark;

    string true_bark;


    private void Awake()
    {
       
    }

    public void Inisiate()
    {
        TrueBark();
        SetUpTrigger();
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
        switch(bark)
        {
            case 1:
                try
                {
                    GameObject.Find(trigger).GetComponent<NonUIButton>().press.RemoveListener(TheBark);
                }
                catch
                {
                    Debug.Log("No trigger or something");
                }
                break;
            case 2:
                try
                {
                    GameObject.Find(trigger).GetComponent<NonUIButton>().press.RemoveListener(StartButtonDectivate);
                }
                catch
                {
                    Debug.Log("No trigger or something");
                }
                break;

                }
    }

    public void SetUpTrigger()
    {
        switch (bark)
        {
            case 1: GameObject.Find(trigger).GetComponent<NonUIButton>().press.AddListener(TheBark); break;
            case 2: GameObject.Find(trigger).GetComponent<NonUIButton>().press.AddListener(StartButtonDectivate); break;
        }
    }

    public void TheBark()
    {
        Debug.Log(true_bark);
        GameObject.Find("man").GetComponent<ManAnimator>().CreateABark(true_bark);
        triggered = true;
    }

    public void StartButtonDectivate()
    {
        if(!GameObject.Find("StartButton").GetComponent<StartButton>().isActive)
        {
            GameObject.Find("man").GetComponent<ManAnimator>().CreateABark(true_bark);
            triggered = true;
        }
    }

    private void TrueBark()
    {
        switch(bark)
        {
            case 1: true_bark = LanguageController.dialog[8]; break;
            case 2: true_bark = LanguageController.dialog[9]; break;
        }
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
