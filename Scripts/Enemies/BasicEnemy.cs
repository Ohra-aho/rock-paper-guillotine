using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BasicEnemy : MonoBehaviour
{
    public string name;
    public Sprite image;

    public int maxHealth;
    public List<GameObject> weapons;

    private GameObject controller;

    public List<int> plan_1;
    public List<int> plan_2;

    private List<int> chosen_plan = new List<int>();
    private int planIndex = 0;

    MainController.Choise lastPlayerChoise = MainController.Choise.kivi;

    public bool off_balance;
    public bool nearDeath;

    public List<int> off_balance_choises;

    public bool advanced = false;

    public List<string> victory_barks;
    public GameObject victory_message;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        TransferInfo();
        transform.parent.GetComponent<SpriteRenderer>().sprite = image;
        int plan = Random.Range(1, 3);
        switch(plan)
        {
            case 1: chosen_plan.AddRange(plan_1); break;
            case 2: chosen_plan.AddRange(plan_2); break;
        }

        MainController MC = GameObject.Find("EventSystem").GetComponent<MainController>();
        MC.victory_barks = victory_barks;
        if (victory_message != null) MC.victory_message = victory_message;
        else MC.victory_message = null;


    }

    public void TransferInfo()
    {
        controller.GetComponent<EnemyController>().maxHealth = maxHealth;
        controller.GetComponent<EnemyController>().weapons = weapons;
        if(!advanced) controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        controller.GetComponent<EnemyController>().currentEnemy = this.gameObject;
        controller.GetComponent<EnemyController>().Inisiate();
    }

    /*public void SpawnWeaponInfo()
    {
        GameObject infoHolder = GameObject.Find("EnemyWeaponInfo");
        for(int i = 0; i < weapons.Count; i++)
        {
            infoHolder.GetComponent<WeaponInfoRack>().SpawnWeaponInfo(weapons[i].GetComponent<Weapon>());
        }
    }*/

    public void ReactToDamage() //Nees indicator when off balance
    {
        float change_to_off_balance = Random.Range(0.01f, 1f);
        if(!off_balance)
        {
            if (change_to_off_balance <= 0.7f)
            {
                off_balance = true;
            }
            else
            {
                off_balance = false;
            }
        } else
        {
            off_balance = false;
        }
        off_balance = false; //Try without off balance
    }

    public void CheckUp(int currentHealth, int maxHealth, int enemyCurrentHealth, int enemyMaxHealth)
    {
        if(currentHealth <= maxHealth/3 || currentHealth == 1)
        {
            nearDeath = true;
        }

        /*if(nearDeath)
        {

        }*/
    }

    public int MakeChoise(MainController.Choise playerChoise)
    {
        int step = 0;
        step = StikToPlan();
        lastPlayerChoise = playerChoise;

        off_balance = false;
        return step;
    }

    private int StikToPlan()
    {
        int step = chosen_plan[planIndex];
        planIndex++;
        if (planIndex >= chosen_plan.Count)
        {
            planIndex = 0;
        }

        //If weapon is destroyed, skip it in plan
        while (!CheckIfWeaponExists(step))
        {
            step = chosen_plan[planIndex];
            planIndex++;
            if (planIndex >= chosen_plan.Count)
            {
                planIndex = 0;
            }
        }
        return step;
    }

    private bool CheckIfWeaponExists(int index)
    {
        return weapons[index] != null;
    }
}
