using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemy : MonoBehaviour
{
    public string name;
    public Sprite image;

    public int maxHealth;
    public List<GameObject> weapons;

    private GameObject controller;

    //Stick to plan,
    //Bluff,
    //Counter,
    //Counter counter

    public List<int> plan;
    private int planIndex = 0;

    MainController.Choise lastPlayerChoise = MainController.Choise.kivi;

    private bool nearDeath;

   
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        TransferInfo();
        controller.GetComponent<EnemyController>().Inisiate();
        GetComponent<SpriteRenderer>().sprite = image;
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
        Debug.Log("Taking damage!");
    }

    public void CheckUp(int currentHealth, int maxHealth, int enemyCurrentHealth, int enemyMaxHealth)
    {
        if(currentHealth <= maxHealth/3 || currentHealth == 1)
        {
            nearDeath = true;
            Debug.Log("Near death");
        }

        /*if()
        {

        }*/
    }

    private Weapon GetStrongestWeapon()
    {
        Weapon strongest = weapons[0].GetComponent<Weapon>();

        for(int i = 1; i < weapons.Count; i++)
        {
            if(weapons[i].GetComponent<Weapon>().damage > strongest.damage)
            {
                strongest = weapons[i].GetComponent<Weapon>();
            }
        }

        return strongest;
    }

    private Weapon GetMostArmor()
    {
        Weapon strongest = weapons[0].GetComponent<Weapon>();

        for (int i = 1; i < weapons.Count; i++)
        {
            if (weapons[i].GetComponent<Weapon>().armor > strongest.armor)
            {
                strongest = weapons[i].GetComponent<Weapon>();
            }
        }

        return strongest;
    }

    private int MakeChoise(MainController.Choise playerChoise)
    {
        float choise = Random.Range(0.01f, 1f);
        int choiseIndex = 0;
        int step = 0;

        //To give some random element to AI's plan
        if (choise <= 0.2f)
        {
            choiseIndex = Random.Range(1, 3);
        }

        //choiseIndex = 3;

        //Does the action
        switch(choiseIndex)
        {
            case 0: step = StikToPlan(); break;
            case 1: step = Bluff(); break;
            case 2: step = Counter(); break;
            case 3: step = CounterCounter(); break;
        }

        lastPlayerChoise = playerChoise;

        return step;
    }

    private int StikToPlan()
    {
        int step = plan[planIndex];
        planIndex++;
        if (planIndex == plan.Count)
        {
            planIndex = 0;
        }
        return step;
    }

    //Make the same action again as previously
    private int Bluff()
    {
        Debug.Log("Bluff");
        if(planIndex > 0)
        {
            int step = plan[planIndex - 1];
            return step;
        } else
        {
            int step = plan[planIndex];
            return step;
        }
        
    }

    //Antisipate the same action from opponent and counter that
    private int Counter()
    {
        Debug.Log("Counter");
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
        Debug.Log("CounterCounter");
        int temp = 0;
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].GetComponent<Weapon>().type == lastPlayerChoise) temp = i;
        }
        return temp;
    }

}
