using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageHolder : MonoBehaviour
{
    //public  List<GameObject> messages;
    public GameObject message;
    [HideInInspector] public bool activated = false;
    public List<ManAnimator.Frame> frames;

    MainController MC;

    string[][] messages = 
    {
        new string[] { "Oh. I was wondering, if you would end up here.", "What happened to that other one? That case about the statue. Few years in prison?", "It's interesting, how one child can change ones fate.", "Regardless. Shall we?" },
        new string[] {  "Whoah... The Shadow of Gial in the flesh.", "I almost rooted for you. Reading about your heists was just too entertaining.", "This should be interesting." },
        new string[] {  "Hello...", "You know. I never got my money back.", "I will enjoy this." },
        new string[] {  "YOU!", "I am very tempted to just end you. Right here and right now.", "So let's get this over with.", "I wish you the worst of luck." },
        new string[] {  "Hello.", "I read about your case. A bit boring, if you ask me.", "Still can't remember why you killed them?", "Well I doubt, I will remember you either." },
        new string[] {  "It wasn't worth it, was it.", "And now I will do to you, what you did to them.", "Funny how that works." },
        new string[] {  "...", "...", "Just pull the lever." },
        new string[] {  "I never understood those numbers.", "Was it code?", "Was it key?", "Oh, do not tell me. It is funnier to continue guessing." },
        new string[] {  "I know how and when, but why?", "I never bothered to figure that one out." },
        new string[] {  "You are a big one", "Now I undestand why that one cop went to a hospital." },

        new string[] {  "I can think of few who could laugh about this.", "Do you?", "No?", "Oh... Ok" },
        new string[] {  "It's funny to think, that in situations like this, everyone is still innosent." },
        new string[] {  "I didn't know that stuff was that valuable.", "How much was your life again?" },
        new string[] {  "For the Crimson god you say?", "It is sad to see how a brother of faith ends up in a situation like this.", "But well.", "Let's end this as it should:", "In blood." },
        new string[] {  "Just tell me.", "What were you going to do with those faces?" },
        new string[] {  "You know...", "They stopped hanging people when they tought it was too cruel." },
        new string[] {  "I would love to have you to clean up your own body.", "You did such a marvelous job at that." },
        new string[] {  "You feeling comfy there?", "Once I thought of an electric chair but..." },
        new string[] {  "Subject number... um...", "Sentenced to... ok...", "for murders of five people...", "a pencil?", "Oh! I am sorry. I was reading about someone else.", "You where?" },
        new string[] {  "You where an activist, weren't you?", "Well I think your side has the best slogans." },

        new string[] {  "BY THE DAWN! WHAT's WRONG WITH YOU?" },
        new string[] {  "Those corpses never walked in the end,", "did they?" },
        new string[] {  "I sometimes want to ask:", "How was it?" },
        new string[] {  "Daddies?", "Sisters?", "Lightning under the sea?", "I don't know what they gave you, but pleace, give me the same dose." },
        new string[] {  "Was it worth it?" },
        new string[] {  "...", "I am too old for this shit." },
        new string[] { "..As dawn rises, we shall envelope ourselves into dusk..", "Oh, sorry. I lost myself to your works.", "Let's make their value go up." },
        new string[] { "I guess you never thought ending up here.", "But hey, they could have sent you to a wall." },
        new string[] {  "Fun fact;", "Ancients believed that best thing to do in life is to die.", "And who are we to doubt their wisdom." },
        new string[] {  "Tonight, Man with the hat joins the game." },

        new string[] {  "Butcher of Narubaaz, welcome.", "It is rather ironic how differently we both do the same job." },
        new string[] {  "Let's make this one fast.", "There is a long line behind you." },
        new string[] {  "You know, sometimes I think about quitting this job", "But then,", "Where I would meet such nice people as you." },
        new string[] {  "What are you so afraid of losing,", "that you would do all those things?", "And then you just ended up here." },
        new string[] {  "You should not be here. If that amounts to anything." },
        new string[] {  "Check. Mate.", "I always wanted to say that." },
        new string[] {  "The Scrap king.", "You people almost got me worried, but here I still am.", "Pull the lever twice, if you want to go out on your own terms." },
        new string[] {  "And this is what happens to people like you." },
        new string[] {  "Do you really subscribe to what that Ed keeps speacing about?" },
        new string[] {  "Keep your hands off my circuitry.", "I know what you can do with it." },

        new string[] {  "Could this be one of those 'natural 1', moments." },
        new string[] {  "You have trouble with your temper?", "Don't lose your head, ok." },
        new string[] { "They found you not guilty the first time.", "I will apologise to your lawyer." },
        new string[] {  "I'm not sure, if you understood, but this is not violence or even justice.", "This is...", "management." },
        new string[] {  "Pass me that cup, and please take one for yourself.", "This might be a long one." },
        new string[] {  "This is more about the money, you know.", "We could help you.", "We really could.", "It just doesn't fit to the budget." },
        new string[] {  "All that money and you chose to make more.", "Have you any idea how many innocent souls ended up to streets just because of that substance?" },
        new string[] {  "A treason?", "I could say something patriotic, but I kill perfectly good citisens quite often so.", "Who am I to judge?" },
        new string[] { "Word, five letters, keywords being finality and end of the road. ", "Why do they make these so hard..", "Any ideas?" },
        new string[] { "No last meal, no talk, no nothing.", " Strange fella, you are. Strange one indeed." },
        //new string[] { "No more, please no more.", " I did not ask for this." }

        new string[] { "Your ads, I got them.", "I understood the idea; kids sniffing glue, very fun.", " And you were allowed to go for so long.", "So, so long." },
        new string[] { "I do not make laws here.", " 1 gram, 10 grams, 10 kilograms even a metric ton; just numbers to me. And now I see you die. Unfair, so unfair." },
        new string[] { "2 dead.", " And only because you did not care enough." },
        new string[] { "An actual war criminal?", "Rules for war are such a wierd thing.", "I hope you find the flamethrower.", "There is one in this game." },
        new string[] { "Abyssal twins and only half left.", " Your sister did well,", " very well actually.", "Lets see, if you too crack this last problem." },
        new string[] { "All these letters and I read them all.", "Did you think I have vote in this?", "That I could change anything or even want to?", "You should have been more careful with that car, that is all I am saying." },
        new string[] { "Dr. Grainwell just sent his report and I must say;", "peak condition. Absolute peak condition you have here.", "Now we can begin." },
        new string[] { "I am sorry.", "Truly I am.", "I didn't know it was your son.", "Although it has never made any difference with the others. They all had families.", "But I hope that the Eye in the sky sees fit to let you meet him again." },
        new string[] { "Hi.", ".", ".", ".", ".", "Long...", "Long time no see?", "Yeah...", "Let's get this over with." }, //Might need something special for barks
        new string[] { "I have seen a quite may people here.", "But never someone as disgusting as you.", "They were children." }
    };

    private void Update()
    {
        if (MC.game_state != MainController.State.dialog) MC.game_state = MainController.State.dialog;
    }

    private void Awake()
    {
        MC = GameObject.Find("EventSystem").GetComponent<MainController>();

        frames = new List<ManAnimator.Frame>();

        //This is ok for now
        int index = MC.GetComponent<StoryCheckList>().greeting_index;
        GameObject new_message = Instantiate(message, transform.parent);
        List<string> temp = new List<string>();
        MC.GetComponent<StoryCheckList>().greeting_index = index+1;

        for(int i = 0; i < messages[index].Length; i++)
        {
            temp.Add(messages[index][i]);
        }
        new_message.GetComponent<Message>().lines = temp;
        new_message.GetComponent<Message>().Inisiate();
        GetComponent<StoryEvent>().over = true;
    }
}
