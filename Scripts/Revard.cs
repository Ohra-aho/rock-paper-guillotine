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

    public bool disabled = true;
    private MainController MC;

    public List<Sprite> symbols;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (MC == null)
        {
            MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        }
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
        if(MC.buttons_active)
        {
            player.GetComponent<PlayerInventory>().AddItem(actualReward);
            //Get rid of info
            if (visibleInfo != null) DestroyInfo();

            if (actualReward.GetComponent<Item>())
            {
                actualReward.GetComponent<Item>().ImmediateEffect.Invoke();
            }
            transform.parent.parent.GetComponent<Test>().UnPauseAnimation();
            Destroy(gameObject);
            GameObject.Find("Roope").GetComponent<Test>().UnPauseAnimation();
        }
    }

    public void DisplayInfo()
    {
        if (MC.buttons_active)
        {
            visibleInfo = Instantiate(Info, GameObject.Find("Canvas").transform);
            visibleInfo.transform.position =
                Camera.main.ScreenToWorldPoint(
                    new Vector3(
                        Input.mousePosition.x + 100,
                        Input.mousePosition.y,
                        Camera.main.nearClipPlane
                    )
                );

            //Display actual info into the popup
            if (actualReward.GetComponent<Weapon>())
            {
                visibleInfo.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(68, 26);
                visibleInfo.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(-11f, 57.3f);

                visibleInfo.transform.GetChild(0)
                    .GetComponent<TextMeshProUGUI>().text = actualReward.GetComponent<Weapon>().name;
                visibleInfo.transform.GetChild(1).GetChild(0)
                    .GetComponent<TextMeshProUGUI>().text = actualReward.GetComponent<Weapon>().damage.ToString();
                visibleInfo.transform.GetChild(1).GetChild(1)
                    .GetComponent<TextMeshProUGUI>().text = actualReward.GetComponent<Weapon>().armor.ToString();

                if (actualReward.GetComponent<Stacking>())
                {
                    visibleInfo.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
                    visibleInfo.GetComponent<RectTransform>().GetChild(1).localScale = new Vector2(0.9f, 0.9f);
                    visibleInfo.transform.GetChild(1).GetChild(2)
                        .GetComponent<TextMeshProUGUI>().text = actualReward.GetComponent<Stacking>().stacks.ToString();
                }

                visibleInfo.transform.GetChild(2)
                    .GetComponent<TextMeshProUGUI>().text = actualReward.GetComponent<Weapon>().description;

                visibleInfo.transform.GetChild(3).gameObject.SetActive(true);
                switch(actualReward.GetComponent<Weapon>().type)
                {
                    case MainController.Choise.kivi:
                        visibleInfo.transform.GetChild(3).GetComponent<Image>().sprite = symbols[0];
                        break;
                    case MainController.Choise.paperi:
                        visibleInfo.transform.GetChild(3).GetComponent<Image>().sprite = symbols[1];
                        break;
                    case MainController.Choise.sakset:
                        visibleInfo.transform.GetChild(3).GetComponent<Image>().sprite = symbols[2];
                        break;
                    case MainController.Choise.hyödytön:
                        visibleInfo.transform.GetChild(3).GetComponent<Image>().sprite = symbols[3];
                        break;
                    case MainController.Choise.voittamaton:
                        visibleInfo.transform.GetChild(3).GetComponent<Image>().sprite = symbols[4];
                        break;
                }                
            }
            else if (actualReward.GetComponent<Item>())
            {
                visibleInfo.transform.GetChild(0)
                    .GetComponent<TextMeshProUGUI>().text = actualReward.GetComponent<Item>().name;
            }
        }
    }

    public void DestroyInfo()
    {
        Destroy(visibleInfo);
    }

    void OnMouseDown()
    {
        if (!disabled) { 
            Chosen();
            transform.parent.parent.GetComponent<RewardMenu>().DisableRewards();
        }
    }


}
