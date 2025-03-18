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

    //0: All neutral
    //1: Head to right neutral
    //2: Right hand half up, open hand
    //3: Both hands up
    //4: Left hand point left
    //5: head tilt left neutral
    //6: left hand up fist
    public Sprite[] man_sheet;
    

    public AudioClip man_pondering;
    public AudioClip first_greeting;
    public AudioClip man_instructing_1;
    public AudioClip instructing_2;
    public AudioClip instructing_3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Stops current animation and starts a new one
    public void StartNewAnimation(IEnumerator new_animation)
    {
        if (current_animation != null) StopCoroutine(current_animation);
        current_animation = StartCoroutine(new_animation);
        animation_running = true;
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
        if(current_sequence != null) StopCoroutine(current_sequence);
        if(current_animation != null) StopCoroutine(current_animation);
        if(current_frame != null) StopCoroutine(current_frame);
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
        ChangeTorsoSprite(frame.sprite);
        yield return new WaitForSeconds(frame.delay);
        frame.over = true;
        StopCoroutine(current_frame);
    }

    IEnumerator FrameTillEndOfAudio(Sprite sprite)
    {
        frame_running = true;
        ChangeTorsoSprite(sprite);
        yield return new WaitWhile(() => GetComponent<AudioSource>().isPlaying);
        StopCoroutine(current_frame);
        frame_running = false;
    }

    public void ManMessage(int id)
    {
        switch (id)
        {
            case 0:
                StartNewAnimation(ManPondering());
                break;
            case 1:
                StartNewAnimation(MansFirstGreeting());
                break;
            case 2:
                StartNewAnimation(ManInstructing1());
                break;
            case 3:
                StartNewAnimation(ManInstructing2());
                break;
            case 4:
                StartNewAnimation(ManInstructing3());
                break;
        }
    }

    //Animations

    IEnumerator ManPondering()
    {
        //Make list of frames
        List<Frame> pondering = new List<Frame> {
            new Frame(man_sheet[0], 1f),
        };
        PlayAudio(man_pondering);
        current_sequence = StartCoroutine(PlaySequence(pondering));
        yield return new WaitWhile(() => sequence_running);
        current_frame = StartCoroutine(FrameTillEndOfAudio(man_sheet[2]));
        yield return new WaitWhile(() => frame_running);
        ChangeTorsoSprite(man_sheet[0]);
        AnimationEnd();
    }

    IEnumerator MansFirstGreeting()
    {
        List<Frame> frames = new List<Frame>
        {
            new Frame(man_sheet[2], 0.7f),
            new Frame(man_sheet[0], 3.2f),
            new Frame(man_sheet[1], 1.7f),
            new Frame(man_sheet[3], 2f),
            new Frame(man_sheet[0], 2.5f),
            new Frame(man_sheet[4], 1.5f)
        };
        PlayAudio(first_greeting);
        current_sequence = StartCoroutine(PlaySequence(frames));
        yield return new WaitWhile(() => sequence_running);
        ChangeTorsoSprite(man_sheet[0]);
        AnimationEnd();
    }

    IEnumerator ManInstructing1()
    {
        List<Frame> frames = new List<Frame>
        {
            new Frame(man_sheet[5], 1f),
            new Frame(man_sheet[0], 0.5f),
            new Frame(man_sheet[1], 2f),
            new Frame(man_sheet[0], 1.3f),
            new Frame(man_sheet[6], 1.7f)
        };
        PlayAudio(man_instructing_1);
        current_sequence = StartCoroutine(PlaySequence(frames));
        yield return new WaitWhile(() => sequence_running);
        ChangeTorsoSprite(man_sheet[0]);
        AnimationEnd();
    }

    IEnumerator ManInstructing2()
    {
        List<Frame> frames = new List<Frame>
        {
            new Frame(man_sheet[0], 1f),
            new Frame(man_sheet[7], 1.5f)
        };
        PlayAudio(instructing_2);
        current_sequence = StartCoroutine(PlaySequence(frames));
        yield return new WaitWhile(() => sequence_running);
        ChangeTorsoSprite(man_sheet[0]);
        AnimationEnd();
    }
    IEnumerator ManInstructing3()
    {
        PlayAudio(instructing_3);
        current_sequence = StartCoroutine(FrameTillEndOfAudio(man_sheet[0]));
        yield return new WaitWhile(() => sequence_running);
        ChangeTorsoSprite(man_sheet[0]);
        AnimationEnd();
    }

    class Frame 
    {
        public Sprite sprite; //What sprite man is changed to
        public float delay; //How long that sprite appears
        public bool over;

        public Frame(Sprite sprite, float delay)
        {
            this.sprite = sprite;
            this.delay = delay;
            this.over = false;
        }
    }

}
