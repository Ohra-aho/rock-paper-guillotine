using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public void SelfDestruct()
    {
        GameObject.Find("PlayerWheelHolder").GetComponent<PlayerWheelHolder>().RemoveWeapon(this.gameObject);
    }
}
