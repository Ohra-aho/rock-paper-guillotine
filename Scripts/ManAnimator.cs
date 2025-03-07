using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAnimator : MonoBehaviour
{
    Coroutine current_animation;
    Coroutine current_sequence;
    Coroutine current_frame;
    bool sequence_running = false;
    bool animation_running = false;
    bool frame_running = false;


    public Sprite[] man_sheet;
    public Sprite[] man_heads;
    //0 neutral
    //1 head right neutral
    public AudioClip man_pondering;
    // Start is called before the first frame update
    void Start()
    {
        //StartNewAnimation(ManPondering());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartNewAnimation(IEnumerator new_animation)
    {
        if (current_animation != null) StopCoroutine(current_animation);
        current_animation = StartCoroutine(new_animation);
        animation_running = true;
    }

    private void ChangeHeadSprite(Sprite new_sprite)
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = new_sprite;
    }

    private void ChangeTorsoSprite(Sprite new_sprite)
    {
        GetComponent<SpriteRenderer>().sprite = new_sprite;
    }

    private void PlayAudio(AudioClip clip)
    {
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
    }

    private void AnimationEnd()
    {
        StopCoroutine(current_sequence);
        StopCoroutine(current_animation);
        StopCoroutine(current_frame);
        animation_running = false;
    }

    IEnumerator PlaySequence(List<Frame> frames)
    {
        sequence_running = true;
        for(int i = 0; i < frames.Count; i++)
        {
            frame_running = true;
            current_frame = StartCoroutine(PlayFrame(frames[i]));
            yield return new WaitUntil(() => frames[i].over);
            frame_running = false;
        }
        sequence_running = false;
    }

    IEnumerator PlayFrame(Frame frame)
    {
        if(frame.head) ChangeHeadSprite(frame.sprite);
        else ChangeTorsoSprite(frame.sprite);
        yield return new WaitForSeconds(frame.delay);
        frame.over = true;
        StopCoroutine(current_frame);
    }

    IEnumerator FrameTillEndOfAudio(Sprite sprite)
    {
        frame_running = true;
        ChangeHeadSprite(sprite);
        yield return new WaitWhile(() => GetComponent<AudioSource>().isPlaying);
        StopCoroutine(current_frame);
        frame_running = false;
    }

    IEnumerator ManPondering()
    {
        //Make list of frames
        List<Frame> pondering = new List<Frame> {
            new Frame(man_heads[0], 1f, true),
        };
        PlayAudio(man_pondering);
        current_sequence = StartCoroutine(PlaySequence(pondering));
        yield return new WaitWhile(() => sequence_running);
        current_frame = StartCoroutine(FrameTillEndOfAudio(man_heads[1]));
        yield return new WaitWhile(() => frame_running);
        ChangeHeadSprite(man_heads[0]);
        AnimationEnd();
    }

    public void ManMessage(int id)
    {
        switch(id)
        {
            case 0:
                current_animation = StartCoroutine(ManPondering());
                break;
        }
    }

    class Frame 
    {
        public Sprite sprite; //What sprite man is changed to
        public float delay; //How long that sprite appears
        public bool head; //Will sprite be put to heads place
        public bool over;

        public Frame(Sprite sprite, float delay, bool head)
        {
            this.sprite = sprite;
            this.delay = delay;
            this.head = head;
            this.over = false;
        }
    }

}
