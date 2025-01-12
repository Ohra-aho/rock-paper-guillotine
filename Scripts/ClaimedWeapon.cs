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

    public void OnBegingDrag()
    {
        DestroyInfo();
        GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
    }

    public void OnEndDrag()
    {
        GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    public void DispalyWeapon()
    {
        GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<Weapon>().sprite;
    }

    public void DisplayInfo()
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
            .GetComponent<TextMeshProUGUI>().text = "V: " + weapon.GetComponent<Weapon>().damage.ToString();
        visibleInfo.transform.GetChild(2)
            .GetComponent<TextMeshProUGUI>().text = "P: " + weapon.GetComponent<Weapon>().armor.ToString();
        visibleInfo.transform.GetChild(3)
            .GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Weapon>().description;
        
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
