using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Sprite closed;
    public Sprite open;

    private bool opened;

    public GameObject man;
    public GameObject musicPlayer;

    public void Interact()
    {
        if(!opened)
        {
            musicPlayer.GetComponent<AudioPlayer>().StopClip();
            GetComponent<Image>().sprite = open;
            opened = true;
            man.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        } else
        {
            GetComponent<NavigationController>().changeScene("SampleScene");
        }
    }

}
