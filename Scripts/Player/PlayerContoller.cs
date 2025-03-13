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
    public GameObject TrueWeaponHolder;
    public GameObject TrueInventory;

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
        if(PlayerWheel.transform.GetChild(choise - 1).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
        {
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
    }

    public void DisplayWeapons()
    {
        InstanciateRealWeapons();
        for (int i = 0; i < PlayerWheel.transform.childCount-1; i++)
        {
            PlayerWheel.transform.GetChild(i).GetChild(0)
                        .GetComponent<WeaponSprite>().weapon = TrueWeaponHolder.transform.GetChild(TrueWeaponHolder.transform.childCount - 1-i).gameObject;
        
            PlayerWheel.transform.GetChild(i).GetChild(0)
                .GetComponent<WeaponSprite>().displaySprite();
        }
        DisplayChoises();
    }

    public void InstanciateRealWeapons()
    {
        for (int i = 0; i < GetComponent<PlayerInventory>().items.Count; i++)
        {
            Instantiate(GetComponent<PlayerInventory>().items[i], TrueInventory.transform);
        }
        GetComponent<PlayerInventory>().items.Clear();
        for (int i = 0; i < TrueInventory.transform.childCount; i++)
        {
            GetComponent<PlayerInventory>().items.Add(TrueInventory.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < weapons.Count; i++)
        {
            Instantiate(weapons[i], TrueWeaponHolder.transform);
        }
    }

    public void ClearTrueWeaponHolder()
    {
        for(int i = TrueWeaponHolder.transform.childCount; i > 0; i--)
        {
            DestroyImmediate(TrueWeaponHolder.transform.GetChild(0).gameObject);
        }
    }

    public List<Weapon> GetWeapons()
    {
        List<Weapon> temp = new List<Weapon>();

        GameObject wheel = transform.parent
            .GetChild(0).GetChild(0).gameObject;

        for(int i = 0; i < wheel.transform.childCount-1; i++)
        {
            if(wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
            {
                temp.Add(
                    wheel.transform.GetChild(i).GetChild(0)
                        .GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>()
                );
            } 
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
        weapon.player = true;
    }

    public void UnequipWeapon(Weapon weapon)
    {
        weapon.unEquip.Invoke();
        weapon.player = false;
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
       if(chosenWeapon != null) chosenWeapon.GetComponent<Weapon>().resultPhase.Invoke();
    }

    public void EndPhase()
    {
        if (chosenWeapon != null) chosenWeapon.GetComponent<Weapon>().endPhase.Invoke();
    }
}
