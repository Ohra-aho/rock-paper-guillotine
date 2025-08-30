using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictroyTrigger : MonoBehaviour
{
    public void VictoryTrigger()
    {
        GameObject.Find("Gambler(Clone)").GetComponent<Gambler>().won = true;
    }
}
