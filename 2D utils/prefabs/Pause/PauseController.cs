using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    public static bool paused = false;

    public GameObject? pauseMenu;
    private GameObject? currentMenu;

    public MainController.State last_state;

    public GameObject main_menu;
    public GameObject museum_menu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && GetComponent<MainController>().game_state != MainController.State.dead)
        {
            if(paused) Resume();
            else Pause();
        }
    }

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (GetComponent<StoryCheckList>().executioner_dead)
            {
                main_menu.SetActive(false);
                museum_menu.SetActive(true);
            }
        }
    }

    public void Pause()
    {
		if(GetComponent<MainController>())
		{
			last_state = GetComponent<MainController>().game_state;
        	GetComponent<MainController>().SetNewState(MainController.State.pause);	
		}
        Time.timeScale = 0f;
        paused = true;
        if(pauseMenu != null)
        {
            currentMenu = Instantiate(pauseMenu, GameObject.Find("Canvas").transform);
        }
    }

    public void Resume()
    {
		if(GetComponent<MainController>())
		{
        	GetComponent<MainController>().SetNewState(last_state);
		}
        Time.timeScale = 1f;
        paused = false;
        if(currentMenu != null)
        {
            Destroy(currentMenu);
        }
    }
}
