using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LayeredMenu : MonoBehaviour
{
    //Keeps track of layers in the menu
    public List<GameObject> layers;
    [HideInInspector] public GameObject currentLayer;

    private void Awake()
    {
        string scene = SceneManager.GetActiveScene().name;

        currentLayer = Instantiate(layers[0], this.transform);
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        controller.GetComponent<SoundSettings>().pause = true;
        if(scene == "MainMenu")
        {

        } else
        {
            controller.GetComponent<MainController>().buttons_active = false;
            GameObject.Find("StartButton").GetComponent<StartButton>().deactivated = true;
            GameObject.Find("man").GetComponent<ManAnimator>().paused = true;
        }
        

    }

    private void OnDestroy()
    {
        string scene = SceneManager.GetActiveScene().name;

        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        controller.GetComponent<SoundSettings>().pause = false;
        if (scene == "MainMenu")
        {

        }
        else
        {
            controller.GetComponent<MainController>().buttons_active = true;
            GameObject.Find("StartButton").GetComponent<StartButton>().deactivated = false;
            GameObject.Find("man").GetComponent<ManAnimator>().paused = false;
        }
    }
}
