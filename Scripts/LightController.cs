using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
	GameObject settings;
	public float base_intensity = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        settings = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = settings.GetComponent<SoundSettings>().brightness;
    }
}
