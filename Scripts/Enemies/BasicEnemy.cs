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

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        TransferInfo();
        controller.GetComponent<EnemyController>().Inisiate();
        GetComponent<SpriteRenderer>().sprite = image;
        int plan = Random.Range(1, 3);
        switch(plan)
        {
            case 1: chosen_plan.AddRange(plan_1); break;
            case 2: chosen_plan.AddRange(plan_2); break;
        }
        
        SpawnWeaponInfo();
    }

    public void TransferInfo()
    {
        controller.GetComponent<EnemyController>().maxHealth = maxHealth;
        controller.GetComponent<EnemyController>().weapons = weapons;
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
        controller.GetComponent<EnemyController>().currentEnemy = this;
    }

    public void SpawnWeaponInfo()
    {
        GameObject infoHolder = GameObject.Find("EnemyWeaponInfo");
        for(int i = 0; i < weapons.Count; i++)
        {
            infoHolder.GetComponent<WeaponInfoRack>().SpawnWeaponInfo(weapons[i].GetComponent<Weapon>());
        }
    }

    public void ReactToDamage()
    {
        float change_to_off_balance = Random.Range(0.01f, 1f);
        if(change_to_off_balance <= 0.7f)
        {
            off_balance = true;
        } else
        {
            off_balance = false;
        }
        off_balance = true;

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

    private int MakeChoise(MainController.Choise playerChoise)
    {
        int step = 0;

        if(off_balance)
        {
            step = OffBalanceChoise();
        }
        else
        {
            step = BasicChoise();
        }

        lastPlayerChoise = playerChoise;

        off_balance = false;
        return step;
    }

    private int BasicChoise()
    {
        //Debug.Log("Basic choise");
        int choiseIndex = 0;
        int step = 0;

        //Does the action
        switch (choiseIndex)
        {
            case 0: step = StikToPlan(); break;
            case 1: step = Bluff(); break;
            case 2: step = Counter(); break;
            case 3: step = CounterCounter(); break;
        }

        return step;
    }

    private int OffBalanceChoise()
    {
        return off_balance_choises[Random.Range(0, off_balance_choises.Count)];
    }

    private int StikToPlan()
    {
        int step = chosen_plan[planIndex];
        planIndex++;
        if (planIndex == chosen_plan.Count)
        {
            planIndex = 0;
        }
        return step;
    }

    //Make the same action again as previously
    private int Bluff()
    {
        if(planIndex > 0)
        {
            int step = chosen_plan[planIndex - 1];
            return step;
        } else
        {
            int step = chosen_plan[planIndex];
            return step;
        }
        
    }

    //Antisipate the same action from opponent and counter that
    private int Counter()
    {
        int temp = 0;
        for(int i = 0; i < weapons.Count; i++)
        {
            switch(lastPlayerChoise)
            {
                case MainController.Choise.kivi:
                    if (weapons[i].GetComponent<Weapon>().type == MainController.Choise.paperi) temp = i;
                    break;
                case MainController.Choise.paperi:
                    if (weapons[i].GetComponent<Weapon>().type == MainController.Choise.sakset) temp = i;
                    break;
                case MainController.Choise.sakset:
                    if (weapons[i].GetComponent<Weapon>().type == MainController.Choise.kivi) temp = i;
                    break;
            }
        }
        return temp;
    }

    //Use opponents previous action
    private int CounterCounter()
    {
        int temp = 0;
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].GetComponent<Weapon>().type == lastPlayerChoise) temp = i;
        }
        return temp;
    }

    //Finds all available counters to selected weapon
    private List<Weapon> FindCountersTo(Weapon weapon)
    {
        List<Weapon> temp = new List<Weapon>();

        switch (weapon.type)
        {
            case MainController.Choise.kivi:
                for (int i = 0; i < weapons.Count; i++)
                {
                    if (weapons[i].GetComponent<Weapon>().type == MainController.Choise.paperi)
                    {
                        temp.Add(weapons[i].GetComponent<Weapon>());
                    }
                }
                break;
            case MainController.Choise.paperi:
                for (int i = 0; i < weapons.Count; i++)
                {
                    if (weapons[i].GetComponent<Weapon>().type == MainController.Choise.sakset)
                    {
                        temp.Add(weapons[i].GetComponent<Weapon>());
                    }
                }
                break;
            case MainController.Choise.sakset:
                for (int i = 0; i < weapons.Count; i++)
                {
                    if (weapons[i].GetComponent<Weapon>().type == MainController.Choise.kivi)
                    {
                        temp.Add(weapons[i].GetComponent<Weapon>());
                    }
                }
                break;
            case MainController.Choise.hyödytön:
                for (int i = 0; i < weapons.Count; i++)
                {
                    temp.Add(weapons[i].GetComponent<Weapon>());
                }
                break;
            case MainController.Choise.voittamaton:
                //No can do...
                break;
        }

        return temp;
    }

}
