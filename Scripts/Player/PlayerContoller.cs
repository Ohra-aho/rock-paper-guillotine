using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerContoller : MonoBehaviour
{
    public MainController MC;
    private EnemyController currentEnemy;
    private HealthBar HB;

    public GameObject healthBar;

    //[HideInInspector] public int maxHealth = 1;
    private int maxHealth = 3;
    [HideInInspector] public int damage = 0;
    [HideInInspector] public int armor = 0;


    //Weapons
    public List<GameObject> weapons;

    public GameObject chosenWeapon;

    public GameObject PlayerWheel;
    public GameObject weaponDetector;


    private void Start()
    {
        HB = healthBar.GetComponent<HealthBar>();
        HB.DisplayHealthBar(maxHealth);
        DisplayWeapons(); //Should be moved somewhere else when implemented further
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

        MainController.Choise weaponType = PlayerWheel.transform.GetChild(choise - 1)
            .GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().type;

        MC.playerChoise = weaponType;
        chosenWeapon = PlayerWheel.transform.GetChild(choise - 1)
            .GetChild(0).GetComponent<WeaponSprite>().weapon;

        weaponDetector.GetComponent<WeaponDetector>().detectionCount = 0;
        weaponDetector.GetComponent<WeaponDetector>().weaponToDetect = choise;

        ChoisePhase();

        MC.enemyChoise = currentEnemy.EnemyChoise(weaponType);

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

    public void DealDamage(int damage)
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("EnemyHolder");

        enemy.GetComponent<EnemyController>().TakeDamage(damage);
        bool dead = enemy.GetComponent<EnemyController>().dead;

        if (chosenWeapon.GetComponent<Weapon>().dealDamage != null)
            chosenWeapon.GetComponent<Weapon>().dealDamage.Invoke();

        if (dead) MC.Win();
        
    }

    public void TakeDamage(int damage)
    {
        GameObject playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth");

        int realDamage = damage - armor;
        if (realDamage < 0) realDamage = 0;

        playerHealth.GetComponent<HealthBar>().TakeDamage(realDamage);

        if(chosenWeapon.GetComponent<Weapon>().takeDamage != null)
            chosenWeapon.GetComponent<Weapon>().takeDamage.Invoke();
        bool dead = playerHealth.GetComponent<HealthBar>().CheckIfDead();


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
        HB = healthBar.GetComponent<HealthBar>();
        HB.HealToFull();
    }

    public void Die()
    {
        HB = healthBar.GetComponent<HealthBar>();
        HB.InstaKill();
    }

    public int GiveCurrentHealth()
    {
        HB = healthBar.GetComponent<HealthBar>();
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
