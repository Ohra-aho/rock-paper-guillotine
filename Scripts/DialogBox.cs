using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBox : MonoBehaviour
{

    Coroutine animation;
    [HideInInspector] public bool animation_playing;
    Coroutine text_anim;
    [HideInInspector] public bool text_anim_playing;

    string current_line;

    public void FinishTextAnimation()
    {
        StopCoroutine(text_anim);
        text_anim_playing = false;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = current_line;
    }

    public void StartAnimation(int anim)
    {
        switch(anim)
        {
            case 0:
                animation = StartCoroutine(Appear());
                break;
            case 1:
                animation = StartCoroutine(Dissapear());
                break;
        }
    }

    public void StartTextAnimation(string text, float? time)
    {
        text_anim = StartCoroutine(DisplayText(text, time));
    }

    IEnumerator Dissapear()
    {
        animation_playing = true;
        float alpha = 0.8f;
        while(alpha > 0)
        {
            alpha -= 0.1f;
            GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, alpha);
            }
            yield return new WaitForSeconds(0.05f);
        }
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
        animation_playing = false;
        if (animation != null) StopCoroutine(animation);
    }

    IEnumerator Appear()
    {
        animation_playing = true;
        float alpha = 0;
        while (alpha < 0.8f)
        {
            alpha += 0.1f;
            GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, alpha);
            }
            yield return new WaitForSeconds(0.05f);
        }
        animation_playing = false;
        if (animation != null) StopCoroutine(animation);
    }

    IEnumerator DisplayText(string text, float? delay)
    {
        yield return new WaitWhile(() => animation_playing);
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
        current_line = text;
        text_anim_playing = true;
        for(int i = 0; i < text.Length; i++)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text += text[i];
            yield return new WaitForSeconds(delay ?? 0.03f);
        }
        text_anim_playing = false;
        if (text_anim != null) StopCoroutine(text_anim);
    }
}
