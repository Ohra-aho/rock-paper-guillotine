using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DropDetector : MonoBehaviour
{
    public GameObject weaponHolder;
    public GameObject player;

    private bool over = false;
    private GameObject objectOver;


    public void OnDrop()
    {
        changeWeapon(objectOver.GetComponent<ClaimedWeapon>().weapon);
    }

    public void changeWeapon(GameObject newWeapon)
    {
        if(weaponHolder.GetComponent<WeaponSprite>().weapon != null)
        {
            //GameObject.Find("InventoryMenu(Clone)").GetComponent<InventoryMenu>()
            //    .addWeapon(weaponHolder.GetComponent<WeaponSprite>().weapon);

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
        if(other.GetComponent<DragNDrop>())
        {
            over = true;
            objectOver = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<DragNDrop>())
        {
            over = false;
            objectOver = null;
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
    }
}
