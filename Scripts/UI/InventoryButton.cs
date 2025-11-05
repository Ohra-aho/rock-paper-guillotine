using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public bool open = false;
    public PlayerWheelHolder PWH;
    public MainController MC;

    public void Press()
    {
        if(
            MC.game_state != MainController.State.dead && 
            MC.game_state != MainController.State.stalling && 
            MC.game_state != MainController.State.dialog && 
            MC.game_state != MainController.State.dead && 
            MC.game_state != MainController.State.transition
        )
        {
            if (open)
            {
                PWH.CloseDrawer();
            }
            else
            {
                PWH.OpenDrawer();
            }
            open = !open;
        }
        
    }
}
