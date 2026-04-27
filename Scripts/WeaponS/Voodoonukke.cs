using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voodoonukke : MonoBehaviour
{
    public int damage;
    private void Awake()
    {
        GetComponent<BuffController>().special = Retaliate;
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => { return true; };
    }

    public void Retaliate(Weapon weapon)
    {
        if (weapon.player)
        {
            GameObject MC = GameObject.Find("EventSystem");
            MC.GetComponent<MainController>().enemy.GetComponent<EnemyController>().HB.TakeDamage(GetComponent<EffectDamage>().amount);
        }
        else
        {
            GameObject.Find("Player").GetComponent<PlayerContoller>().HB.TakeDamage(GetComponent<EffectDamage>().amount);
        }
    }
}
