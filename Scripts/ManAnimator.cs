using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAnimator : MonoBehaviour
{
    public GameObject event_holder;
    public GameObject dialog_box;
    public GameObject bark_box;
    public MainController controller;
    List<Frame> current_frames;
    Frame current_bark;
    int current_frame = 0;

    public AudioClip g1;
    public AudioClip g2;
    public AudioClip g3;

    public LanguageController LG;

    //0: All neutral
    //1: Head to right neutral
    //2: Right hand half up, open hand
    //3: Both hands up
    //4: Left hand point left
    //5: head tilt left neutral
    //6: left hand up fist
    public Sprite[] man_sheet;
    public Sprite[] bark_sheet;
    private List<Frame> first_greeting_1;
    private List<Frame> instructions_1;
    private List<Frame> instructions_2;
    private List<Frame> instructions_3;
    private List<Frame> instructions_4;
    private List<Frame> boss_intro_1;
    private List<Frame> finished_game_1;

    int clip;

    Coroutine bark_cr;

    SoundSettings settings;

    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        settings = GameObject.FindGameObjectWithTag("GameController").GetComponent<SoundSettings>();

        first_greeting_1 = new List<Frame>()
        {
            new Frame(man_sheet[2], null, LG.first_greeting[0]),
            new Frame(man_sheet[0], null, LG.first_greeting[1]),
            new Frame(man_sheet[1], null, LG.first_greeting[2]),
            new Frame(man_sheet[3], null, LG.first_greeting[3]),
            new Frame(man_sheet[4], null, LG.first_greeting[4]),
        };
        instructions_1 = new List<Frame>()
        {
            new Frame(man_sheet[6], null, LG.instructions[0]),
            new Frame(man_sheet[0], null, LG.instructions[1])
        };
        instructions_2 = new List<Frame>()
        {
            new Frame(man_sheet[0], null, LG.instructions[2])
        };
        instructions_3 = new List<Frame>()
        {
            new Frame(man_sheet[0], null, LG.instructions[3])
        };
        //First victory
        instructions_4 = new List<Frame>()
        {
            //Frames need to be added
            new Frame(man_sheet[0], null, LG.instructions[5]),
            new Frame(man_sheet[0], null, LG.instructions[6]),
            new Frame(man_sheet[0], null, LG.instructions[7])
        };
        boss_intro_1 = new List<Frame>()
        {
            //Frames need to be added
            new Frame(man_sheet[0], null, LG.boss_intros[0]),
            new Frame(man_sheet[0], null, LG.boss_intros[1]),
            new Frame(man_sheet[0], null, LG.boss_intros[2])
        };
        finished_game_1 = new List<Frame>()
        {
            new Frame(man_sheet[0], null, LG.finished_playthroughs[0]),
            new Frame(man_sheet[0], null, LG.finished_playthroughs[1]),
            new Frame(man_sheet[0], null, LG.finished_playthroughs[2]),
            new Frame(man_sheet[0], null, LG.finished_playthroughs[3])
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(!paused) HandleDialog();
        Upkeep();
    }


    bool mute;
    float volume = 0f;
    string type = "Man";

    public void Upkeep()
    {
        //Get sound targets from settings and adapt to them
        List<SoundTarget> soundTargets = settings.soundTargets;
        for (int i = 0; i < soundTargets.Count; i++)
        {
            if (soundTargets[i].name == type)
            {
                mute = soundTargets[i].mute;
                volume = soundTargets[i].volume;
            }
        }
        if (GetComponent<AudioSource>().mute != mute) GetComponent<AudioSource>().mute = mute;
        if (GetComponent<AudioSource>().volume != volume) GetComponent<AudioSource>().volume = volume;
    }

    private void HandleAudio()
    {
        //Handle audio
        if ((dialog_box.GetComponent<DialogBox>().text_anim_playing || bark_box.GetComponent<DialogBox>().text_anim_playing) && !GetComponent<AudioSource>().isPlaying)
        {
            int x = clip;
            while (clip == x)
            {
                clip = Random.Range(1, 4);
            }
            switch (clip)
            {
                case 1: GetComponent<AudioSource>().clip = g1; break;
                case 2: GetComponent<AudioSource>().clip = g2; break;
                case 3: GetComponent<AudioSource>().clip = g3; break;
            }
            GetComponent<AudioSource>().Play();
        }
        else if ((!dialog_box.GetComponent<DialogBox>().text_anim_playing && !bark_box.GetComponent<DialogBox>().text_anim_playing) && GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    private void HandleDialog()
    {
        HandleAudio();

        //Handle text
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            if (current_frames != null)
            {
                if (!dialog_box.GetComponent<DialogBox>().text_anim_playing)
                {
                    current_frame++;
                    if (current_frame <= current_frames.Count - 1)
                    {
                        PlayFrame(current_frames[current_frame]);
                    }
                    else if (current_frame >= current_frames.Count)
                    {
                        //If last part of animation played
                        dialog_box.GetComponent<DialogBox>().StartAnimation(1);
                        ChangeSprite(man_sheet[0]);

                        controller.buttons_active = true;
                        for (int i = 0; i < event_holder.transform.childCount; i++)
                        {
                            if(event_holder.transform.GetChild(i).GetComponent<Message>())
                            {
                                if (event_holder.transform.GetChild(i).GetComponent<Message>().activated)
                                {
                                    event_holder.transform.GetChild(i).GetComponent<StoryEvent>().over = true;
                                }
                            }
                        }
                        current_frames = null;
                    }
                }
                else
                {
                    dialog_box.GetComponent<DialogBox>().FinishTextAnimation();
                }
            }
        }
    }

    public void CreateABark(string bark)
    {
        if(current_bark == null)
        {
            current_bark =
                new Frame(
                    bark_sheet[Random.Range(0, bark_sheet.Length)],
                    null,
                    bark
                );
        }
        bark_cr = StartCoroutine(HandleBarking());
    }

    IEnumerator HandleBarking()
    {
        if(current_bark != null)
        {
            bark_box.GetComponent<DialogBox>().StartAnimation(0);
            bark_box.GetComponent<DialogBox>().StartTextAnimation(current_bark.text, null);
            yield return new WaitWhile(() => bark_box.GetComponent<DialogBox>().text_anim_playing);
            yield return new WaitForSeconds(3f);
            bark_box.GetComponent<DialogBox>().StartAnimation(1);
            yield return new WaitWhile(() => bark_box.GetComponent<DialogBox>().animation_playing);
            current_bark = null;
            StopCoroutine(bark_cr);
        }

    }

    private void ChangeSprite(Sprite new_sprite)
    {
        GetComponent<SpriteRenderer>().sprite = new_sprite;
    }

    private void PlayFrame(Frame frame)
    {
        ChangeSprite(frame.sprite);
        dialog_box.GetComponent<DialogBox>().StartTextAnimation(frame.text, null);
    }

    public void ManMessage(int id)
    {
        switch (id)
        {
            case 0: current_frames = first_greeting_1; break;
            case 1: current_frames = instructions_1; break;
            case 2: current_frames = instructions_2; break;
            case 3: current_frames = instructions_3; break;
            case 4: current_frames = instructions_4; break;
            case 5: current_frames = boss_intro_1; break;
            case 6: current_frames = finished_game_1; break;
        }
        current_frame = 0;
        dialog_box.GetComponent<DialogBox>().StartAnimation(0);
        PlayFrame(current_frames[current_frame]);
    }

    //Animations

    public class Frame 
    {
        public Sprite sprite; //What sprite man is changed to
        public float? text_speed; //How long is between each letter
        public string text;

        public Frame(Sprite sprite, float? text_speed, string text)
        {
            this.sprite = sprite;
            this.text_speed = text_speed;
            this.text = text;
        }
    }

}
