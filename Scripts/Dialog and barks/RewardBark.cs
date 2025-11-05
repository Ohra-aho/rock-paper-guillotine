using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBark : MonoBehaviour
{
    public string bark;
    public string triggering_weapon;
    public MainController.Choise triggering_type;
    public delegate bool TriggerReq();
    public TriggerReq trigger_req;

    public void Activate()
    {
        if(trigger_req != null)
        {
            if (trigger_req.Invoke())
            {
                GameObject bh = GameObject.Find("BarkHolder");
                GameObject new_bark = Instantiate(bh.GetComponent<BarkController>().bark_template, bh.transform);
                new_bark.GetComponent<Bark>().SetTrueBark(bark);
                new_bark.GetComponent<Bark>().TheBark();
            }
        } else
        {
            GameObject bh = GameObject.Find("BarkHolder");
            GameObject new_bark = Instantiate(bh.GetComponent<BarkController>().bark_template, bh.transform);
            new_bark.GetComponent<Bark>().SetTrueBark(bark);
            new_bark.GetComponent<Bark>().TheBark();
        }
        
        Destroy(this.gameObject);
    }
}
