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

    public List<int> plan;
    private int planIndex = 0;

    MainController.Choise lastPlayerChoise = MainController.Choise.kivi;

    private bool nearDeath;

    private void Awake()
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
        //Debug.Log("Taking damage!");
    }

    public void CheckUp(int currentHealth, int maxHealth, int enemyCurrentHealth, int enemyMaxHealth)
    {
        if(currentHealth <= maxHealth/3 || currentHealth == 1)
        {
            nearDeath = true;
        }

        //Debug.Log(GetStrongestWeapon().name);
        //Debug.Log(GetMostArmor().name);

        /*if(nearDeath)
        {

        }*/
    }

    private Weapon GetStrongestWeapon()
    {
        Weapon strongest = weapons[0].GetComponent<Weapon>();

        //Find strongest
        for(int i = 1; i < weapons.Count; i++)
        {
            if(weapons[i].GetComponent<Weapon>().damage > strongest.damage)
            {
                strongest = weapons[i].GetComponent<Weapon>();
            }
        }
        bool allEqual = true;

        //Check if all weapons are equal
        for(int i = 0; i < weapons.Count; i++)
        {
            if(strongest.damage > weapons[i].GetComponent<Weapon>().damage)
            {
                allEqual = false;
                break;
            }
        }

        if(allEqual) return null;
        else return strongest;
        
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

        bool allEqual = true;
        //Check if all weapons are equal
        for (int i = 0; i < weapons.Count; i++)
        {
            if (strongest.armor > weapons[i].GetComponent<Weapon>().armor)
            {
                allEqual = false;
                break;
            }
        }

        if (allEqual) return null;
        else return strongest;
        
    }

    private int MakeChoise(MainController.Choise playerChoise)
    {
        int step = 0;

        List<Weapon> dangerous = CanBeKilledWith(); //Weapons which will lose against
        List<Weapon> lethal = CanKillWith(); //Weapons to win with

        //Debug.Log("Dangerous" + dangerous.Count);
        //Debug.Log("Lethal" + lethal.Count);


        if (dangerous.Count == 0 && lethal.Count == 0)
        {
            //step = BasicChoise();
        }
        step = BasicChoise();
        //Might actually be better to just follow plan. Maybe could add couple of differetn plans or somehting
        /*else if(lethal.Count > 0)
        {
            if(lethal.Count < weapons.Count)
            {
                step = ChooseFromList(lethal);
            } else
            {
                step = BasicChoise();
            }

        } else if(dangerous.Count > 0)
        {
            if(dangerous.Count < weapons.Count)
            {
                step = ChooseFromList(dangerous);
            } else
            {
                step = BasicChoise();
            }
        }*/

        lastPlayerChoise = playerChoise;

        return step;
    }

    private int BasicChoise()
    {
        //Debug.Log("Basic choise");
        float choise = Random.Range(0.01f, 1f);
        int choiseIndex = 0;
        int step = 0;
        //To give some random element to AI's plan
        if (choise <= 0.1f)
        {
            //choiseIndex = Random.Range(1, 3);
        }

        //choiseIndex = 3;

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

    ///////////////Needs something that takes into account players armor or somehting and weights possibilities against each other///////
    private int ChooseFromList(List<Weapon> list)
    {
        int temp = 0;
        int index = Random.Range(0, list.Count-1); //Temporary before more choise functions

        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].GetComponent<Weapon>() == list[index]) temp = i;
        }
        return temp;
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


    private int UseStrongestWeapon(Weapon strongest)
    {
        int temp = 0;

        for (int i = 0; i < weapons.Count; i++)
        {
            if (strongest == weapons[i].GetComponent<Weapon>())
            {
                temp = i;
                break;
            }
        }

        return temp;
    }

    private int UseWeakestWeapon(Weapon strongest1, Weapon strongest2)
    {
        List<GameObject> weakWeapons = new List<GameObject>();
        GameObject chosen = null;
        int temp = 0;

        for (int i = 0; i < weapons.Count; i++)
        {
            if (strongest1 != weapons[i].GetComponent<Weapon>() && strongest2 != weapons[i].GetComponent<Weapon>())
            {
                weakWeapons.Add(weapons[i]);
            }
        }

        //If there are nore than one weak weapon, choose one at random
        if(weakWeapons.Count > 1)
        {
            int index = Random.Range(0, weakWeapons.Count-1);
            chosen = weakWeapons[index];
            for (int i = 0; i < weapons.Count; i++)
            {
                if (chosen.GetComponent<Weapon>() == weapons[i].GetComponent<Weapon>())
                {
                    temp = i;
                    break;
                }
            }
        }


        return temp;
    }

    //Returns list of weapons which can kill enemy
    private List<Weapon> CanBeKilledWith()
    {
        List<Weapon> list = new List<Weapon>();
        List<Weapon> counters = new List<Weapon>();

        
        //Collect dangerous weapons
        PlayerContoller player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        int currentHealth = controller.GetComponent<EnemyController>().GiveCurrentHealth();

        List<Weapon> playerWeapons = player.GetWeapons();
        for (int i = 0; i < playerWeapons.Count; i++)
        {
            Weapon w = playerWeapons[i];
            if(w.damage >= currentHealth)
            {
                list.Add(w);
            }
        }

        //Collect counters to those weapons
        for(int i = 0; i < list.Count; i++)
        {
            counters.AddRange(FindCountersTo(list[i]));
        }

        return counters.Distinct().ToList();
    }

    //Return list of weapons which can kill player
    private List<Weapon> CanKillWith()
    {
        List<Weapon> list = new List<Weapon>();

        int playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GiveCurrentHealth();
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");

        for (int i = 0; i < weapons.Count; i++)
        {
            Weapon w = weapons[i].GetComponent<Weapon>();
            if (w.damage >= playerHealth)
            {
                list.Add(w);
            }
        }

        return list;
    }

    //Finds all available counters to selected counter
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
        }

        return temp;
    }

}
