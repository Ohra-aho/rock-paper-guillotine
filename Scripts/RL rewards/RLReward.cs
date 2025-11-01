using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class RLReward : MonoBehaviour
{
    public string name;
    public string description;

    public UnityEvent buffing;
    public UnityEvent victory_effect;
    public UnityEvent activate;

    public bool chosen = false;

    public Sprite image_1;
    public Sprite image_2;

    GameObject info;

    private void Awake()
    {
        info = GameObject.Find("Canvas").transform.GetChild(14).gameObject;
        GetComponent<NonUIButton>().over.AddListener(ShowInfo);
        GetComponent<NonUIButton>().exit.AddListener(HideInfo);
    }

    public void DisableReward()
    {
        Destroy(GetComponent<BoxCollider2D>());
    }

    public void EnableReward()
    {
        this.gameObject.AddComponent<BoxCollider2D>();
    }

    public bool CheckIfCanBePicked()
    {
        RLController rlc = GameObject.Find("EventSystem").GetComponent<RLController>();
        if (rlc.chosen_buffs.Count < rlc.picks)
        {
            return true;
        }
        else return false;
    }

    public void ChangeSprite()
    {
        chosen = !chosen;
        if(chosen && CheckIfCanBePicked())
        {
            GetComponent<SpriteRenderer>().sprite = image_2;
            GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Add(this.gameObject);
        } else if(!chosen)
        {
            GetComponent<SpriteRenderer>().sprite = image_1;
            GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Remove(this.gameObject);
        }
    }

    public void ShowInfo()
    {
        if(GameObject.Find("EventSystem").GetComponent<RLController>().picks > 0)
        {
            info.SetActive(true);
            info.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = name;
            info.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = description;
        }
    }

    public void HideInfo()
    {
        info.SetActive(false);
    }

}
