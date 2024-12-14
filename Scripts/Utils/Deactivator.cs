using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deactivator : MonoBehaviour
{
    public List<GameObject> targets;

    public void Deactivate(GameObject target)
    {
        target.GetComponent<Button>().interactable = false;
    }

    public void Activate(GameObject target)
    {
        target.GetComponent<Button>().interactable = true;
    }

    public void DeactivateAll()
    {
        for(int i = 0; i < targets.Count; i++)
        {
            Deactivate(targets[i]);
        }
    }

    public void ActivateAll()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            Activate(targets[i]);
        }
    }
}
