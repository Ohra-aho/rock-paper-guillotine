using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BarkData
{
    public string trigger;
    public bool triggered;
    public int bark;
    public string true_bark;
    //Bark needs an ID for saving an loading
    public BarkData(Bark b)
    {
        true_bark = b.GiveTrueBark();
        trigger = b.trigger;
        //bark = b.bark;
        triggered = b.triggered;
    }
}
