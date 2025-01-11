using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public List<GameObject> enemies;
    public bool firstEnemy = true;

    HealthBar HB;
    public int maxHealth;
    [HideInInspector] public int damage = 0;
    [HideInInspector] public int armor = 0;

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


    public void Inisiate()
    {
        HB = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<HealthBar>();
        HB.DisplayHealthBar(maxHealth);
        EnemyWheel = GameObject.FindGameObjectWithTag("EnemyWheel");
        weaponDetector = GameObject.FindGameObjectWithTag("EnemyWeaponDetector");
        DisplayWeapons();
    }

    public MainController.Choise EnemyChoise(MainController.Choise playerChoise)
    {
        int choise = choiseMaker(playerChoise);
        //choise = 0;
        MainController.Choise enemyChoise = weapons[choise].GetComponent<Weapon>().type;
        chosenWeapon = weapons[choise];

        weaponDetector.GetComponent<WeaponDetector>().detectionCount = 0;
        weaponDetector.GetComponent<WeaponDetector>().weaponToDetect = choise+1;

        EnemyWheel.GetComponent<Test>().UnPauseAnimation();

        ChoisePhase();

        return enemyChoise;
    }

    public void RecoverAllHealth()
    {
        HB = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<HealthBar>();
        HB.HealToFull();
    }

    public void Die()
    {
        HB = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<HealthBar>();
        HB.InstaKill();
    }

    public void DestroyThis()
    {
        HB = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<HealthBar>();
        HB.DestroyHealthBar();
        Destroy(transform.GetChild(0).gameObject);
    }

    public void SpawnEnemy()
    {
        int index = Random.Range(0, enemies.Count);
        if(firstEnemy)
        {
            index = 0;
            firstEnemy = false;
        }
        Instantiate(enemies[index], transform);
    }

    public void HandleEnemy()
    {
        if (transform.childCount > 0) DestroyThis();
        else SpawnEnemy();
        
    }

    public void DisplayWeapons()
    {
        for (int i = 0; i < EnemyWheel.transform.childCount; i++)
        {
            EnemyWheel.transform.GetChild(i).GetChild(0)
                .GetComponent<WeaponSprite>().weapon = weapons[i];

            EnemyWheel.transform.GetChild(i).GetChild(0)
                .GetComponent<WeaponSprite>().displaySprite();
        }
    }

    public void TakeDamage(int damage)
    {
        HB = GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<HealthBar>();

        int realDamage = damage - armor;
        if (realDamage < 0) realDamage = 0;

        HB.GetComponent<HealthBar>().TakeDamage(realDamage);
        dead = HB.GetComponent<HealthBar>().CheckIfDead();
    }

    // Rock, Paper, scissors

    public void ChoisePhase()
    {
        damage = 0;
        armor = 0;
        //Does things when choise is made
        chosenWeapon.GetComponent<Weapon>().choisePhase.Invoke();
        if(choiseEffect != null) choiseEffect();

        damage = chosenWeapon.GetComponent<Weapon>().damage;
        armor = chosenWeapon.GetComponent<Weapon>().armor;
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
    }
}
