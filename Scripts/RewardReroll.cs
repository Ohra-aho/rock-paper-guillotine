using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardReroll : MonoBehaviour
{
    MainController MC;
    public bool reward_open = true;

    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();
    }

    private void Update()
    {
        GetComponent<NonUIButton>().interactable = MC.game_state == MainController.State.reward && reward_open;
    }

    public void Reroll()
    {
        GameObject[] reward_menus = GameObject.FindGameObjectsWithTag("Rewards");
        for(int i = 0; i < reward_menus.Length; i++)
        {
            reward_menus[i].GetComponent<Test>().UnPauseAnimation();
        }
        MC.SpawnRewardMenu();

    }
}
