using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAnimator : MonoBehaviour
{
    public GameObject event_holder;
    public GameObject dialog_box;
    List<Frame> current_frames;
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
    private List<Frame> first_greeting_1;
    private List<Frame> instructions_1;
    private List<Frame> instructions_2;

    int clip;


    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if(dialog_box.GetComponent<DialogBox>().text_anim_playing && !GetComponent<AudioSource>().isPlaying)
        {
            int x = clip;
            while(clip == x)
            {
                clip = Random.Range(1, 4);
            }
            switch(clip)
            {
                case 1: GetComponent<AudioSource>().clip = g1; break;
                case 2: GetComponent<AudioSource>().clip = g2; break;
                case 3: GetComponent<AudioSource>().clip = g3; break;
            }
            GetComponent<AudioSource>().Play();
        } else if(!dialog_box.GetComponent<DialogBox>().text_anim_playing && GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Stop();
        }

        if (Input.GetKeyDown("space"))
        {
            if(current_frames != null)
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
                        dialog_box.GetComponent<DialogBox>().StartAnimation(1);
                        ChangeSprite(man_sheet[0]);
                        NonUIButton[] buttons = FindObjectsOfType<NonUIButton>();
                        for (int i = 0; i < buttons.Length; i++)
                        {
                            buttons[i].interactable = true;
                        }
                        for(int i = 0; i < event_holder.transform.childCount; i++)
                        {
                            if(event_holder.transform.GetChild(i).GetComponent<Message>().activated)
                            {
                                event_holder.transform.GetChild(i).GetComponent<StoryEvent>().over = true;
                            }
                        }
                    }
                }
                else
                {
                    dialog_box.GetComponent<DialogBox>().FinishTextAnimation();
                }
            }
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
            case 0:
                current_frames = first_greeting_1;
                break;
            case 1:
                current_frames = instructions_1;
                break;
            case 2:
                current_frames = instructions_2;
                break;
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
