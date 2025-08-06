using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    public static bool paused = false;

    public GameObject? pauseMenu;
    private GameObject? currentMenu;

    MainController.State last_state;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused) Resume();
            else Pause();
            
        }
    }

    public void Pause()
    {
        last_state = GetComponent<MainController>().game_state;
        GetComponent<MainController>().SetNewState(MainController.State.pause);
        Time.timeScale = 0f;
        paused = true;
        if(pauseMenu != null)
        {
            currentMenu = Instantiate(pauseMenu, GameObject.Find("Canvas").transform);
        }
    }

    public void Resume()
    {
        GetComponent<MainController>().SetNewState(last_state);
        Time.timeScale = 1f;
        paused = false;
        if(currentMenu != null)
        {
            Destroy(currentMenu);
        }
    }
}
