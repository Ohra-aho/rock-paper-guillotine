using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemy : MonoBehaviour
{
    float kiviPref = 0f;
    float paperiPref = 0f;
    float saksetPref = 0f;

    List<MainController.Choise> playerChoises = new List<MainController.Choise>();

    private void Start()
    {
        TransferInfo();
    }

    private void TransferInfo()
    {
        transform.parent.GetComponent<EnemyController>()
            .choiseEffect = GetPlayerChoise;
    }

    private void GetPlayerChoise()
    {
        Weapon playersChoise = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerContoller>().chosenWeapon.GetComponent<Weapon>();
        playerChoises.Add(playersChoise.type);
        AdjustToMostUsedWeapon(playersChoise.type);
    }

    private void AdjustToMostUsedWeapon(MainController.Choise choise)
    {
        switch(choise)
        {
            case MainController.Choise.kivi: paperiPref += 0.03f; break;
            case MainController.Choise.paperi: saksetPref += 0.03f; break;
            case MainController.Choise.sakset: kiviPref += 0.03f; break;
        }
    }

 

    

}
