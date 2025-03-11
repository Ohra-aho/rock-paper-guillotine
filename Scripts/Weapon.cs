using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [HideInInspector] public bool player;
    [HideInInspector] public Weapon opponent;
    public MainController.Choise type;
    public int damage;
    public int armor;
    public string name;
    public string description;
    public Sprite sprite;
    public int stacks;


    public UnityEvent choisePhase;
    public UnityEvent resultPhase;
    public UnityEvent endPhase;

    public UnityEvent takeDamage;
    public UnityEvent dealDamage;
    public UnityEvent draw;
    public UnityEvent heal;

    public UnityEvent equip;
    public UnityEvent unEquip;

    public UnityEvent constant;

    private void Update()
    {
        if (constant != null) constant.Invoke();
    }

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

    public void TakeDamage(HealthBar hb, int amount)
    {
        int realDamage = amount - armor;
        if (realDamage < 0) realDamage = 0;

        hb.GetComponent<HealthBar>().TakeDamage(realDamage);

        takeDamage.Invoke();

        bool dead = hb.GetComponent<HealthBar>().CheckIfDead();
    }

    public void DealDamage(HealthBar hb, Weapon target, HealthBar opponent_hb)
    {
        target.TakeDamage(opponent_hb, damage);
        dealDamage.Invoke();
        bool dead = opponent_hb.GetComponent<HealthBar>().CheckIfDead();
    }

    public void HandleDraw()
    {
        draw.Invoke();
    }
}
