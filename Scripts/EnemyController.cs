using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public List<GameObject> enemies;
    public bool firstEnemy = true;

    public HealthBar HB;
    public HealthBar EnemyHB;
    public int maxHealth;
    [HideInInspector] public int damage = 0;
    [HideInInspector] public int armor = 0;
    [HideInInspector] public BasicEnemy currentEnemy;

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

    public GameObject story_event_holder;

    public MainController MC;
    public bool victory = false;

    private void Update()
    {
        if(HB.dead)
        {
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
        /*if(firstEnemy)
        {
            index = 0;
            firstEnemy = false;
        }*/
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
            EnemyWheel.transform.GetChild(i).GetChild(0)
                .GetComponent<WeaponSprite>().weapon = weapons[i];

            EnemyWheel.transform.GetChild(i).GetChild(0)
                .GetComponent<WeaponSprite>().displaySprite();
        }
    }

    public void TakeDamage()
    {

        dead = HB.GetComponent<HealthBar>().CheckIfDead();
        if(!dead)
        {
            currentEnemy.ReactToDamage();
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
        //Does things when result is determined
    }

    public void EndPhase()
    {
        if (endEffect != null) endEffect();

        //Does things when round is over
        currentEnemy.CheckUp(
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
