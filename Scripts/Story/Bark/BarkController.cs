using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkController : MonoBehaviour
{
    public GameObject bark_template;
    public GameObject reward_bark_template;

    public void ActivateInstantBark(string bark)
    {
        GameObject new_bark = Instantiate(bark_template, transform);
        new_bark.GetComponent<Bark>().bark = bark;
        new_bark.GetComponent<Bark>().immediate = true;
        new_bark.GetComponent<Bark>().Inisiate();
    }

    public void ActivateExecutionerBark(string bark)
    {
        GameObject new_bark = Instantiate(bark_template, transform);
        new_bark.GetComponent<Bark>().bark = bark;
        new_bark.GetComponent<Bark>().executioner = true;
        new_bark.GetComponent<Bark>().immediate = true;
        new_bark.GetComponent<Bark>().Inisiate();
    }

    public void ActivatePriorityBark(string bark)
    {
        GameObject new_bark = Instantiate(bark_template, transform);
        new_bark.GetComponent<Bark>().bark = bark;
        new_bark.GetComponent<Bark>().immediate = true;
        new_bark.GetComponent<Bark>().priority = true;
        new_bark.GetComponent<Bark>().Inisiate();
    }
}
