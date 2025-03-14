using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teramyrsky : MonoBehaviour
{
    public int damage_bonus;
    private void Awake()
    {
        GetComponent<BuffController>().damage_bonus = damage_bonus;
        GetComponent<BuffController>().awake = true;
        GetComponent<BuffController>().buff_requirement = (Weapon weapon) => {
            if (!weapon.gameObject.GetComponent<SelfDestruct>() && weapon.name != this.GetComponent<Weapon>().name) return true;
            else return false;
        };
        GetComponent<BuffController>().special = AddSelfDestruct;
        GetComponent<BuffController>().special_removal = RemoveSeflDestruct;
    }

    public void AddSelfDestruct(Weapon weapon)
    {
        weapon.gameObject.AddComponent<SelfDestruct>();
        weapon.dealDamage.AddListener(weapon.GetComponent<SelfDestruct>().Destruct);
    }

    public void RemoveSeflDestruct(Weapon weapon)
    {
        if(weapon.dealDamage.GetPersistentEventCount() > 0) weapon.dealDamage.RemoveListener(weapon.GetComponent<SelfDestruct>().Destruct);
        Destroy(weapon.gameObject.GetComponent<SelfDestruct>());
    }
}
