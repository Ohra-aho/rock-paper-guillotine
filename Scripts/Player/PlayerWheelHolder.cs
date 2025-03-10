using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWheelHolder : MonoBehaviour
{
    public bool detached = false;

    public GameObject weaponDetector;
    public GameObject startButton;
    [SerializeField] private GameObject InventoryMenu;

    public void press()
    {
        //PlayAudio();
        if(detached)
        {
            AttachWheel();
        } else
        {
            DetachWheel();
        }
    }

    public void DetachWheel()
    {
        weaponDetector.GetComponent<WeaponDetector>().weaponToDetect = 0;
        transform.GetChild(0).GetComponent<Test>().UnPauseAnimation();
        transform.GetChild(0).GetComponent<Test>().PlayAnimation("DetachWheel");
        detached = true;
        startButton.GetComponent<NonUIButton>().interactable = false;
        Instantiate(InventoryMenu, GameObject.Find("InventoryMenuHolder").transform);
    }

    public void AttachWheel()
    {
        transform.GetChild(0).GetComponent<Test>().PlayAnimation("AttachWheel");
        detached = false;
        GameObject.Find("InventoryMenuHolder").GetComponent<Test>().PlayAnimation("CloseDrawer");
        startButton.GetComponent<NonUIButton>().interactable = true;
    }

    public void RemoveWeapon(GameObject weapon)
    {
        for(int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            GameObject weaponHolder = transform.GetChild(0).GetChild(i).gameObject;
            if (weaponHolder.transform.GetChild(0).GetComponent<WeaponSprite>().weapon == weapon)
            {
                weaponHolder.transform.GetChild(0).GetComponent<WeaponSprite>().weapon = null;
                weaponHolder.transform.GetChild(0).GetComponent<WeaponSprite>().displaySprite();
            }
        }

        GameObject ti = transform.parent.GetChild(1).GetComponent<PlayerContoller>().TrueInventory.gameObject;

        for (int i = 0; i < ti.transform.childCount; i++)
        {
            if(ti.transform.GetChild(i).gameObject == weapon)
            {
                Destroy(ti.transform.GetChild(i).gameObject);
                break;
            }
        }
    }

    private int LastIndex()
    {
        int index = transform.childCount - 1;
        if (index < 0) index = 0;
        return index;
    }

    public void PlayAudio()
    {
        if (!detached) transform.GetChild(LastIndex()).GetChild(0).GetComponent<AudioPlayer>().PlayClip();
        else transform.GetChild(LastIndex()).GetChild(1).GetComponent<AudioPlayer>().PlayClip();
    }
}
