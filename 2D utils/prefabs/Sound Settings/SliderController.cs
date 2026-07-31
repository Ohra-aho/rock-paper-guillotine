using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SliderController : MonoBehaviour
{
	public SoundTarget target;

    //Setting requirements
    public string settings = "EventSystem";

	public float brightness;

	public UnityEvent on_change;

    //public Sprite
    // Start is called before the first frame update

	public void Inisiate()
	{
		if(name != "Brightness")
		{
			transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = target.name;
			transform.GetChild(1).GetComponent<Slider>().value = target.volume;
			transform.GetChild(3).GetComponent<Toggle>().isOn = target.mute;
			transform.GetChild(3).GetComponent<Toggle>().onValueChanged.AddListener((bool b) => {MuteSound();});
			DisplayValues(target.volume);
		} else
		{
			transform.GetChild(1).GetComponent<Slider>().value = brightness;
			DisplayValues(brightness);
		}
		
		transform.GetChild(1).GetComponent<Slider>().onValueChanged.AddListener(
			(float x) => {
				on_change.Invoke();
				DisplayValues(x);
			}
		);
		
	}

    private void DisplayValues(float x)
    {
		if(name != "Brightness")
		{
			if(target.volume != x)
			{
				target.volume = x;
			}
			transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = (target.volume*100).ToString("F0");
			GameObject.Find(settings).GetComponent<SoundSettings>().ChangeValues(target.name, target.mute, target.volume);	
		} else
		{
			transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = (x*100).ToString("F0");
			GameObject.Find(settings).GetComponent<SoundSettings>().brightness = x;
		}
    }

    public void MuteSound()
    {
        target.mute = !target.mute;
		DisplayValues(target.volume);
    }
}
