using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncHandler : MonoBehaviour
{
	public GameObject loading_screen;
    public void DisplayLoadingScreen()
	{
		loading_screen.SetActive(true);
		StartCoroutine(LoadMainScene());
	}

	IEnumerator LoadMainScene()
	{
		AsyncOperation load_operation = SceneManager.LoadSceneAsync("SampleScene");
		while(!load_operation.isDone)
		{
			yield return null;
		}
	}
}
