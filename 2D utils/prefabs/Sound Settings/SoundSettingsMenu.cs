using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettingsMenu : MonoBehaviour
{
    SoundSettings SS;
    public GameObject soundSlider;
    public string settings = "EventSystem";
    // Start is called before the first frame update
    void Awake()
    {
        SS = GameObject.Find(settings).GetComponent<SoundSettings>();

        //Get sound targets from SoundSettings and makes settings bar for each sound target
        for(int i = 0; i < SS.soundTargets.Count; i++)
        {
            //MakeSettingBar(SS.soundTargets[i]);
        }
        transform.GetChild(0).GetComponent<ScrollView>().AdjustScrollSize();
    }

    
}



