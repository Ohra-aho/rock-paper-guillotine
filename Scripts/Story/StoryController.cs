using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public List<GameObject> events;
    public GameObject story_event_holder;
    public GameObject story;

    //For save system
    /*[HideInInspector]*/ public int playthroughts = 0;
    [HideInInspector] public int storyIndex = -1;
    [HideInInspector] public int narrative_index = -1;

    //Tutorial messages
    public GameObject first_victory;

    public GameObject first_boss_intro;
    public GameObject first_boss_victory;

    public GameObject first_achievement;
    public GameObject first_achievement_pick;

    public bool executioner = false;

    //Scenes
    public GameObject cellar;
    public GameObject museum;

    public void Inisiate()
    {
        LoadStory();
        GetComponent<StoryCheckList>().LoadStoryCheckList();
        if(GetComponent<StoryCheckList>().greeting_index >= messages.Length) 
        {
            executioner = true;
            GameObject.Find("man").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        } 
        if(GetComponent<StoryCheckList>().executioner_dead)
        {
            cellar.SetActive(false);
            museum.SetActive(true);
        }
        executioner = true;

        //Set base for the playthrough (at this point there is just one)
        story = Instantiate(GetComponent<MainController>().playthroughts[0], transform);

        //If its the first playthrough, set the tutorial
        if (playthroughts == 0)
        {
            story.GetComponent<Story>().narrative = Resources.Load<GameObject>("Story/Narratives/Tutorial").GetComponent<Narrative>();
        }
        else if (narrative_index == -1)
            if (narrative_index == -1)
            {
                int game_index = Random.Range(1, 2);
                story.GetComponent<Story>().narrative = Resources.Load<GameObject>("Story/Narratives/Game_" + game_index).GetComponent<Narrative>();
            }
            else
            {
                story.GetComponent<Story>().narrative = Resources.Load<GameObject>("Story/Narratives/Game_" + narrative_index).GetComponent<Narrative>();
            }
        story.GetComponent<Story>().AddBossSpeetches();
        story.GetComponent<Story>().AddIntroSpeeches();
        story.GetComponent<Story>().CreateDeathBark();
        events.AddRange(story.GetComponent<Story>().events);
    }

    public void InvokeNextEvent()
    {
        if(story_event_holder.transform.childCount == 0 && storyIndex < events.Count-1)
        {
            storyIndex++;
            GameObject new_event = Instantiate(events[storyIndex], story_event_holder.transform);
        } 
    }

    private void LoadStory() {
        StoryData story_data = SaveSystem.LoadStoryData();
        if (story_data != null)
        {
            playthroughts = story_data.playthroughs;
            if (story_data.encounter_index == -1)
            {
                narrative_index = -1;
            }
            else
            {
                storyIndex = story_data.encounter_index - 1;
                narrative_index = story_data.narrative_index;
            }
        }
    }

    public void BuildNarrativeFromStoryChecklist()
    {

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
        new string[] { "I know how and when,", "but why...", "I did not bother to figure that one out." },
        new string[] { "It is funny to think that in situations like this, everyone is still innocent.", "Well, until proven, I suppose. 3"},
        new string[] { "Was it worth it?" },

        //Story 1
        new string[] { "Whoah... The Shadow of Gial in the flesh.", "I almost rooted for you, but I guess life has a price in the end.", "Shame. Reading about your heists was quite entertaining.", "This should be interesting." },
        
        //Abyssal twin 1
        new string[] { "You look terrible.", " No matter what, you didn’t tell where your brother was. That’s commendable.", "I would die to have that close relationship with my brother." },
        new string[] { "No last meal, no talk, no nothing.", "Strange fella, you are. Strange one indeed." },
        new string[] { "Oh. I was wondering, if you would end up here. What happened to that other one?", "That case about the statue. Few years in prison?", "It's interesting, how one child can change ones fate.", "Regardless. Shall we?" },
        //Abyssal twin 2
        new string[] { "Abyssal twins and only half left.", "Your sister did ok.", "Lets see if you can crack this last problem." },
        new string[] { "Hello. I have read about your case. A bit boring, if you ask me.", "Still can't remember why you killed them?", "Well I doubt I will remember you either." },
        new string[] { "Smoke? ", "Well if you don't mind I will grab one.", "It has been a long day." },

        //Story 2
        new string[] { "Well, I guess this tracks.", "The building was empty, but I am paying for the repairs too you know." },

        new string[] { "Butcher of Narubaaz, welcome!", "It is rather ironic how differently we both do the same job." },
        new string[] { "Yeah, It is good that Dr Grainwel does his health inspections.", "Wouldn’t want anyone to get sick would we." },
        new string[] { "Daddies? Sisters? Drugs under the sea?", "Not sure what you had, but please; give me the same dose." },
        new string[] { "YOU!"," …", "Just pull the lever." },
        new string[] { "Hello…", "You know. I never got my money back.", " I will enjoy this." },

        //Story 3
        new string[] { "You don’t look that shady to me. But that might just be a boon in your line of work.", "Please, tell me. Are they planning something?", "I will take that secret to the grave, I promise." },

        new string[] { "Could you explain to me:", "How do you even betray a country?", "It is a landmass in the end. Dirt. How do you betray dirt?" },
        new string[] { "Word, five letters, keywords being finality and end of the road.", "Think, think, think..", "Why do they make these so hard…" },
        new string[] { "2 dead.", "And only because you didn’t care enough." },
        new string[] { "I can think of a few who could laugh about this.", "Do you?", "Oh, okey." },
        new string[] { "Fun fact; The Ancients believed that best thing to do in your life is to die.", "And who are we to doupt their wisdom?" },

        //Story 4
        new string[] { "Oh oh.", "Wouldn’t want to be you.", "Your ’partner’ already passed through here. Did they tell you anything?", "Come on. Not like you haven’t already spilled the beans.", "Thank you tho. Those files were an interesting read." },

        new string[] { "Those corpses never walked in the end, did they?" },
        new string[] { "I have seen a quite may people here.", "But never someone as disgusting as you.", "They were children." },
        new string[] { "You know, sometimes I thought it would be interesting to ask:", " How it felt?" },
        new string[] { "For the Gore Lord you said.", "Sad to see fellow brother of faith ending up here.", "But lets end this as it should; with blood." },
        new string[] { "What are you so afraid of losing that you would do all those things just to end up here." },

        //Story 5
        new string[] { "Did someone pay you or something?", "Because I can’t imagine someone being that upset about tax policies." },

        new string[] { "All these letters and I read them all.", "Did you think I have vote in this? That I could change anything or even want to?", "You should have been more careful with that car, that is all I am saying." },
        new string[] { "I can somewhat relate.", "Sometimes I get so angry at someone that I just kill them when they sit down.", "But I try to avoid that.", "It is never worth it." },
        new string[] { "I am sorry. Truly I am.", "I didn't know it was your son.", "Although it has never made any difference with the others. They all had families.", "But I hope that the Eye in the sky sees fit to let you meet him again." },
        new string[] { "Check. Mate.", "I always wanted to say that." },
        new string[] { "You should have tried applying here.", "People here have called me insane as well." },

        //Story 6
        new string[] { "Definiton for an identity theft has become quite broad.", "Yes, a large margin of what you wrote was never said, but still.", "Well, this you can quote however you like:", "I hope you have a fun game." },

        new string[] { "You know, sometimes I think about quitting this gig.", "But then I would not meet such nice people like you." },
        new string[] { "Don’t worry, the tax payers didn’t pay for this. I built this myself." },
        new string[] { "Hmm... I never understood those numbers.", "Was it code? Was it key?", " Actually, do not tell me.", " It’s funnier to keep on guessing." },
        new string[] { "I saw the picture in a newspaper.", "That was an impressive feat of logistics. You should have been a truck driver." },

        //Story 7
        new string[] { "You are a living proof of that you should never bring a gun to a fist fight.", "Not that I agree with the people you killed.", "We have law enforcement for a reason." },

        new string[] {  "About a hundred people crushed.", "I… I’m sorry.", "That must have felt terrible." },
        new string[] {  "BLIND MANS BANE! WHAT IS WRONG WITH YOU?" },
        new string[] {  "So you took a loan under someone elses name.", "What did you need the money for?", "A house?", "Well you are never getting that now, but we have a quite homely new residence for you." },
        new string[] {  "I get it. Living in small space with jerks around every corne must be infuriating.", "You seemed a nice person tho.", "I heared you used a toothbrush. That is somewhat impressive." },

        //Story 8
        new string[] {  "You should have been more civil about your approach.", "Don’t get me wrong, I like protests as much as the other 600 people,", " but quite many got trampeled to death." },

        new string[] {  "And of course this is the answer to everything.", "But who will listen to you now?" },
        new string[] {  "So. He was dead after all.", "Never thought those conspiracy theories would end up being true.", "Two years. That’s a new record." },
        new string[] {  "Well there is no honor among thieves, is there?", "That pearl will make a quite popular museum attraction some day." },
        new string[] {  "Ok, this doesn’t make any sense to me.", "And I hate having to work overtime." },
        new string[] {  "Hush now.", "I believe you to be innosent for this. I really do.", "But I also believed the last one." },

        //Story 9
        new string[] {  "Sometimes I wonder why they bother with the trials and all when people start dying.", "The officers should have just executed you after you gunned one of them down.", "Well, at least I get something out of this." },

        new string[] {  "Ok. This is refreshing.", "A basic barfight.", " I will drink to your memory, my firend." },
        new string[] {  "..As dawn rises we shall envelope ourselves into dusk..", "Oh, sorry. I lost myself to your works.", "Let's make their value go up." },
        new string[] {  "It has been awhile.", "Let’s see if you dragged some of our officals down with you.", "This might actually be somewhat effective assasination tactic." },
        
        //Story 10
        new string[] {  "Well this is a first.", "Did you paralyze them or something?", "Heh… I guess you should not give those coppers a reason.", "And it’s not like I ever needed one." },

        new string[] {  "Ok. I got it the first couple of times, but they got all things you took back." },
        new string[] {  "The Splatter!", "People like you brighten my day. You know how to put on a show.", "Here. Just for you." },
        new string[] {  "Poor pup.", "They had to put it down.", "Can’t imagine what it was feeling. Must have been confused.", "Mans best friend, redused to a weapon." }, // Tähän jäätiin
        new string[] {  "It is funny, that even now they kept sure that the inheritance was furthered to you.", "Do you have kids?" },

        //Story 11
        new string[] {  "What are you doing here? Didn’t you steal like a grandfather clock?", "You… You can’t put a price on time I guess." },

        new string[] {  "Should I just ask them to shoot people who assault them on the spot?", "This just feels really pointless." },
        new string[] {  "You should have picked a better motorcycle." },
        new string[] {  "Sometimes I think what I will do when I retire.", "Maybe I will buy a small kabin in the middle of the woods.", "A peaceful life." },

        //Story 12
        new string[] {  "Drug industrialist eh?", "Kind of a wierd accusation since you ran a bar.", "I some times wanted to pay that place a visit. I heard it was a nice place.", "Although I believe I’m not that popular among you people." },

        new string[] {  "This again? Oh well." },
        new string[] {  "I did not get home last night because of you.", "You know how uncomfortable beds here are." },
        new string[] {  "Your ads, I got them.", "I understood the idea; kids sniffing glue, very fun.", "And you were allowed to go for so long. So, so long." },
        new string[] {  "So let me get this straight:", "A building was demolished on purpose to kill two people inside of it, who were spokespeople to the opposing party. That was made to look like an accident.", "This was also a calculated move to rise cost of building houses due to an expensive screenings of the current work force, so more money could be fonneled towards governments military projects.", "…", "I see." },
        new string[] {  "I miss the murderers. Could you just drink the alcohol instead of throwing it all accross the streets?" },

        //Story 13
        new string[] {  "Yeah… I figured.", "Even if I hoped the Scrap King would not stoop to violence. But I guess he is an idealist.", "I could feel sorry for you, but maybe this was your plan all along." },
        new string[] {  "Oh… You all have been sent here?", "The All Witness. This is going to be a long day." },
        new string[] {  "Usually I have something to say to people who come here, but I don’t even know who you are." },
        new string[] {  "How many there are after you? " },
        new string[] {  "Could you try to be quick?" },
        new string[] {  "Just pull the lever." },
        new string[] {  "...", "What?" },
        new string[] {  "..." },
        new string[] {  "You know, I built this thing to mess with awful people.", "And you have killed others as well, and I think they are still fixing the crater on the street, but you are not like the usual folk here.", "You don’t hurt because you believe your life to be more precious than someone elses.", "You hurt because you believe your world would be better than someone elses." },
        new string[] {  "You know, let’s just get this over with." },
        new string[] {  "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "[kill]" },
        new string[] {  "Hi. Long…", "Long time no see?", "Yeah… Let's not go there." },
        new string[] {  "You are the last of them?", "Good. Go out as you want.", "I can’t be bothered to kill you.", "I’m not sure have you understood, but this is not violence or even justice.", "This just... is." },
        new string[] {  "And there is the King.", "What was left of your group is dead. You led them to their unceremonial ends.", "They say those who win, write the history. Maybe one day you will be written as a hero.", "And maybe people now will understand the consequenses of hate." },
        
        new string[] {  "A kiosk, really?" },
        new string[] {  "I don’t care." },
        new string[] {  "Heh. And they still let me do the honors.", "Didn’t know I was included under ”an assault of an officer”." },
        new string[] {  "All that money and you chose to make more.", "Have you any idea how many innocent souls ended up to streets just because of that substance?" },

        //Story 14
        new string[] {  "Did you find out if they got away? I have not seen them round here since.", " Maybe you will just take their place. This all would be rather pointless otherwise.", "And thanks a lot for giving me even more work from now on." },

        new string[] {  "I love the smell of burning flesh in the morning." },
        new string[] {  "Commendable, but they will die tomorrow anyway.", "No, there isn’t much I can do and I am technically an officer as well." },
        new string[] {  "Hi.", "I know… I know." },

        //Story 15
        new string[] {  "Ok. This kind of thing again?", "Everybody knows that we cell weapons. What the exact numbers have to do with anything?", "And it was a good article." },

        new string[] {  "You just had to drag me back from my holiday?", "Yeah, he had an affair, so what? Get a divorce like sane people." },
        new string[] {  "I kind of miss the nicknames people like you were given.", "But I also understand why that thing got banned. Some sick people might pursue them.", "What do you think of this 0337?" },
        new string[] {  "You could have just used your own passport, you know." },

        //Story 16
        new string[] {  "Apparently no-one learned from the King.", "Let just get one thing straight. I am not against you per se, just your actions." },
        new string[] {  "Same as all before?" },
        new string[] {  "I am too old for this shit." },
        new string[] {  "Go.", "Just get out.", "You will be shot yes, but what difference it makes?" }
    };

    string[] executioner_message = { "Now, let's see how well I remember this.", "Or...", "Should I just..." };
}
