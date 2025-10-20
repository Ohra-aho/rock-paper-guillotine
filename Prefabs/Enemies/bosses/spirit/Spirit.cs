using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public bool debuff_active = false;
    public MainController.Choise debuffed_type;

    public int active_mask = 0;
    private int last_mask = 0;

    public List<int> fear_plan; //1
    public List<int> anger_plan; //2
    public List<int> arrogance_plan; //3

    private int fear_index = 0;
    private int anger_index = 0;
    private int arrogance_index = 0;

    private int mask_timer = 0;
    private int previous_health = 12;

    GameObject controller;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    public int MakeChoise(MainController.Choise c)
    {
        int health = controller.GetComponent<EnemyController>().HB.GetComponent<HealthBar>().GiveCurrentHealth();
        if (health < previous_health)
        {
            if (previous_health > 8 && health <= 8 && health > 4)
            {
                active_mask = 0;
            }
            else if (previous_health > 4 && health <= 4)
            {
                active_mask = 0;
            }
        }
        previous_health = health;

        switch (active_mask)
        {
            case 0:
                /*int mask = 0;
                while (mask == last_mask)
                {
                    mask = Random.Range(3, 6);
                }
                mask_timer = Random.Range(3, 7);
                last_mask = mask;
                active_mask = mask;*/
                //return last_mask;
                int choise = GetComponent<BasicEnemy>().MakeChoise(c);
                active_mask = choise;
                return choise;
            case 3:
                return ContinuePlan(1);
            case 4:
                return ContinuePlan(2);
            case 5:
                return ContinuePlan(3);
            default: 
                return GetComponent<BasicEnemy>().MakeChoise(c);
        }
    }

    private int ContinuePlan(int plan)
    {
        switch(plan)
        {
            case 1:
                //int? choise = FearChoise();
                return ComputePlan(anger_plan, 1);
            case 2: return ComputePlan(arrogance_plan, 2);
            case 3: return ComputePlan(fear_plan, 3);
            default: return 0;
        }
    }

    private int ComputePlan(List<int> plan, int mask)
    {

        /*mask_timer--;
        if(mask_timer <= 0)
        {
            active_mask = 0;
        }*/
        //Ei toimi
        
        switch (mask)
        {
            case 1:
                int i = anger_index;
                anger_index++;
                if (anger_index >= plan.Count) anger_index = 0;
                return plan[i];
            case 2:
                int j = arrogance_index;
                arrogance_index++;
                if (arrogance_index >= plan.Count) arrogance_index = 0;
                return plan[j];
            case 3:
                int k = fear_index;
                fear_index++;
                if (fear_index >= plan.Count) fear_index = 0;
                return plan[k];
            default: return 0; //Should never happen
        }
       
    }

    // Needs to account for multiple debuffed weapons
    private int? FearChoise()
    {
        switch(debuffed_type)
        {
            case MainController.Choise.kivi:
                if (Chance()) return 1;
                else return 0;
            case MainController.Choise.paperi:
                if (Chance()) return 0;
                else return 2;
            case MainController.Choise.sakset:
                if (Chance()) return 2;
                else return 1;
            default: return null;
        }
    }

    private bool Chance()
    {
        int chance = Random.Range(0, 3);
        return chance == 0;
    }
}
