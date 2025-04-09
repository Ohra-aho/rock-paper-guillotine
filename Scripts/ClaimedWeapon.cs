using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClaimedWeapon : MonoBehaviour
{
    public GameObject weapon;
    private GameObject visibleInfo;
    public GameObject Info;
    public List<Sprite> symbols;

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
            visibleInfo.transform.GetChild(1)
                .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().damage.ToString();
            visibleInfo.transform.GetChild(2)
                .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().armor.ToString();
            visibleInfo.transform.GetChild(3)
                .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().description;
            switch (weapon.GetComponent<Weapon>().type)
            {
                case MainController.Choise.kivi:
                    visibleInfo.transform.GetChild(4).GetComponent<Image>().sprite = symbols[0];
                    break;
                case MainController.Choise.paperi:
                    visibleInfo.transform.GetChild(4).GetComponent<Image>().sprite = symbols[1];
                    break;
                case MainController.Choise.sakset:
                    visibleInfo.transform.GetChild(4).GetComponent<Image>().sprite = symbols[2];
                    break;
                case MainController.Choise.hyödytön:
                    visibleInfo.transform.GetChild(4).GetComponent<Image>().sprite = symbols[3];
                    break;
                case MainController.Choise.voittamaton:
                    visibleInfo.transform.GetChild(4).GetComponent<Image>().sprite = symbols[4];
                    break;
            }
        }

    }

    public void DestroyInfo()
    {
        Destroy(visibleInfo);
        transform.parent.parent.GetComponent<NonUIScroll>().Deactivate(); //Crude but works

    }

    private void OnMouseDown()
    {
        DestroyInfo();
    }
}
