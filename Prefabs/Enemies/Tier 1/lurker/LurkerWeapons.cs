using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LurkerWeapons : MonoBehaviour
{
    public void Tail()
    {
        Lurker l = GameObject.Find("Lurker(Clone)").GetComponent<Lurker>();
        l.tail_hit = 2;
    }

    public void Scales()
    {
        Lurker l = GameObject.Find("Lurker(Clone)").GetComponent<Lurker>();
        l.taken_damage = false;
    }

    public void TakeDamage()
    {
        Lurker l = GameObject.Find("Lurker(Clone)").GetComponent<Lurker>();
        l.taken_damage = true;
    }
}
