using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakeningCurse : MonoBehaviour
{
    string target_name = "";
    private void Awake()
    {
        GetComponent<BuffController>().damage_bonus = -1;
        GetComponent<BuffController>().temporary = true;
        GetComponent<BuffController>().timer = 10;
        GetComponent<BuffController>().special_apply = true;
    }

    public void ApplyBuffs()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        List<Weapon> equipped_weapons = player.GetComponent<PlayerContoller>().GetWeapons();
        target_name = equipped_weapons[Random.Range(0, equipped_weapons.Count)].name;
        Debug.Log(target_name);
        GetComponent<BuffController>().buff_requirement = (Weapon w) =>
        {
            return w.name == target_name;
        };
        GetComponent<BuffController>().Equip();
    }
}
