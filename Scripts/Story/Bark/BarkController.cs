using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkController : MonoBehaviour
{
    public GameObject bark_template;

    private void Awake()
    {
        LoadBarks();
    }

    public void SaveBarks()
    {
        int amount = transform.childCount;
        Bark[] barks = new Bark[10];

        for(int i = 0; i < amount; i++)
        {
            barks[i] = transform.GetChild(i).GetComponent<Bark>();
        }

        SaveSystem.SaveBarks(barks);
    }

    public void LoadBarks()
    {
        BarkData[] barks = new BarkData[10];
        barks = SaveSystem.LoadBarks();

        for(int i = 0; i < barks.Length; i++)
        {
            if(barks[i] != null)
            {
                GameObject loaded_bark = Instantiate(bark_template, transform);
                loaded_bark.GetComponent<Bark>().trigger = barks[i].trigger;
                loaded_bark.GetComponent<Bark>().triggered = barks[i].triggered;
                loaded_bark.GetComponent<Bark>().bark = barks[i].bark;
                loaded_bark.GetComponent<Bark>().SetTrueBark(barks[i].true_bark);

                loaded_bark.GetComponent<Bark>().Inisiate();
            }
        }
    }
}
