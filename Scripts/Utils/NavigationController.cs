using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{
	public GameObject async_handler;
    public void changeScene(string scene)
    {
		async_handler.GetComponent<AsyncHandler>().DisplayLoadingScreen();
        //SceneManager.LoadScene(scene);
    }

    public void ReloadCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
