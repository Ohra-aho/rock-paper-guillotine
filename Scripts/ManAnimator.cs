using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAnimator : MonoBehaviour
{
    public GameObject dialog_box;
    List<Frame> current_frames;
    int current_frame = 0;

    public AudioClip g1;
    public AudioClip g2;
    public AudioClip g3;


    //0: All neutral
    //1: Head to right neutral
    //2: Right hand half up, open hand
    //3: Both hands up
    //4: Left hand point left
    //5: head tilt left neutral
    //6: left hand up fist
    public Sprite[] man_sheet;
    private List<Frame> test_1;

    int clip;


    // Start is called before the first frame update
    void Start()
    {
        test_1 = new List<Frame>()
        {
            new Frame(man_sheet[1], null, "Jotain tässä pitäis sanoa"),
            new Frame(man_sheet[4], null, "Mutta taasen sitten ei ole oikein mitään sanottavaa"),
            new Frame(man_sheet[0], 0.09f, "Tiedätkö sen tunteen?"),
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
                case 1:
                    GetComponent<AudioSource>().clip = g1;
                    break;
                case 2:
                    GetComponent<AudioSource>().clip = g2;
                    break;
                case 3:
                    GetComponent<AudioSource>().clip = g3;
                    break;
            }
            GetComponent<AudioSource>().Play();
        } else if(!dialog_box.GetComponent<DialogBox>().text_anim_playing && GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Stop();
        }

        if (Input.GetKeyDown("space"))
        {
            if (!dialog_box.GetComponent<DialogBox>().text_anim_playing)
            {
                current_frame++;
                if(current_frame <= current_frames.Count-1)
                {
                    PlayFrame(current_frames[current_frame]);
                } else if(current_frame >= current_frames.Count)
                {
                    dialog_box.GetComponent<DialogBox>().StartAnimation(1);
                }
            } else
            {
                dialog_box.GetComponent<DialogBox>().FinishTextAnimation();
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
                current_frames = test_1;
                current_frame = 0;
                dialog_box.GetComponent<DialogBox>().StartAnimation(0);
                PlayFrame(current_frames[current_frame]);
                break;
        }
    }

    //Animations

    public class Frame 
    {
        public Sprite sprite; //What sprite man is changed to
        public float? text_speed; //How long that sprite appears
        public string text;

        public Frame(Sprite sprite, float? text_speed, string text)
        {
            this.sprite = sprite;
            this.text_speed = text_speed;
            this.text = text;
        }
    }

}
