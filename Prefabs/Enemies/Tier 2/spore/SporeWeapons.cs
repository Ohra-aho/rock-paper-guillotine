using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeWeapons : MonoBehaviour
{
    public void OffBalance()
    {
        switch(GetComponent<Weapon>().name)
        {
            case "Spikes": GetComponent<Weapon>().owner.GetComponent<Spore>().spike_damaged = true;
                break;
            case "Fungus":
                GetComponent<Weapon>().owner.GetComponent<Spore>().fungus_damaged = true;
                break;
        }
        if(GetComponent<Weapon>().owner.GetComponent<Spore>().spike_damaged && GetComponent<Weapon>().owner.GetComponent<Spore>().fungus_damaged)
        {
            GetComponent<Weapon>().owner.GetComponent<BasicEnemy>().OffBalance();
        }
    }
}
