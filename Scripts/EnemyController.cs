using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public HealthBar HB;
    public HealthBar EnemyHB;
    public int maxHealth;
    [HideInInspector] public GameObject currentEnemy;

    public List<GameObject> weapons;

    [HideInInspector] public GameObject EnemyWheel;
    [HideInInspector] public GameObject weaponDetector;

    private GameObject chosenWeapon;

    public bool dead;

    public delegate int ChoiseMaker(MainController.Choise palyerChoise);
    public ChoiseMaker choiseMaker;

    //Enemy specific effects
    public delegate void Effect();
    public Effect choiseEffect;
    public Effect resultEffect;
    public Effect endEffect;
    public Effect damageEffect;

    public GameObject story_event_holder;

    public MainController MC;
    public bool victory = false;

    public GameObject true_weapon_holder;

    private void Update()
    {
        if(HB.dead)
        {
            dead = true;
            MC.Win();
            HB.dead = false;
        }
    }

    public void Inisiate()
    {
        HB.DisplayHealthBar(maxHealth);
        EnemyWheel = GameObject.FindGameObjectWithTag("EnemyWheel");
        weaponDetector = GameObject.FindGameObjectWithTag("EnemyWeaponDetector");
        DisplayWeapons();
    }

    public Weapon EnemyChoise(MainController.Choise playerChoise)
    {
        int choise = choiseMaker(playerChoise);
        //choise = 0;
        Weapon enemyChoise = weapons[choise].GetComponent<Weapon>();
        chosenWeapon = weapons[choise];

        weaponDetector.GetComponent<WeaponDetector>().detectionCount = 0;
        weaponDetector.GetComponent<WeaponDetector>().weaponToDetect = choise+1;

        EnemyWheel.GetComponent<Test>().UnPauseAnimation();
        EnemyWheel.GetComponent<Test>().PlayAudio(0);
        EnemyWheel.GetComponent<Test>().PlayAudio(1);

        ChoisePhase();

        return enemyChoise;
    }

    public void RecoverAllHealth()
    {
        HB.HealToFull();
    }

    public void Die()
    {
        HB.InstaKill();
    }

    public void DestroyThis()
    {
        HB.DestroyHealthBar();
        Destroy(transform.GetChild(0).gameObject);
    }

    public void SpawnEnemy()
    {
        if(story_event_holder.transform.childCount > 0)
        {
            Encounter encounter = null;
            if (story_event_holder.transform.GetChild(0).GetComponent<Encounter>()) 
            {
                encounter = story_event_holder.transform.GetChild(0).GetComponent<Encounter>();
            }
            if(encounter != null)
            {
                victory = false;
                Instantiate(encounter.enemies[0], transform);
            }
        }
    }

    public void HandleEnemy()
    {
        GameObject infoHolder = GameObject.Find("EnemyWeaponInfo");
        infoHolder.GetComponent<WeaponInfoRack>().ClearInfoRack();
        if (transform.childCount > 0) DestroyThis();
        else SpawnEnemy();
        
    }

    public void DisplayWeapons()
    {
        for (int i = 0; i < EnemyWheel.transform.childCount-1; i++)
        {
            GameObject new_weapon = Instantiate(weapons[i], true_weapon_holder.transform);
            new_weapon.GetComponent<Weapon>().player = false;
            EnemyWheel.transform.GetChild(i).GetChild(0)
                .GetComponent<WeaponSprite>().weapon = new_weapon;
            weapons[i] = new_weapon;

            EnemyWheel.transform.GetChild(i).GetChild(0)
                .GetComponent<WeaponSprite>().displaySprite();
        }
        SpawnWeaponInfo();
    }

    public void SpawnWeaponInfo()
    {
        GameObject infoHolder = GameObject.Find("EnemyWeaponInfo");
        for (int i = 0; i < true_weapon_holder.transform.childCount; i++)
        {
            infoHolder.GetComponent<WeaponInfoRack>().SpawnWeaponInfo(true_weapon_holder.transform.GetChild(i).GetComponent<Weapon>());
        }
    }

    public void TakeDamage()
    {
        dead = HB.GetComponent<HealthBar>().CheckIfDead();
        if(!dead)
        {
            if(damageEffect != null) damageEffect.Invoke();
            currentEnemy.GetComponent<BasicEnemy>().ReactToDamage();
        }
    }

    // Rock, Paper, scissors

    public void ChoisePhase()
    {
        //Does things when choise is made
        chosenWeapon.GetComponent<Weapon>().choisePhase.Invoke();
        if(choiseEffect != null) choiseEffect();

    }

    public void ResultPhase()
    {
        if (resultEffect != null) resultEffect();
        chosenWeapon.GetComponent<Weapon>().resultPhase.Invoke();
        //Does things when result is determined
    }

    public void EndPhase()
    {
        if (endEffect != null) endEffect();

        chosenWeapon.GetComponent<Weapon>().endPhase.Invoke();

        //Does things when round is over
        currentEnemy.GetComponent<BasicEnemy>().CheckUp(
                HB.GiveCurrentHealth(),
                maxHealth,
                EnemyHB.GiveCurrentHealth(),
                EnemyHB.GiveMaxHealth()
            );

    }

    public int GiveCurrentHealth()
    {
        return HB.GetComponent<HealthBar>().GiveCurrentHealth();
    }
}
