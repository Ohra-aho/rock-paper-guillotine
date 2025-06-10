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
        dialog[0] = suomi ? "No p�iv��." : "Good day to you.";
        dialog[1] = suomi ? "Siit� onkin hetki kun t�nne on viimeksi l�hetetty joku." : "It has been a long time, since someone was sent here.";
        dialog[2] = suomi ? "Pakko sanoa, sinun kohdallasi pid�n t�t� v�h�n ylily�ntin�," : "I have to say, this is a little bit too harsh for you";
        dialog[3] = suomi ? "mutta enh�n min� p��t�ksi� tee." : "but I don't make decisions.";
        dialog[4] = suomi ? "Irrota ratas niin voimme aloittaa." : "Detach the gear and we can begin.";

        dialog[5] = suomi ? "Nyt on aikasi k�yd� viimeiseen taisteluun." : "Now it's time fo your last battle.";
        dialog[6] = suomi ? "Kiinnit� aseesi rattaaseen ja aseta ratas taas paikalleen." : "Attach your weapons to the gear and put it back in it's place.";
        dialog[7] = suomi ? "No niin. Ved� vivusta, kun olet valmis." : "That's that. Pull the lever, when you are ready.";
        dialog[8] = suomi ? "Min� tosiaan toivon, ettei minun tarvits selitt�� t�t� osaa." : "I really hope, I don't have to explain this part.";
        dialog[9] = suomi ? "Aaa... Minun olisi varmaan pin�nyt varoittaa." : "Oh... I propably should have warned you.";

        //First victory
        dialog[10] = suomi ? "Onneksi olkoon. Ensimm�isen kohtaamisen voittaja olet sin�." : "Congradulations. You won the first encounter.";
        dialog[11] = suomi ? "Mutta lis�� on tulossa ja tulet tarvitsemaan jotain vahvempaa niit� varten." : "But more is comming, and you will need something more powerfull against them.";
        dialog[12] = suomi ? "Valitse yksi n�ist�" : "Choose one of these.";

        //Boss 1
        dialog[13] = suomi ? "Olet taistellut hyvin." : "You have fought well.";
        dialog[14] = suomi ? "Mutta seuraava vastustaja tulee olemaan vaarallisempi kuin mik��n ennen kohtaamasi." : "But the next foe will be more dangerous than anyhting you have faced this far.";
        dialog[15] = suomi ? "Onnea matkaan." : "Wish you luck.";

        //End of first play through
        dialog[16] = suomi ? "Noin sit� pit��!" : "That's how it is done!";
        dialog[17] = suomi ? "Et ole p�ll�mpi t�ss�." : "You are not bad at this";
        dialog[18] = suomi ? "T�m� on ollut hauskaa, mutta teloitus on teloitus..." : "This has been fun, but execution is an execution...";
        dialog[19] = suomi ? "Kunnes j�lleen kohtaamme." : "Until we meet again.";

    }
}
