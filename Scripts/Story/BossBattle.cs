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
}
