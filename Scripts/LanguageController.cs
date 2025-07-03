using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageController
{
    public static bool suomi;

    public static string[][] tutorial = new string[][]
    {
        /*0*/
        new string[]
        {
            "Good day to you.", 
            "It has been a long time, since someone was sent here.",
            "I have to say, this is a little bit too harsh for you",
            "but I don't make decisions.",
            "Detach the gear and we can begin.",
        },

        /*1*/
        new string[]
        {
            "Now it's time fo your last battle.",
            "Attach your weapons to the gear and put it back in it's place.",
        },

        /*2*/
        new string[]
        {
            "That's that. Pull the lever, when you are ready.",
        },
        
        /*3*/ //First victory
        new string[]
        { 
            "Congradulations. You won the first encounter.",
            "But more is comming, and you will need something more powerfull against them.",
            "Choose one of these.",
        },
       
        /*4*/ //Boss 1
        new string[]
        {
            "You have fought well.",
            "But the next foe will be more dangerous than anyhting you have faced this far.",
            "Wish you luck.",
        },

        /*5*/ //End of first play through
        new string[]
        { 
            "That's how it is done!",
            "You are not bad at this",
            "This has been fun, but execution is an execution...",
            "Until we meet again."
        }
        
    };

    public static string[][] greetings = new string[][]
    {
        /*0*/
        new string[]
        {
            "Oh. I was wondering, if you would end up here.",
            "What happened to that other one? That case about the statue. Few years in prison?",
            "It's interesting, how one child can change ones fate.",
            "Regardless. Shall we?",
        },

        /*1*/
        new string[]
        {
            "Whoah... The Shadow of Gial in the flesh.",
            "I almost rooted for you. Reading about your heists was just too entertaining.",
            "This should be interesting.",
        },
      
        /*2*/
        new string[]
        {
            "Hello...",
            "You know. I never got my money back.",
            "I will enjoy this one.",
        },

        /*3*/
        new string[]
        {
            "YOU!",
            "I am very tempted to just end you. Right here and right now.",
            "So let's get this over with.",
            "I wish you the worst of luck.",
        },
        
        /*4*/
        new string[]
        {
            "Hello.",
            "I read about your case. A bit boring, if you ask me.",
            "Still can't remember why you killed them?",
            "Well I doubt, I will remember you either.",
        },

        /*5*/
        new string[]
        {
            "It wasn't worth it, was it.",
            "And now I will do to you, what you did to them.",
            "Funny how that works.",
        },

        /*6*/
        new string[]
        {
            "...",
            "...",
            "Just pull the lever.",
        }
    };

    public static string[][] boss_intros = new string[][]
    {
        /*0*/
        new string[]
        {
            "The next one will be a little tougher.",
            "Show me what you are made of.",
        },

        /*1*/
        new string[]
        {
            "You will propably die here.",
            "And if you do, it has been surprisingly entertaining.",
        },
        
        /*2*/
        new string[]
        {
            "You must do better this time.",
            "I believe in you.",
        },
        
        /*3*/
        new string[]
        {
            "Next foe is one of my persional favourites.",
            "This ought to be interesting.",
        }
    };

    public static string[][] boss_victories = new string[][]
    {
        /*0*/
        new string[]
        {
            "Congratulations!",
            "You did better than I thought."
        },

        /*1*/
        new string[]
        {
            "Might need some more fine tuning, that one."
        },
        
        /*2*/
        new string[]
        {
            ".",
        },

        /*3*/
        new string[]
        {
            "You did well. I hope you won't dissapoint."
        },

        /*4*/
        new string[]
        {
            "Well. It wasn't so bad. Was it?"
        },

        /*5*/
        new string[]
        {
            "Might need a buffs...",
        }, 

        /*6*/
        new string[]
        {
            "That's how it is done!",
        },

        /*7*/
        new string[]
        {
            "Well, that was interesting.",
        },

        /*8*/
        new string[]
        {
            "Well that was a first.",
            "Haven't seen that strategy used on them before."
        }
    };

    public static string[] barks = new string[]
    {
        /*0*/ "I really hope, I don't have to explain this part.",
        /*1*/ "Oh... I propably should have warned you."
    }; 


    public static void ChangeLanguage()
    {
        //First instructions
        /*
        dialog[0] = suomi ? "No päivää." : "Good day to you.";
        dialog[1] = suomi ? "Siitä onkin hetki kun tänne on viimeksi lähetetty joku." : "It has been a long time, since someone was sent here.";
        dialog[2] = suomi ? "Pakko sanoa, sinun kohdallasi pidän tätä vähän ylilyöntinä," : "I have to say, this is a little bit too harsh for you";
        dialog[3] = suomi ? "mutta enhän minä päätöksiä tee." : "but I don't make decisions.";
        dialog[4] = suomi ? "Irrota ratas niin voimme aloittaa." : "Detach the gear and we can begin.";

        dialog[5] = suomi ? "Nyt on aikasi käydä viimeiseen taisteluun." : "Now it's time fo your last battle.";
        dialog[6] = suomi ? "Kiinnitä aseesi rattaaseen ja aseta ratas taas paikalleen." : "Attach your weapons to the gear and put it back in it's place.";
        dialog[7] = suomi ? "No niin. Vedä vivusta, kun olet valmis." : "That's that. Pull the lever, when you are ready.";
        dialog[8] = suomi ? "Minä tosiaan toivon, ettei minun tarvits selittää tätä osaa." : "I really hope, I don't have to explain this part.";
        dialog[9] = suomi ? "Aaa... Minun olisi varmaan pinänyt varoittaa." : "Oh... I propably should have warned you.";

        //First victory
        dialog[10] = suomi ? "Onneksi olkoon. Ensimmäisen kohtaamisen voittaja olet sinä." : "Congradulations. You won the first encounter.";
        dialog[11] = suomi ? "Mutta lisää on tulossa ja tulet tarvitsemaan jotain vahvempaa niitä varten." : "But more is comming, and you will need something more powerfull against them.";
        dialog[12] = suomi ? "Valitse yksi näistä" : "Choose one of these.";

        //Boss 1
        dialog[13] = suomi ? "Olet taistellut hyvin." : "You have fought well.";
        dialog[14] = suomi ? "Mutta seuraava vastustaja tulee olemaan vaarallisempi kuin mikään ennen kohtaamasi." : "But the next foe will be more dangerous than anyhting you have faced this far.";
        dialog[15] = suomi ? "Onnea matkaan." : "Wish you luck.";

        //End of first play through
        dialog[16] = suomi ? "Noin sitä pitää!" : "That's how it is done!";
        dialog[17] = suomi ? "Et ole pöllömpi tässä." : "You are not bad at this";
        dialog[18] = suomi ? "Tämä on ollut hauskaa, mutta teloitus on teloitus..." : "This has been fun, but execution is an execution...";
        dialog[19] = suomi ? "Kunnes jälleen kohtaamme." : "Until we meet again.";
        */

    }
}
