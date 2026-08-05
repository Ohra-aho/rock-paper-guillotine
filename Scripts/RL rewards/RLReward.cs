using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Unity.VisualScripting;

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

	MainController MC;
    GameObject info;

	public bool dont_load;

    private void Awake()
    {
        
    }

	void Update()
	{
		bool active = GameObject.Find("EventSystem").GetComponent<RLController>().achievements_active;
		bool force_deactive = GameObject.Find("EventSystem").GetComponent<RLController>().game_started;
		if(force_deactive)
		{
			active = false;
		}
		if(active)
		{
			EnableReward();
		} else 
		{
			DisableReward();
		}
	}

	public void Inisiate()
	{
		info = GameObject.Find("Canvas").transform.GetChild(15).gameObject;
        GetComponent<NonUIButton>().over.AddListener(ShowInfo);
        GetComponent<NonUIButton>().exit.AddListener(HideInfo);
		MC = GameObject.Find("EventSystem").GetComponent<MainController>();
		GetComponent<NonUIButton>().Inisiate();
	}

    public void DisableReward()
    {
        if(GetComponent<BoxCollider2D>()) Destroy(GetComponent<BoxCollider2D>());
    }

	public void EnableReward()
	{
		if(!GetComponent<BoxCollider2D>()) gameObject.AddComponent<BoxCollider2D>();
	}

    public bool CheckIfCanBePicked()
    {
		return true;
        RLController rlc = GameObject.Find("EventSystem").GetComponent<RLController>();
        if (rlc.chosen_buffs.Count < rlc.picks)
        {
            return true;
        }
        else return false;
    }

    public void ChangeSprite()
    {	
        if(!chosen && CheckIfCanBePicked())
        {
			chosen = true;
            GetComponent<SpriteRenderer>().sprite = image_2;
            GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Add(this.gameObject);
        } else if(chosen)
        {
			chosen = false;
            GetComponent<SpriteRenderer>().sprite = image_1;
            GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Remove(this.gameObject);
        }
    }

    public void ShowInfo()
    {
        if(GameObject.Find("EventSystem").GetComponent<RLController>().picks > 0 && MC.game_state != MainController.State.re_arming)
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

	public void Load()
	{
		GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Add(gameObject);
		activate.Invoke();
		buffing.Invoke();
		GetComponent<SpriteRenderer>().sprite = image_2;
	}

}
