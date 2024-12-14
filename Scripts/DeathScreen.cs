using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void TryAgain()
    {
        GetComponent<NavigationController>().changeScene("MainMenu");
    }
}
