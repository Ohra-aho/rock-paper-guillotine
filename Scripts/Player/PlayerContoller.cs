using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerContoller : MonoBehaviour
{
    public MainController MC;
    private EnemyController currentEnemy;
    public HealthBar HB;

    //[HideInInspector] public int maxHealth = 1;
    private int maxHealth = 3;
    [HideInInspector] public int damage = 0;
    [HideInInspector] public int armor = 0;


    //Weapons
    public List<GameObject> weapons;

    public GameObject chosenWeapon;

    public GameObject PlayerWheel;
    public GameObject weaponDetector;

    public bool defeat = false;


    private void Start()
    {
        HB.DisplayHealthBar(maxHealth);
        DisplayWeapons(); //Should be moved somewhere else when implemented further
    }

    private void Update()
    {
        if (HB.dead && !defeat)
        {
            MC.Loose();
            HB.dead = false;
        }
    }

    public void DisplayChoises()
    {
        for(int i = 0; i < 3; i++)
        {
            if(PlayerWheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
            {
                transform.GetChild(i).GetComponent<CHoisePanel>().weapon_name =
                    PlayerWheel.transform.GetChild(i).GetChild(0)
                        .GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().name;
                transform.GetChild(i).GetComponent<CHoisePanel>().DisplayName();
            }
        }
    }

    public void MakeAChoise(int choise)
    {
        MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        currentEnemy = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        PlayerWheel.GetComponent<Test>().UnPauseAnimation();
        PlayerWheel.GetComponent<Test>().PlayAudio(0);
        PlayerWheel.GetComponent<Test>().PlayAudio(1);

        Weapon weapon = PlayerWheel.transform.GetChild(choise - 1)
            .GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>();

        MC.playerChoise = weapon;
        chosenWeapon = PlayerWheel.transform.GetChild(choise - 1)
            .GetChild(0).GetComponent<WeaponSprite>().weapon;

        weaponDetector.GetComponent<WeaponDetector>().detectionCount = 0;
        weaponDetector.GetComponent<WeaponDetector>().weaponToDetect = choise;

        ChoisePhase();

        MC.enemyChoise = currentEnemy.EnemyChoise(weapon.type);

        MC.Resolve();
    }

    public void DisplayWeapons()
    {
        for(int i = 0; i < PlayerWheel.transform.childCount-1; i++)
        {
            PlayerWheel.transform.GetChild(i).GetChild(0)
                        .GetComponent<WeaponSprite>().weapon = weapons[i];
        
            PlayerWheel.transform.GetChild(i).GetChild(0)
                .GetComponent<WeaponSprite>().displaySprite();
        }
        DisplayChoises();
    }

    public List<Weapon> GetWeapons()
    {
        List<Weapon> temp = new List<Weapon>();

        GameObject wheel = transform.parent
            .GetChild(0).GetChild(0).gameObject;

        for(int i = 0; i < wheel.transform.childCount-1; i++)
        {
            temp.Add(
                wheel.transform.GetChild(i).GetChild(0)
                .GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>()
            );
        }
        return temp;
    }

    //Combat functions

    public void DealDamage()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("EnemyHolder");
        bool dead = enemy.GetComponent<EnemyController>().dead;
        if (dead) MC.Win();
    }

    public void TakeDamage()
    {
        bool dead = HB.GetComponent<HealthBar>().CheckIfDead();

        if (dead) MC.Loose();
    }

    //Equipping
    public void EquipWeapon(Weapon weapon)
    {
        weapon.equip.Invoke();
    }

    public void UnequipWeapon(Weapon weapon)
    {
        weapon.unEquip.Invoke();
    }

    public void Draw()
    {
        
    }

    public void RecoverAllHealth()
    {
        HB.HealToFull();
    }

    public void Die()
    {
        HB.InstaKill();
    }

    public int GiveCurrentHealth()
    {
        return HB.GetComponent<HealthBar>().GiveCurrentHealth();
    }

    // Rock, Paper, scissors

    public void ChoisePhase()
    {
        damage = 0;
        armor = 0;
        //Does things when choise is made
        chosenWeapon.GetComponent<Weapon>().choisePhase.Invoke();
        damage = chosenWeapon.GetComponent<Weapon>().damage;
        armor = chosenWeapon.GetComponent<Weapon>().armor;
    }

    public void ResultPhase()
    {
        chosenWeapon.GetComponent<Weapon>().resultPhase.Invoke();
    }

    public void EndPhase()
    {
        chosenWeapon.GetComponent<Weapon>().endPhase.Invoke();
    }
}
