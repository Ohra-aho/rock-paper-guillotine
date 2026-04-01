using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handcerchife : MonoBehaviour
{
    private void Awake()
    {
        /*GetComponent<BuffController>().special = IncreaseStack;
        GetComponent<BuffController>().takeDamage = true;
        GetComponent<BuffController>().dealDamage = true;
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return true; };*/
    }

    public void IncreaseStack()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Stacking>().IncreaseStacks(player.GetComponent<PlayerContoller>().HB.GiveMaxHealth() - player.GetComponent<PlayerContoller>().GiveCurrentHealth());
        if(GetComponent<Stacking>().stacks == 10)
        {
            GetComponent<Stacking>().stacks = 0;
            GetComponent<EffectDamage>().DealDamage(null);
        }
    }
}
