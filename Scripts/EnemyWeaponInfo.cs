using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyWeaponInfo : MonoBehaviour
{
    public Weapon weapon;
    public List<Sprite> symbols;

    public void Initiate()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.name;
    }

    public void DisplayInfo()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        GameObject info = transform.GetChild(1).gameObject;
        //info.SetActive(true);
        info.transform.GetChild(0).GetComponent<Image>().sprite = weapon.sprite;
        switch (weapon.GetComponent<Weapon>().type)
        {
            case MainController.Choise.kivi:
                info.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = symbols[0];
                break;
            case MainController.Choise.paperi:
                info.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = symbols[1];
                break;
            case MainController.Choise.sakset:
                info.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = symbols[2];
                break;
            case MainController.Choise.hyödytön:
                info.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = symbols[3];
                break;
            case MainController.Choise.voittamaton:
                info.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = symbols[4];
                break;
        }
        info.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weapon.damage.ToString();
        info.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = weapon.armor.ToString();
        info.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = weapon.description;
    }

    public void RemoveInfo()
    {
        GameObject info = transform.GetChild(1).gameObject;
        info.SetActive(false);
    }
}
