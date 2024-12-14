using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public string name = "Item";
    public bool oneTimeUse;
    public Sprite sprite;
    public UnityEvent ImmediateEffect;
    
    public void EmptyEffect()
    {
        Debug.Log("Ei tee mit‰‰n");
    }
}
