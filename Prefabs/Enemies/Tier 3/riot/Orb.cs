using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public void HealOpponent()
    {
        int damage = GetComponent<DamageInteractions>().CalculateTakenDamage();
        if(damage <= 0)
        {
            GameObject.Find("Table").GetComponent<TableController>().player_healing++;
            if(GetComponent<Weapon>().opponent.player_owner.GetComponent<PlayerContoller>().HB.ValidHeal())
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>().playerChoise.heal.Invoke();
            }
        }
    }

    public void StackForDeath()
    {
        GetComponent<Stacking>().IncreaseStacks(1);
        if(GetComponent<Stacking>().stacks == 3)
        {
            GetComponent<Weapon>().owner.HB.InstaKill();
        }
    }
}
