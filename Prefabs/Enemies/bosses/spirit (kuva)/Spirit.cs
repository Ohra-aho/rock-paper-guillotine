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

    GameObject controller;

    private void Awake()
    {
        //controller = GameObject.FindGameObjectWithTag("EnemyHolder");
        //controller.GetComponent<EnemyController>().choiseMaker = MakeChoise;
    }

    public int MakeChoise(MainController.Choise c)
    {
        switch(active_mask)
        {
            case 0:
                int mask = 0;
                while (mask == last_mask)
                {
                    mask = Random.Range(3, 6);
                }
                mask_timer = Random.Range(3, 7);
                last_mask = mask;
                active_mask = mask;
                return last_mask;
            case 1:
                return ContinuePlan(1);
            case 2:
                return ContinuePlan(2);
            case 3:
                return ContinuePlan(3);
        }
        return GetComponent<BasicEnemy>().MakeChoise(c);
    }

    private int ContinuePlan(int plan)
    {
        switch(plan)
        {
            case 1:
                int? choise = FearChoise();
                return choise ?? ComputePlan(fear_plan, fear_index);
            case 2: return ComputePlan(anger_plan, anger_index);
            case 3: return ComputePlan(arrogance_plan, arrogance_index);
            default: return 0;
        }
    }

    private int ComputePlan(List<int> plan, int index)
    {
        mask_timer--;
        if(mask_timer <= 0)
        {
            active_mask = 0;
        }
        int step = plan[index];
        index++;
        if (index >= plan.Count) index = 0;
        return step;
    }

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
