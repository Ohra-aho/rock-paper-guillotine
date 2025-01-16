using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyWeaponInfo : MonoBehaviour
{
    public Weapon weapon;

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
        info.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "V: " + weapon.damage + "\t" + "P: " + weapon.armor;
        info.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = weapon.description;
    }

    public void RemoveInfo()
    {
        GameObject info = transform.GetChild(1).gameObject;
        info.SetActive(false);
    }
}
