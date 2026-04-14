using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{
    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ReloadCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
