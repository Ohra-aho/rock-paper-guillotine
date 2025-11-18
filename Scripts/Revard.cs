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
    }

    public void Chosen()
    {
        if(MC.buttons_active)
        {
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y - 0.2f, transform.parent.position.z);

            player.GetComponent<PlayerInventory>().AddItem(actualReward);
            //Get rid of info
            if (visibleInfo != null) DestroyInfo();

            transform.parent.parent.GetComponent<Test>().UnPauseAnimation();
            Destroy(gameObject);
            GameObject.Find("Roope").GetComponent<Test>().UnPauseAnimation();
            GameObject.Find("Reward reroll").GetComponent<RewardReroll>().reward_open = false;
            ActivatePickBark();
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
        }
    }

    private void DestroyAllInfo()
    {
        GameObject[] info = GameObject.FindGameObjectsWithTag("reward_info");
        if(info.Length > 0)
        {
            for (int i = info.Length-1; i >= 0; i--)
            {
                Destroy(info[i]);
            }
        }
    }

    public void DestroyInfo()
    {
        Destroy(visibleInfo);
    }

    void OnMouseDown()
    {
        if (!disabled && MC.game_state == MainController.State.reward) { 
            Chosen();
            transform.parent.parent.GetComponent<RewardMenu>().DisableRewards();
        }
        DestroyAllInfo();
    }

    private void ActivatePickBark()
    {
        if(actualReward.GetComponent<Weapon>().pick_barks.Count > 0)
        {
            int chance = Random.Range(1, 5); //1,5
            if (chance == 1)
            {
                int index = Random.Range(0, actualReward.GetComponent<Weapon>().pick_barks.Count);
                string bark = actualReward.GetComponent<Weapon>().pick_barks[index];
                GameObject.Find("BarkHolder").GetComponent<BarkController>().ActivateInstantBark(bark);
            }
        }
    }

}
