using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageController
{
    public static bool suomi;

    public static string[] dialog = new string[20] 
    {
        "Good day to you.",
        "It has been a long time, since someone was sent here.",
        "I have to say, this is a little bit too harsh for you",
        "but I don't make decisions.",
        "Detach the gear and we can begin.",

        "Now it's time fo your last battle.",
        "Attach your weapons to the gear and put it back in it's place.",
        "That's that. Pull the lever, when you are ready.",
        "I really hope, I don't have to explain this part.",
        "Oh... I propably should have warned you.",

        //First victory
        "Congradulations. You won the first encounter.",
        "But more is comming, and you will need something more powerfull against them.",
        "Choose one of these.",

        //Boss 1
        "You have fought well.",
        "But the next foe will be more dangerous than anyhting you have faced this far.",
        "Wish you luck.",

        //End of first play through
        "That's how it is done!",
        "You are not bad at this",
        "This has been fun, but execution is an execution...",
        "Until we meet again."
    };


    public static void ChangeLanguage()
    {
        //First instructions
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

    }
}
