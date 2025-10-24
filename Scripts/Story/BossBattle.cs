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
        GameObject.Find("EventSystem").GetComponent<RLController>().bosses_killed++;
        if(GameObject.Find("EventSystem").GetComponent<RLController>().picks < tier)
        {
            GameObject.Find("EventSystem").GetComponent<RLController>().picks++;
        }
    }
}
