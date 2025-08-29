using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    public GameObject buff;
    private List<Weapon> equipped_weapons = new List<Weapon>();

    private void Awake()
    {
        equipped_weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
    }

    public void DebuffOpposingWeapon()
    {
        equipped_weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();

        GameObject RI = GameObject.FindGameObjectWithTag("RI");
        int index = Random.Range(0, equipped_weapons.Count);

        for(int i = 0; i < RI.transform.childCount; i++)
        {
            GameObject weapon = RI.transform.GetChild(i).gameObject;

            if(weapon.GetComponent<Weapon>().name == equipped_weapons[index].name)
            {
                GameObject new_buff = Instantiate(buff, weapon.transform);
                new_buff.GetComponent<Buff>().timer = 1;
                new_buff.GetComponent<Buff>().type_change = MainController.Choise.hyödytön;
                new_buff.GetComponent<Buff>().AddBuff();
            }
        }
    }
}
