using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public MainController.Choise type;
    public int damage;
    public int armor;
    public string name;
    public string description;
    public Sprite sprite;

    public UnityEvent choisePhase;
    public UnityEvent resultPhase;
    public UnityEvent endPhase;

    public UnityEvent takeDamage;
    public UnityEvent dealDamage;
    public UnityEvent heal;

    public UnityEvent equip;
    public UnityEvent unEquip;


    public void emptyFunction()
    {
        //Debug.Log("Ei tee mit‰‰n");
    }

    public bool? GetVictory()
    {
        return GameObject.Find("EventSystem").GetComponent<MainController>().won;
    }

    public bool? GetDead()
    {
        //return GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().dead;
        return false;
    }
}
