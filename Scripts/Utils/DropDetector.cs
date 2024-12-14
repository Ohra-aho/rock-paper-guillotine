using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DropDetector : MonoBehaviour, IDropHandler
{
    public GameObject weaponHolder;
    public GameObject player;

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<DragAndDrop>().remove = true;
        changeWeapon(eventData.pointerDrag.GetComponent<ClaimedWeapon>().weapon);

    }

    public void changeWeapon(GameObject newWeapon)
    {
        if(weaponHolder.GetComponent<WeaponSprite>().weapon != null)
        {
            GameObject.Find("ImventoryMenu(Clone)").GetComponent<InventoryMenu>()
                .addWeapon(weaponHolder.GetComponent<WeaponSprite>().weapon);

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>()
                .UnequipWeapon(weaponHolder.GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>());
        }
        weaponHolder.GetComponent<WeaponSprite>().weapon = newWeapon;

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>()
                .EquipWeapon(weaponHolder.GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>());

        weaponHolder.GetComponent<WeaponSprite>().displaySprite();
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerContoller>().DisplayChoises();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }

    void OnTriggerStay(Collider other)
    {
    }

    void OnTriggerExit(Collider other)
    {
    }
}
