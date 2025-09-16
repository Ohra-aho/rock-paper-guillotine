using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claws : MonoBehaviour
{
    bool draw = false;
    public void DealHalfDamage()
    {
        if(!draw)
        {
            GetComponent<EffectDamage>().amount = GetComponent<Weapon>().damage / 2;
            GetComponent<EffectDamage>().DealDamage(null);
        }
        draw = false;
    }

    public void DrawTrigger()
    {
        MainController MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        if(MC.playerChoise.type == MainController.Choise.sakset)
        {
            draw = true;
        }
    }

    
}
