using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class WeaponSprite : MonoBehaviour
{
    public List<Sprite> symbols;
    public GameObject weapon;
    public int id;

    private GameObject visibleInfo;
    public GameObject Info;

    public void displaySprite()
    {
        if(weapon != null)
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
        } else
        {
            GetComponent<SpriteRenderer>().sprite = null;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    //Annoying, but nessessary
    public void RemoveSprite()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
    }

    void OnMouseDown()
    {
        GameObject wheelHolder = transform.parent.parent.parent.gameObject;
        if (wheelHolder.GetComponent<PlayerWheelHolder>().detached && weapon != null)
        {
            Unequip();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.GiveAwarning();
        }
    }

    public void Unequip()
    {
        PlayerContoller player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
        if (GameObject.Find("InventoryMenu(Clone)"))
        {
            GameObject.Find("InventoryMenu(Clone)").GetComponent<InventoryMenu>().addWeapon(weapon);
        } else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().items.Add(weapon);
        }
        player.UnequipWeapon(weapon.GetComponent<Weapon>());
        weapon = null;
        player.DisplayChoises();
        displaySprite();
        DestroyInfo();
        transform.parent.GetChild(1).GetComponent<DropDetector>().PlayAudio(6);
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
                visibleInfo.transform.GetChild(1).GetChild(0)
                    .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().GiveEffectiveDamage().ToString();
                visibleInfo.transform.GetChild(1).GetChild(1)
                    .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().GiveEffectiveArmor().ToString();

                if (weapon.GetComponent<Stacking>())
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
    }

    public void DestroyInfo()
    {
        if(visibleInfo != null) Destroy(visibleInfo);
    }
}
