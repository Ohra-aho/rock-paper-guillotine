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
        if(objectOver != null)
        {
            changeWeapon(
                objectOver.GetComponent<ClaimedWeapon>().weapon, 
                objectOver.transform.GetSiblingIndex()
            );
        }
    }

    public void changeWeapon(GameObject newWeapon, int index)
    {
        PlayAudio(5);
        if(weaponHolder.GetComponent<WeaponSprite>().weapon != null)
        {
            GameObject.Find("InventoryMenu(Clone)").GetComponent<InventoryMenu>()
                .addWeapon(weaponHolder.GetComponent<WeaponSprite>().weapon);

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>()
                .UnequipWeapon(weaponHolder.GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>());
        }
        weaponHolder.GetComponent<WeaponSprite>().weapon = newWeapon;
        GameObject.Find("InventoryMenu(Clone)").GetComponent<InventoryMenu>()
                .removeWeapon(index);

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>()
                .EquipWeapon(weaponHolder.GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>());

        weaponHolder.GetComponent<WeaponSprite>().displaySprite();
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerContoller>().DisplayChoises();
    }

    public void DisplayLoadedWeapon(GameObject newWeapon)
    {
        if (weaponHolder.GetComponent<WeaponSprite>().weapon != null)
        {
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

    private int LastIndex()
    {
        int index = transform.parent.parent.childCount - 1;
        if (index < 0) index = 0;
        for (int i = 0; i < transform.parent.parent.childCount; i++)
        {
            if (transform.parent.parent.GetChild(i).GetComponent<Stupid>())
            {
                return i;
            }
        }
        return index;
    }

    public void PlayAudio(int clip)
    {
        transform.parent.parent.GetChild(LastIndex()).GetChild(clip).GetComponent<AudioPlayer>().PlayClip();
    }
}
