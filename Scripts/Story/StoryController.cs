using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StoryController : MonoBehaviour
{
    public List<GameObject> events;
    public GameObject story_event_holder;
    public GameObject story;

    //For save system
    /*[HideInInspector]*/ public int playthroughts = 0;
    [HideInInspector] public int storyIndex = -1;

    //Tutorial messages
    public GameObject first_victory;

    public GameObject first_boss_intro;
    public GameObject first_boss_victory;

    public GameObject first_achievement;
    public GameObject first_achievement_pick;

    public bool executioner = false;

	public bool debug = false;
	public bool museum_active = false;

    //Scenes
    public GameObject cellar;

	public GameObject the_q;
	public GameObject main_background;
	public GameObject museum_background;
	public GameObject table;
	public Sprite museum_table;
	public GameObject machine_1;
	public Sprite machine_1_sprite;
	public GameObject machine_2;
	public Sprite machine_2_sprite;
	public GameObject player_wheel_holder;
	public GameObject enemy_wheel_holder;

	public List<GameObject> wheels;
	public Sprite museum_wheel;
	public GameObject start_button;
	public GameObject lamp;
	public GameObject man;
	public GameObject light_changer;
	public Sprite museum_light_changer;

	public StoryData story_data;


	

    public void Inisiate()
    {
        LoadStory();
        if(GetComponent<StoryCheckList>().greeting_index >= messages.Length) 
        {
            executioner = true;
            GameObject.Find("man").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        } 
        if(museum_active)
        {
			//Change scene to museum
			the_q.GetComponent<CameraNQuilliotine>().ChangeToMuseum();
			the_q.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("background");
			the_q.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 1;
			table.GetComponent<SpriteRenderer>().sprite = museum_table;
			machine_1.GetComponent<SpriteRenderer>().sprite = machine_1_sprite;
			machine_2.GetComponent<SpriteRenderer>().sprite = machine_2_sprite;
			main_background.SetActive(false);
			museum_background.SetActive(true);
			player_wheel_holder.GetComponent<PlayerWheelHolder>().ChangeToMuseum();
			enemy_wheel_holder.GetComponent<EnemyWheelHolder>().ChangeToMuseum();

			for(int i = 0; i < wheels.Count; i++)
			{
				wheels[i].GetComponent<SpriteRenderer>().sprite = museum_wheel;
			}
			start_button.GetComponent<StartButton>().ChangeToMuseum();
			lamp.transform.position = new Vector2(lamp.transform.position.x, 9);
			lamp.transform.GetChild(0).GetComponent<Light2D>().pointLightOuterRadius = 14;
			man.SetActive(false);
			light_changer.GetComponent<SpriteRenderer>().sprite = museum_light_changer;
        }
        //executioner = true; ///////Debug

        //Set base for the playthrough (at this point there is just one)

		if(debug)
		{
			story = Instantiate(GetComponent<MainController>().playthroughts[4], transform);
		}
        else if(executioner)
		{
			//Set executioner game
	        story = Instantiate(GetComponent<MainController>().playthroughts[2], transform);
		}
		else if (playthroughts == 0)
        {
	        //If its the first playthrough, set the tutorial
	        story = Instantiate(GetComponent<MainController>().playthroughts[0], transform);
        }
        else if(GetComponent<StoryCheckList>().executioner_dead)
		{
			//Set museum game
	        story = Instantiate(GetComponent<MainController>().playthroughts[3], transform);
		} else
		{
			//Set main game
	        story = Instantiate(GetComponent<MainController>().playthroughts[1], transform);
		}
		
            
        events.AddRange(story.GetComponent<Story>().events);
    }

    public void InvokeNextEvent()
    {
        if(story_event_holder.transform.childCount == 0 && storyIndex < events.Count-1)
        {
            storyIndex++;
            Instantiate(events[storyIndex], story_event_holder.transform);
        } 
    }

    private void LoadStory() {
        story_data = SaveSystem.LoadStoryData();
        if (story_data != null)
        {
            playthroughts = story_data.playthroughs;

            if (story_data.encounter_index != -1)
			{
				storyIndex = story_data.encounter_index-1;
			}
			GetComponent<RLController>().Insiate(story_data);
	        GetComponent<StoryCheckList>().LoadStoryCheckList(story_data);
        } else
		{
			GetComponent<RLController>().Insiate(null);
	        GetComponent<StoryCheckList>().LoadStoryCheckList(null);
		}
    }

    public string[][] GiveMessages()
    {
        return messages;
    }

    public string[] GiveExecutionerMessage()
    {
        return executioner_message;
    }

    string[][] messages =
    {
        new string[] { "I know how and when,", "but why...10", "I did not bother to figure that one out." },
        new string[] { "It is funny to think that in situations like this, everyone is still innocent.", "Well, until proven, I suppose. 7"},
        new string[] { "Was it worth it? 12" },

        //Story 1
        new string[] { "Whoah... The Shadow of Gial in the flesh. 11", "I almost rooted for you, but I guess life has a price in the end.", "Shame. 4", " Reading about your heists was quite entertaining.", "This should be interesting." },
        
        //Abyssal twin 1
        new string[] { "You look terrible.", "No matter what, you didn't tell where your brother was. That's commendable.", "I would die to have that close relationship with my brother. 16" },
        new string[] { "No last meal, no talk, no nothing. 1", "Strange fella, you are. Strange one indeed. 1" },
        new string[] { "Oh. I was wondering, if you would end up here.", " What happened to that other one? 5", "That case about the statue. Few years in prison? 5", "It's interesting, how one child can change ones fate.", "Regardless. Shall we? 17" },
        //Abyssal twin 2
        new string[] { "Abyssal twins and only half left.", "Your sister did ok.", "Lets see if you can crack this last problem. 15" },
        new string[] { "Hello. 3", " I have read about your case. A bit boring, if you ask me.", "Still can't remember why you killed them? 5", "Well I doubt I will remember you either. 16" },
        new string[] { "Smoke? ", "Well if you don't mind I will grab one.", "It has been a long day." }, //Tarvii erikoisen spriten

        //Story 2
        new string[] { "Well, I guess this tracks. 10", "The building was empty, but I am paying for the repairs too you know." },

        new string[] { "Butcher of Narubaaz, welcome! 15", "It is rather ironic how differently we both do the same job. 16" },
        new string[] { "Yeah, It is good that Dr Grainwel does his health inspections.", "Wouldn't want anyone to get sick would we. 16" },
        new string[] { "Daddies? Sisters? Drugs under the sea?", "Not sure what you had, but please; give me the same dose. 17" },
        new string[] { "YOU! 0",". . .", "Just pull the lever." },
        new string[] { "Hello. 3", "You know. I never got my money back.", " I will enjoy this. 16" },

        //Story 3
        new string[] { "You don't look that shady to me. But that might just be a boon in your line of work.", "Please, tell me. Are they planning something? 5", "I will take that secret to the grave, I promise. 16" },

        new string[] { "Could you explain to me:", "How do you even betray a country? 5", "It is a landmass in the end. Dirt. How do you betray dirt? 10" },
        new string[] { "Word, five letters, keywords being finality and end of the road.", "Think, think, think..", "Why do they make these so hard..." }, //Newspaper
        new string[] { "2 dead.", "And only because you didn't care enough." },
        new string[] { "I can think of a few who could laugh about this. 7", "Do you? 5", "Oh, okey." },
        new string[] { "Fun fact; The Ancients believed that best thing to do in your life is to die. 9", "And who are we to doupt their wisdom?" },

        //Story 4
        new string[] { "Oh oh. 12", "Wouldn't want to be you. 21", "Your \"partner\" already passed through here. Did they tell you anything?", "Come on. Not like you haven't already spilled the beans. 16" },

        new string[] { "Those corpses never walked in the end.", "Did they? 11" },
        new string[] { "I have seen a quite may people here.", "But never someone as disgusting as you.", "They were children. 0" },
        new string[] { "You know, sometimes I thought it would be interesting to ask:", " How it felt? 5" },
        new string[] { "For the Gore Lord you said. 11", "Sad to see fellow brother of faith ending up here. 7", "But lets end this as it should; with blood. 14" },
        new string[] { "What are you so afraid of losing that you would do all those things just to end up here. 1" },

        //Story 5
        new string[] { "Did someone pay you or something?", "Because I can't imagine someone being that upset about tax policies." },

        new string[] { "All these letters and I read them all.", "Did you think I have vote in this? That I could change anything or even want to?", "You should have been more careful with that car, that is all I am saying." },
        new string[] { "I can somewhat relate. 4", "Sometimes I get so angry at someone that I just kill them when they sit down.", "But I try to avoid that.", "It is never worth it. 4" },
        new string[] { "I am sorry. Truly I am. 19", "I didn't know it was your son.", "Although it has never made any difference with the others. They all had families. 7", "But I hope that the Eye in the sky sees fit to let you meet him again." },
        new string[] { "Check. Mate. 14", "I always wanted to say that. 15" },
        new string[] { "You should have tried applying here. 17", "People here have called me insane as well." },

        //Story 6
        new string[] { "Definiton for an identity theft has become quite broad.", "Yes, a large margin of what you wrote was never said, but still. 10", "Well, this you can quote however you like:", "I hope you have a fun game. 12" },

        new string[] { "You know, sometimes I think about quitting this gig.", "But then I would not meet such nice people like you. 1" },
        new string[] { "Don't worry, the tax payers didn't pay for this.", "I built this myself. 16" },
        new string[] { "Hmm... I never understood those numbers.", "Was it code? Was it key? 5", " Actually, do not tell me. 3", " It's funnier to keep on guessing." },
        new string[] { "I saw the picture in a newspaper.", "That was an impressive feat of logistics. You should have been a truck driver. 9" },

        //Story 7
        new string[] { "You are a living proof of that you should never bring a gun to a fist fight. 12", "Not that I agree with the people you killed. 4", "We have law enforcement for a reason." },

        new string[] {  "About a hundred people crushed.", "I... I'm sorry. 19", "That must have felt terrible. 4" },
        new string[] {  "BLIND MANS BANE! WHAT IS WRONG WITH YOU? 11" },
        new string[] {  "So you took a loan under someone elses name.", "What did you need the money for? 5", "A house? 5", "Well you are never getting that now, but we have a quite homely new residence for you. 16" },
        new string[] {  "I get it. Living in small space with jerks around every corne must be infuriating.", "You seemed a nice person tho. 17", "I heared you used a toothbrush. That is somewhat impressive." },

        //Story 8
        new string[] {  "You should have been more civil about your approach.", "Don't get me wrong, I like protests as much as the other 600 people, 3", " but quite many got trampeled to death." },

        new string[] {  "And of course this is the answer to everything. 0", "But who will listen to you now?" },
        new string[] {  "So. He was dead after all. 11", "Never thought those conspiracy theories would end up being true.", "Two years. That's a new record. 10" },
        new string[] {  "Well there is no honor among thieves, is there?", "That pearl will make a quite popular museum attraction some day." },
        new string[] {  "Ok, this doesn't make any sense to me.", "And I hate having to work overtime. 0" },
        new string[] {  "Hush now. 12", "I believe you to be innosent for this. I really do. 12", "But I also believed the last one. 11" },

        //Story 9
        new string[] {  "Sometimes I wonder why they bother with the trials and all when people start dying. 1", "The officers should have just executed you after you gunned one of them down. 1", "Well, at least I get something out of this. 7" },

        new string[] {  "Ok. This is refreshing.", "A basic barfight.", " I will drink to your memory, my firend. 12" },
        new string[] {  "..As dawn rises we shall envelope ourselves into dusk..", "Oh, sorry. I lost myself to your works.", "Let's make their value go up." }, //Runot
        new string[] {  "It has been awhile.", "Let's see if you dragged some of our officals down with you.", "This might actually be somewhat effective assasination tactic. 10" },
        
        //Story 10
        new string[] {  "Well this is a first.", "Did you paralyze them or something? 5", "Heh... I guess you should not give those coppers a reason.", "And it's not like I ever needed one." },

        new string[] {  "Ok. I got it the first couple of times, but they got all things you took back. 5" },
        new string[] {  "The Splatter! 11", "People like you brighten my day. You know how to put on a show. 15", "I made something just for you. 18" },
        new string[] {  "Poor pup. 4", "They had to put it down.", "Can't imagine what it was feeling. Must have been confused.", "Mans best friend, redused to a weapon." },
        new string[] {  "It is funny, that even now they kept sure that the inheritance was furthered to you.", "Do you have kids? 21" },

        //Story 11
        new string[] {  "What are you doing here? Didn't you steal like a grandfather clock? 5", "You... You can't put a price on time I guess." },

        new string[] {  "Should I just ask them to shoot people who assault them on the spot? 10", "This just feels really pointless." },
        new string[] {  "You should have picked a better motorcycle." },
        new string[] {  "Sometimes I think what I will do when I retire.", "Maybe I will buy a small kabin in the middle of the woods. 10", "A peaceful life." },

        //Story 12
        new string[] {  "Drug industrialist eh? 14", "Kind of a wierd accusation since you ran a bar. 10", "Some times I wanted to pay that place a visit. I heard it was a nice.", "Although I believe I�m not that popular among you people. 4" },

        new string[] {  "This again?", "Oh well. 7" },
        new string[] {  "I did not get home last night because of you. 21", "You know how uncomfortable beds here are." },
        new string[] {  "Your ads, I got them.", "I understood the idea; kids sniffing glue, very fun.", "And you were allowed to go for so long. So, so long." },
        new string[] {  "So let me get this straight: 1", "A building was demolished on purpose to kill two people inside of it, who were spokespeople to the opposing party. That was made to look like an accident. 1", "This was also a calculated move to rise cost of building houses due to an expensive screenings of the current work force, so more money could be fonneled towards governments military projects. 1", "... 1", "I see. 1" },
        new string[] {  "I miss the murderers. Could you just drink the alcohol instead of throwing it all accross the streets? 19" },

        //Story 13
        new string[] {  "Yeah... I figured.", "Even if I hoped the Scrap King would not stoop to violence. But I guess he is an idealist.", "I could feel sorry for you, but maybe this was your plan all along." },
        new string[] {  "Oh... You all have been sent here? 5", "The All Witness. This is going to be a long day. 19" },
        new string[] {  "Usually I have something to say to people who come here, but I don't even know who you are." },
        new string[] {  "How many there are after you? " },
        new string[] {  "Could you try to be quick? 17" },
        new string[] {  "Just pull the lever. 21" },
        new string[] {  "...", "What? 17" },
        new string[] {  "..." },
        new string[] {  "You know, I built this thing to mess with awful people.", "And you have killed others as well, and I think they are still fixing the crater on the street, but you are not like the usual folk here.", "You don�t hurt because you believe your life to be more precious than someone elses. 1", "You hurt because you believe your world would be better than someone elses. 1" },
        new string[] {  "Yeah, let's just get this over with.", "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "Hi. Long...", "Long time no see? 3", "Yeah... Let's not go there. 4" },
        new string[] {  "You are the last of them?", "Good. Go out as you want.", "I can't be bothered to kill you.", "I'm not sure have you understood, but this is not violence or even justice.", "This just... is." },
        new string[] {  "And there is the King. 17", "What was left of your group is dead. You led them to their unceremonial ends.", "They say those who win, write the history. Maybe one day you will be written as a hero.", "And maybe people now will understand the consequenses of hate. 0" },
        
        new string[] {  "A kiosk, really? 5" },
        new string[] {  "I don't care." },
        new string[] {  "Heh. And they still let me do the honors. 12", "Didn't know I was included under an assault of an officer. 10" },
        new string[] {  "All that money and you chose to make more. 1", "Have you any idea how many innocent souls ended up to streets just because of that substance? 1" },

        //Story 14
        new string[] {  "Did you find out if they got away? I have not seen them round here since. 5", " Maybe you will just take their place. This all would be rather pointless otherwise.", "And thanks a lot for giving me even more work from now on." },

        new string[] {  "I love the smell of burning flesh in the morning. 16" },
        new string[] {  "Commendable, but they will die tomorrow anyway.", "No, there isn't much I can do and I am technically an officer as well." },
        new string[] {  "Hi.", "I know... I know. 7" },

        //Story 15
        new string[] {  "Ok. This kind of thing again?", "Everybody knows that we cell weapons. What the exact numbers have to do with anything? 5", "And it was a good article. 18" },

        new string[] {  "You just had to drag me back from my holiday?", "Yeah, he had an affair, so what? Get a divorce like sane people." },
        new string[] {  "I kind of miss the nicknames people like you were given.", "But I also understand why that thing got banned. Some sick people might pursue them.", "What do you think of this 0337? 12" },
        new string[] {  "You could have just used your own passport, you know." },

        //Story 16
        new string[] {  "Apparently no-one learned from the King.", "Let just get one thing straight. I am not against you per se, just your actions. 21" },
        new string[] {  "Same as all before?" },
        new string[] {  "I am too old for this shit. 19" },
        new string[] {  "Go. 19", "Just get out. 19", "You will be shot yes, but what difference it makes?" }
    };

    string[] executioner_message = { "Now, let's see how well I remember this.", "Or...", "Should I just..." };
}
