using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponInfo : MonoBehaviour
{
    public Weapon weapon;

    public List<Sprite> icons;
    private void Update()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.name;
        transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.GiveEffectiveDamage().ToString();
        transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.GiveEffectiveArmor().ToString();
        if (weapon.GetComponent<Stacking>())
        {
            transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(200f, 40f);
            transform.GetChild(1).GetComponent<RectTransform>().localScale = new Vector2(0.75f, 0.75f);
            transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Stacking>().stacks.ToString();
        }
        else
        {
            transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(144f, 40f);
            transform.GetChild(1).GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
            transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        }
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = weapon.description;

        switch (weapon.type)
        {
            case MainController.Choise.kivi:
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[0];
                break;
            case MainController.Choise.paperi:
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[1];
                break;
            case MainController.Choise.sakset:
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[2];
                break;
            case MainController.Choise.hyödytön:
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[3];
                break;
            case MainController.Choise.voittamaton:
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[4];
                break;
        }
    }
}
