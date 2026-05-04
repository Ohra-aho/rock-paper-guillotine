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
        if (
            MC.game_state != MainController.State.dead &&
            MC.game_state != MainController.State.stalling &&
            MC.game_state != MainController.State.dialog &&
            MC.game_state != MainController.State.dead &&
            MC.game_state != MainController.State.transition &&
            MC.game_state != MainController.State.in_battle
        )
        {
            MC.SetNewState(MainController.State.re_arming);
            if (open)
            {
                PWH.CloseDrawer();
                PWH.AttachWheel();
            }
            else
            {
                PWH.OpenDrawer();
                PWH.DetachWheel();
            }
            open = !open;
        }
        
    }
}
