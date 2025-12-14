using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    public GameObject buff;

    public void ApplyBuff()
    {
        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
        int index = Random.Range(0, weapons.Count);
        
        GameObject new_buff = Instantiate(buff, weapons[index].transform);
        new_buff.GetComponent<Buff>().id = GetComponent<Weapon>().name;
        new_buff.GetComponent<Buff>().damage_buff = 1;
        new_buff.GetComponent<Buff>().temporary = true;
        new_buff.GetComponent<Buff>().timer = 100;
        new_buff.GetComponent<Buff>().AddBuff();
    }
}
