using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDetector : MonoBehaviour
{
    public int weaponToDetect;
    public int detectionCount = 0;
    public GameObject weaponWheel;
    public GameObject playerWheelHolder;

    TableController TC;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!playerWheelHolder.GetComponent<PlayerWheelHolder>().detached)
        {
            if(other.GetComponent<WeaponSprite>())
            {
                if (other.GetComponent<WeaponSprite>().id == weaponToDetect)
                {
                    detectionCount++;
                }
                if (detectionCount == 2 && weaponToDetect != 0)
                {
                    TC = GameObject.FindGameObjectWithTag("Table").GetComponent<TableController>();
                    weaponWheel.GetComponent<Test>().PauseAnimation();
                    TC.resultsVisible++;
                }
            }   
        }
    }

    void OnTriggerStay(Collider other)
    {
    }

    void OnTriggerExit(Collider other)
    {
    }

}
