using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barker : MonoBehaviour
{
    public LanguageController LG;
    string[] barks = new string[1];

    private void Start()
    {
        barks[0] = LG.instructions[3];
    }

    public void SetUpTriggerBark(int bark, string trigger)
    {
        GameObject.Find(trigger).GetComponent<NonUIButton>().press.AddListener(
            () => GetComponent<ManAnimator>().CreateABark(barks[bark])
        );
    }
}
