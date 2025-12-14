using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCutter : MonoBehaviour
{
    int previous_health = 0;
    public void CalculateDamage()
    {
        int max_hp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().HB.GiveMaxHealth();
        if(max_hp != previous_health)
        {
            int difference = previous_health - max_hp;
            GetComponent<Weapon>().damage += difference;
            if (GetComponent<Weapon>().damage < 0) GetComponent<Weapon>().damage = 0;
            previous_health = max_hp;
        }
    }
}
