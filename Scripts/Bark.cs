using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public string trigger;
    public bool triggered;

    public int bark;

    string true_bark;

    LanguageController LG;

    private void Awake()
    {
        LG = GameObject.Find("EventSystem").GetComponent<LanguageController>();
        SetTrueBark();
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

    private void SetTrueBark()
    {
        switch(bark)
        {
            case 1: true_bark = LG.instructions[3]; break;
            case 2: true_bark = LG.instructions[4]; break;
        }
    }
}
