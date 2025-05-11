using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrogance : MonoBehaviour
{
    bool choise_phase = true;
    int current_HP;
    private void Awake()
    {
        GetComponent<BuffController>().special_apply = true;
        GetComponent<BuffController>().special = SwitchFunction;
        GetComponent<BuffController>().choisePhase = true;
        GetComponent<BuffController>().endPhase = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 1;
    }

    public void WearMask()
    {
        GameObject RIE = GameObject.FindGameObjectWithTag("RIE");
        /*for (int i = 0; i < RIE.transform.childCount; i++)
        {
            RIE.transform.GetChild(i).GetComponent<BuffController>().Unequip();
        }*/
        GetComponent<BuffController>().Equip();
    }

    public void DealDamage(Weapon weapon)
    {
        weapon.EffectDamage(1);
    }

    public void SwitchFunction(Weapon weapon)
    {
        if(choise_phase)
        {
            GetCurrentHP();
            choise_phase = false;
        } else
        {
            if(!DamageTaken())
            {
                DealDamage(weapon);
            }
            choise_phase = true;
        }
    }

    public void GetCurrentHP()
    {
        EnemyController enemy = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        current_HP = enemy.HB.GiveCurrentHealth();
    }

    public bool DamageTaken()
    {
        EnemyController enemy = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        if(current_HP > enemy.HB.GiveCurrentHealth())
        {
            return true;
        } else
        {
            return false;
        }
    }
}
