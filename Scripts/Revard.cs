using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Revard : MonoBehaviour
{
    GameObject player;
    public GameObject actualReward;
    public GameObject Info;

    private GameObject visibleInfo;

    public bool disabled = false;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Invoke()
    {
        if (actualReward.GetComponent<Weapon>())
        {
            GetComponent<SpriteRenderer>().sprite = actualReward.GetComponent<Weapon>().sprite;
        }
        else if (actualReward.GetComponent<Item>())
        {
            GetComponent<SpriteRenderer>().sprite = actualReward.GetComponent<Item>().sprite;
        }
    }

    public void Chosen()
    {
        player.GetComponent<PlayerInventory>().AddItem(actualReward);
        //Get rid of info
        if(visibleInfo != null) DestroyInfo();
        
        if(actualReward.GetComponent<Item>())
        {
            actualReward.GetComponent<Item>().ImmediateEffect.Invoke();
        }
        transform.parent.parent.GetComponent<Test>().UnPauseAnimation();
        Destroy(gameObject);
        GameObject.Find("Roope").GetComponent<Test>().UnPauseAnimation();
    }

    public void DisplayInfo()
    {
        visibleInfo = Instantiate(Info, GameObject.Find("Canvas").transform);
        visibleInfo.transform.position = 
            Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Input.mousePosition.x+100, 
                    Input.mousePosition.y, 
                    Camera.main.nearClipPlane
                )
            );

        //Display actual info into the popup
        if(actualReward.GetComponent<Weapon>())
        {
            visibleInfo.transform.GetChild(0)
                .GetComponent<TextMeshProUGUI>().text = actualReward.GetComponent<Weapon>().name;
            visibleInfo.transform.GetChild(1)
                .GetComponent<TextMeshProUGUI>().text = "V: "+actualReward.GetComponent<Weapon>().damage.ToString();
            visibleInfo.transform.GetChild(2)
                .GetComponent<TextMeshProUGUI>().text = "P: "+actualReward.GetComponent<Weapon>().armor.ToString();
            visibleInfo.transform.GetChild(3)
                .GetComponent<TextMeshProUGUI>().text = actualReward.GetComponent<Weapon>().description;
        } else if(actualReward.GetComponent<Item>())
        {
            visibleInfo.transform.GetChild(0)
                .GetComponent<TextMeshProUGUI>().text = actualReward.GetComponent<Item>().name;
        }
    }

    public void DestroyInfo()
    {
        Destroy(visibleInfo);
    }

    void OnMouseDown()
    {
        if(!disabled) Chosen(); // T‰h‰n vois pist‰‰ jotain, ett‰ jos ottaa useamman kuin yhden niin kuolee
        transform.parent.parent.GetComponent<RewardMenu>().DisableRewards();
    }


}
