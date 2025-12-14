using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monument : MonoBehaviour
{
    public void TriggerAllEndTurnEffects()
    {
        List<Weapon> weapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>().GetWeapons();
        for(int i = 0; i < weapons.Count; i++)
        {
            if(weapons[i].name != GetComponent<Weapon>().name)
            {
                if (weapons[i].endPhase != null)
                {
                    if (weapons[i].GetComponent<SelfDestruct>())
                    {
                        if (!weapons[i].GetComponent<SelfDestruct>().disabled)
                        {
                            weapons[i].GetComponent<SelfDestruct>().disabled = true;
                            weapons[i].endPhase.Invoke();
                            weapons[i].GetComponent<SelfDestruct>().disabled = false;
                        }
                        else
                        {
                            weapons[i].endPhase.Invoke();
                        }
                    }
                    else
                    {
                        weapons[i].endPhase.Invoke();
                    }
                }
            }
        }
    }
}
