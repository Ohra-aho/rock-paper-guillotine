using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuLayer : MonoBehaviour
{
	SoundSettings SS;
	public UnityEvent awake;
	public void Awake()
	{
		awake.Invoke();
	}

	public void Main()
	{
		SS = GameObject.Find("EventSystem").GetComponent<SoundSettings>();
		for(int i = 0; i < SS.soundTargets.Count; i++)
		{
			switch(SS.soundTargets[i].name)
			{
				case "Master volume": transform.GetChild(1).GetComponent<SliderController>().target = SS.soundTargets[i]; break;
				case "Music": transform.GetChild(2).GetComponent<SliderController>().target = SS.soundTargets[i]; break;
				case "Sound effects": transform.GetChild(3).GetComponent<SliderController>().target = SS.soundTargets[i]; break;
			}
		}
		transform.GetChild(4).GetComponent<SliderController>().brightness = SS.brightness;

		transform.GetChild(1).GetComponent<SliderController>().Inisiate();
		transform.GetChild(2).GetComponent<SliderController>().Inisiate();
		transform.GetChild(3).GetComponent<SliderController>().Inisiate();
		transform.GetChild(4).GetComponent<SliderController>().Inisiate();
	}

    //Add to each layer to be used in layermenu
    public void ChangeLayer(int index)
    {
        LayeredMenu LM = transform.parent.gameObject.GetComponent<LayeredMenu>();
        Destroy(LM.currentLayer);
        LM.currentLayer = Instantiate(LM.layers[index], this.transform.parent);
    }

    public void CloseMenu()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseController>().Resume();
    }

    public void QuitGame()
    {
        transform.parent.GetComponent<LayeredMenu>().QuitGame();
    }

	public void Resume()
    {
		SaveSystem.SaveSoundSettings(new SoundData(SS.soundTargets, SS.brightness));
        SS.GetComponent<PauseController>().Resume();
    }
}

