using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public int tier;

    public void UpdateGear()
    {
        GetComponent<Encounter>().ChangeGear(tier);
    }

    public void DownGradeGear()
    {
        GetComponent<Encounter>().ResetGear();
    }

    public void AddBossKill()
    {
        if(tier == 1)
        {
            GameObject.Find("EventSystem").GetComponent<StoryCheckList>().first_boss_beaten = true;
        }
        GameObject.Find("EventSystem").GetComponent<RLController>().bosses_killed++;
        if(GameObject.Find("EventSystem").GetComponent<RLController>().picks < tier)
        {
            GameObject.Find("EventSystem").GetComponent<RLController>().picks++;
        }
    }
}
