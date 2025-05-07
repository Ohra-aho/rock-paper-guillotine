using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TableController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    [HideInInspector] public int resultsVisible = 0;
    bool resulting = false;
    bool? result = false;

    MainController MC;
    Coroutine table;

    private void Update()
    {
        table = null;
        if (resultsVisible > 0 && !resulting)
        {
            if(resultsVisible == 2)
            {
                resulting = true;
                table = StartCoroutine(DisplayAll());
            }
        }
    }

    public void ClearDisplay()
    {
        resultsVisible = 0;
        resulting = false;
    }

    public void CallDisplay(bool? r)
    {
        result = r;
    }

    IEnumerator DisplayAll() {
        MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();

        yield return new WaitForSeconds(0.2f);
        MC.DisplayConsequenses(result);

        //Might need something...
        player.GetComponent<PlayerContoller>().ResultPhase();
        enemy.GetComponent<EnemyController>().ResultPhase();

        player.GetComponent<PlayerContoller>().EndPhase();
        enemy.GetComponent<EnemyController>().EndPhase();

        ActivateEachTurnEffects(GameObject.FindGameObjectWithTag("RI"));
        ActivateEachTurnEffects(GameObject.FindGameObjectWithTag("RIE"));

        if (table != null) StopCoroutine(table);
    }

    private void ActivateEachTurnEffects(GameObject weapon_holder)
    {
        for(int i = 0; i < weapon_holder.transform.childCount; i++)
        {
            if(weapon_holder.transform.GetChild(i).GetComponent<Weapon>().eachTurn != null)
            {
                weapon_holder.transform.GetChild(i).GetComponent<Weapon>().eachTurn.Invoke();
            }
        }
    }
}
