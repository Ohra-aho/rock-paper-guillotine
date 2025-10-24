using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWheelHolder : MonoBehaviour
{
    public bool detached = false;

    public GameObject weaponDetector;
    public GameObject startButton;
    public GameObject inventory_button;
    [SerializeField] private GameObject InventoryMenu;
    MainController MC;

    //Achievement aids
    [HideInInspector] public List<Weapon> used_weapons = new List<Weapon>(); //experimentor

    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
    }

    private void Update()
    {
        if(MC.CompareState(MainController.State.idle) || MC.CompareState(MainController.State.re_arming))
        {
            if(!GetComponent<NonUIButton>().interactable)
            {
                GetComponent<NonUIButton>().interactable = true;
            }
        } else
        {
            if(GetComponent<NonUIButton>().interactable)
            {
                GetComponent<NonUIButton>().interactable = false;
            }
        }
    }

    public void press()
    {
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
        if (GameObject.Find("InventoryMenu(Clone)") == null) inventory_button.GetComponent<InventoryButton>().Press();
    }

    public void OpenDrawer()
    {
        Instantiate(InventoryMenu, GameObject.Find("InventoryMenuHolder").transform);
    }

    public void CloseDrawer()
    {
        GameObject.Find("InventoryMenuHolder").GetComponent<Test>().PlayAnimation("CloseDrawer");
    }

    public void AttachWheel()
    {
        transform.GetChild(0).GetComponent<Test>().PlayAnimation("AttachWheel");
        detached = false;
        if (GameObject.Find("InventoryMenu(Clone)") != null) inventory_button.GetComponent<InventoryButton>().Press(); //CloseDrawer();
    }

    public void RemoveWeapon(GameObject weapon)
    {
        for(int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            GameObject weaponHolder = transform.GetChild(0).GetChild(i).gameObject;
            if(weaponHolder.transform.GetChild(0).GetComponent<WeaponSprite>())
            {
                if (weaponHolder.transform.GetChild(0).GetComponent<WeaponSprite>().weapon == weapon)
                {
                    Destroy(weaponHolder.transform.GetChild(0).GetComponent<WeaponSprite>().weapon);
                    weaponHolder.transform.GetChild(0).GetComponent<WeaponSprite>().RemoveSprite();
                }
            }
        }

        //Remove name
        GameObject choise_panel = transform.parent.GetChild(1).gameObject;
        for(int i = 0; i < choise_panel.transform.childCount; i++)
        {
            if(choise_panel.transform.GetChild(i).GetComponent<CHoisePanel>().weapon == weapon.GetComponent<Weapon>())
            {
                choise_panel.transform.GetChild(i).GetComponent<CHoisePanel>().ClearName();
                choise_panel.transform.GetChild(i).GetComponent<CHoisePanel>().weapon = null;
                choise_panel.transform.GetChild(i).GetComponent<CHoisePanel>().weapon_name = "";
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


    //achievement aiders

    public void AdvanceExperimentor()
    {
        GameObject wheel = transform.GetChild(0).gameObject;
        for(int i = 0; i < wheel.transform.childCount-1; i++)
        {
            if(wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
            {
                if (!used_weapons.Contains(wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>()))
                {
                    used_weapons.Add(wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>());
                }
            }
            
        }
    }
}
