using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PreActiveEnemy : MonoBehaviour
{
    float kiviPref = 0f;
    float paperiPref= 0f;
    float saksetPref = 0f;

    // Start is called before the first frame update
    void Start()
    {
        AdjustToStrongestWeapon(
                SortPlayerWeapons()
            );
        AdjustToMostCommonType(
                GetWeaponTypes()
            );

        kiviPref = 0f;
        paperiPref = 0f;
        saksetPref = 0f;
    }

    private List<Weapon> SortPlayerWeapons()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        List<Weapon> playerWeapons = player.GetComponent<PlayerContoller>().GetWeapons();
        playerWeapons = playerWeapons.OrderBy(x => x.damage).ToList();
        return playerWeapons;
    }

    private List<MainController.Choise> GetWeaponTypes()
    {
        List<MainController.Choise> temp = new List<MainController.Choise>();

        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        List<Weapon> playerWeapons = player.GetComponent<PlayerContoller>().GetWeapons();

        for (int i = 0; i < playerWeapons.Count; i++)
        {
            temp.Add(playerWeapons[i].type);
        }

        return temp;
    }

    private void AdjustToStrongestWeapon(List<Weapon> playerWeapons)
    {
        //Check if damages are mostly same
        bool same = false;
        int similarDamage = 0;
        for(int i = 0; i < playerWeapons.Count; i++)
        {
            if(playerWeapons[i].damage == playerWeapons[playerWeapons.Count-1].damage)
            {
                similarDamage++;
            }
        }

        if(similarDamage >= playerWeapons.Count * 0.6f)
        {
            same = true;
        }

        if(!same)
        {
            Debug.Log("Not Same");
            switch (playerWeapons[playerWeapons.Count - 1].type)
            {
                case MainController.Choise.kivi: paperiPref += 0.1f; break;
                case MainController.Choise.paperi: saksetPref += 0.1f; break;
                case MainController.Choise.sakset: kiviPref += 0.1f; break;
            }
        }
    }

    private void AdjustToMostCommonType(List<MainController.Choise> types)
    {
        int kivet = types.Count(x => x == MainController.Choise.kivi);
        int paperit = types.Count(x => x == MainController.Choise.paperi);
        int sakset = types.Count(x => x == MainController.Choise.sakset);

        if (kivet > sakset) paperiPref += 0.05f;
        if (kivet > paperit) paperiPref += 0.05f;
        if (paperit > kivet) saksetPref += 0.05f;
        if (paperit > sakset) saksetPref += 0.05f;
        if (sakset > kivet) kiviPref += 0.05f;
        if (sakset > paperit) kiviPref += 0.05f;
    }

    
}
