using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ClaimedWeapon : MonoBehaviour
{
    public GameObject weapon;
    private GameObject visibleInfo;
    public GameObject Info;
    public List<Sprite> symbols;

    GameObject wheel;

    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;

    public bool disabled;

    private void Awake()
    {
        wheel = GameObject.Find("PlayerWheelHolder").transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        disabled = !GameObject.Find("PlayerWheelHolder").GetComponent<PlayerWheelHolder>().detached;
    }

    public void OnBegingDrag()
    {
        DestroyInfo();
        GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
        FixSorting1();
    }

    public void OnEndDrag()
    {
        GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        FixSorting2();
    }

    public void FixSorting1()
    {
        GetComponent<SpriteRenderer>().sortingOrder += 2;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder += 2;
    }

    public void FixSorting2()
    {
        GetComponent<SpriteRenderer>().sortingOrder -= 2;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder -= 2;
    }

    public void DispalyWeapon()
    {
        GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<Weapon>().sprite;
        switch(weapon.GetComponent<Weapon>().type)
        {
            case MainController.Choise.kivi:
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = symbols[0];
                break;
            case MainController.Choise.paperi:
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = symbols[1];
                break;
            case MainController.Choise.sakset:
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = symbols[2];
                break;
            case MainController.Choise.hyödytön:
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = symbols[3];
                break;
            case MainController.Choise.voittamaton:
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = symbols[4];
                break;
        }
    }

    public void DisplayInfo()
    {
        
        if(GameObject.Find("EventSystem").GetComponent<MainController>().buttons_active)
        {
            transform.parent.parent.GetComponent<NonUIScroll>().Activate(); //Crude but works

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

            visibleInfo.transform.GetChild(0)
                .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().name;

            visibleInfo.transform.GetChild(1).GetChild(0)
                .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().GiveEffectiveDamage().ToString();
            visibleInfo.transform.GetChild(1).GetChild(1)
                .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().GiveEffectiveArmor().ToString();
            if(weapon.GetComponent<Stacking>())
            {
                visibleInfo.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
                visibleInfo.GetComponent<RectTransform>().GetChild(1).localScale = new Vector2(0.9f, 0.9f);
                visibleInfo.transform.GetChild(1).GetChild(2)
                    .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Stacking>().stacks.ToString();
            }

            visibleInfo.transform.GetChild(2)
                .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().description;
        }

    }

    public void DestroyInfo()
    {
        Destroy(visibleInfo);
        transform.parent.parent.GetComponent<NonUIScroll>().Deactivate(); //Crude but works
    }

    //Double click

    private void OnMouseDown()
    {
        if(!disabled)
        {
            if (Time.time - clicktime >= clickdelay)
            {
                clicked = 0;
            }

            clicked++;
            if (clicked == 1)
            {
                clicktime = Time.time;
            }

            if (clicked >= 2 && Time.time - clicktime <= clickdelay)
            {
                for (int i = 0; i < wheel.transform.childCount - 1; i++)
                {
                    if (wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon == null)
                    {
                        DestroyInfo();
                        wheel.transform.GetChild(i).GetChild(1).GetComponent<DropDetector>().changeWeapon(weapon, transform.GetSiblingIndex());
                        break;
                    }
                }
                clicked = 0;
            }
        }
        
    }
}
