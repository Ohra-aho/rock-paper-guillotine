using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WeaponSprite : MonoBehaviour
{
    public GameObject weapon;
    public int id;

    private GameObject visibleInfo;
    public GameObject Info;


    public void displaySprite()
    {
        if(weapon != null)
        {
            GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<Weapon>().sprite;
        } else
        {
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    void OnMouseDown()
    {
        GameObject wheelHolder = transform.parent.parent.parent.gameObject;
        if(wheelHolder.GetComponent<PlayerWheelHolder>().detached && weapon != null)
        {
            GameObject.Find("InventoryMenu(Clone)").GetComponent<InventoryMenu>().addWeapon(weapon);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().UnequipWeapon(weapon.GetComponent<Weapon>());
            weapon = null;
            displaySprite();
            DestroyInfo();
        }
    }

    public void DisplayInfo()
    {
        GameObject wheelHolder = transform.parent.parent.parent.gameObject;

        if (wheelHolder.GetComponent<PlayerWheelHolder>().detached && weapon != null)
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

            if (weapon != null)
            {
                visibleInfo.transform.GetChild(0)
                    .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().name;
                visibleInfo.transform.GetChild(1)
                    .GetComponent<TextMeshProUGUI>().text = "V: " + weapon.GetComponent<Weapon>().damage.ToString();
                visibleInfo.transform.GetChild(2)
                    .GetComponent<TextMeshProUGUI>().text = "P: " + weapon.GetComponent<Weapon>().armor.ToString();
                visibleInfo.transform.GetChild(3)
                    .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().description;
            }
        }

        

    }

    public void DestroyInfo()
    {
        Destroy(visibleInfo);
    }
}
