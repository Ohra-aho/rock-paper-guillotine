using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origami : MonoBehaviour
{
    bool flipped = false;

    public void Flip()
    {
        if(!flipped)
        {
            GetComponent<Weapon>().damage -= 2;
            GetComponent<Weapon>().armor += 2;
        } else
        {
            GetComponent<Weapon>().damage += 2;
            GetComponent<Weapon>().armor -= 2;
        }
        flipped = !flipped;
    }
}
