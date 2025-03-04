using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopper : MonoBehaviour
{
    bool stop;
    MainController mc;
    // Start is called before the first frame update
    void Start()
    {
        mc = GameObject.Find("EventSystem").GetComponent<MainController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mc.stop != stop)
        {
            stop = mc.stop;
            GoThroughAllChildren(this.gameObject, !stop);
        }
    }

    public void GoThroughAllChildren(GameObject target, bool stop)
    {
        StopInteractions(target, stop);
        int children = target.transform.childCount;
        for(int i = 0; i < children; i++)
        {
            GoThroughAllChildren(target.transform.GetChild(i).gameObject, stop);
        }
    }

    public void StopInteractions(GameObject target, bool stop)
    {
        if (target.GetComponent<Button>())
        {
            Debug.Log(target.name);
            target.GetComponent<Button>().interactable = stop;
        }
        if(target.GetComponent<NonUIButton>())
        {
            Debug.Log(target.name);
            target.GetComponent<NonUIButton>().interactable = stop;
        }
        if(target.GetComponent<NonUIScroll>())
        {
            //GetComponent<NonUIScroll>().interactable = stop;
        }

    }
}
