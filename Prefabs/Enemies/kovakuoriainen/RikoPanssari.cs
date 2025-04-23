using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RikoPanssari : MonoBehaviour
{
    private void Awake()
    {
        transform.parent.GetComponent<EnemyController>().damageEffect = BreakArmor;
    }

    public void BreakArmor()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        for(int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<Weapon>().armor = 0;
        }
    }
}
