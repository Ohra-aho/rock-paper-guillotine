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
    public List<float> actionIncreasePrefs; //Determines how likely each action preference is to change, if change is inisitaed
    public List<float> actionPrefs; //Determines chances for each action to take.

    public List<int> plan;
    private int planIndex = 0;

    MainController.Choise lastPlayerChoise = MainController.Choise.kivi;

   
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        TransferInfo();
        controller.GetComponent<EnemyController>().Inisiate();
        GetComponent<Image>().sprite = image;
    }

    public void TransferInfo()
    {
        controller.GetComponent<EnemyController>().maxHealth = maxHealth;
        controller.GetComponent<EnemyController>().weapons = weapons;
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    private int MakeChoise(MainController.Choise playerChoise)
    {
        float choise = Random.Range(0.01f, 1f);
        int choiseIndex = 0;

        //Chooses action according to actionPrefs
        for(int i = 0; i < actionPrefs.Count; i++)
        {
            if(choise <= actionPrefs[i]) choiseIndex = i;
        }

        int step = 0;
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

    public void MakeAdjustments(float kiviPref, float paperiPref, float saksetPref)
    {
        List<float> weaponPrefs = GetComponent<BasicEnemy>().actionPrefs;

        if (kiviPref > 0)
        {
            weaponPrefs[1] -= kiviPref / 2;
            weaponPrefs[2] -= kiviPref / 2;
        }
        if (paperiPref > 0)
        {
            weaponPrefs[1] += paperiPref / 2;
            weaponPrefs[2] -= paperiPref / 2;
        }
        if (saksetPref > 0)
        {
            weaponPrefs[1] -= saksetPref / 2;
            weaponPrefs[2] += saksetPref / 2;
        }


    }

    private void CapWeaponPrefs()
    {
        for(int i = 0; i < actionPrefs.Count; i++)
        {
            if(actionPrefs[i] > 1)
            {

            }
        }
    }

}
