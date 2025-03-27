using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageController : MonoBehaviour
{
    public bool suomi;

    public string[] first_greeting = new string[5];
    public string[] instructions = new string[8];
    public string[] boss_intros = new string[3];
    public string[] finished_playthroughs = new string[4];

    private void Awake()
    {
        ChangeLanguage();
    }

    private void Update()
    {
        ChangeLanguage();
    }

    public void ChangeLanguage()
    {
        //First instructions
        first_greeting[0] = suomi ? "No p�iv��." : "Good day to you.";
        first_greeting[1] = suomi ? "Siit� onkin hetki kun t�nne on viimeksi l�hetetty joku." : "It has been a long time, since someone was sent here.";
        first_greeting[2] = suomi ? "Pakko sanoa, sinun kohdallasi pid�n t�t� v�h�n ylily�ntin�," : "I have to say, this is a little bit too harsh for you";
        first_greeting[3] = suomi ? "mutta enh�n min� p��t�ksi� tee." : "but I don't make decisions.";
        first_greeting[4] = suomi ? "Irrota ratas niin voimme aloittaa." : "Detach the gear and we can begin.";

        instructions[0] = suomi ? "Nyt on aikasi k�yd� viimeiseen taisteluun." : "Now it's time fo your last battle.";
        instructions[1] = suomi ? "Kiinnit� aseesi rattaaseen ja aseta ratas taas paikalleen." : "Attach your weapons to the gear and put it back in it's place.";
        instructions[2] = suomi ? "No niin. Ved� vivusta, kun olet valmis." : "That's that. Pull the lever, when you are ready.";
        instructions[3] = suomi ? "Min� tosiaan toivon, ettei minun tarvits selitt�� t�t� osaa." : "I really hope, I don't have to explain this part.";
        instructions[4] = suomi ? "Aaa... Minun olisi varmaan pin�nyt varoittaa." : "Oh... I propably should have warned you.";
        //First victory
        instructions[5] = suomi ? "Onneksi olkoon. Ensimm�isen kohtaamisen voittaja olet sin�." : "Congradulations. You won the first encounter.";
        instructions[6] = suomi ? "Mutta lis�� on tulossa ja tulet tarvitsemaan jotain vahvempaa niit� varten." : "But more is comming, and you will need something more powerfull against them.";
        instructions[7] = suomi ? "Valitse yksi n�ist�" : "Choose one of these.";

        //Boss 1
        boss_intros[0] = suomi ? "Olet taistellut hyvin." : "You have fought well.";
        boss_intros[1] = suomi ? "Mutta seuraava vastustaja tulee olemaan vaarallisempi kuin mik��n ennen kohtaamasi." : "But the next foe will be more dangerous than anyhting you have faced this far.";
        boss_intros[2] = suomi ? "Onnea matkaan." : "Wish you luck.";

        //End of first play through
        finished_playthroughs[0] = suomi ? "Noin sit� pit��!" : "That's how it is done!";
        finished_playthroughs[1] = suomi ? "Et ole p�ll�mpi t�ss�." : "You are not bad at this";
        finished_playthroughs[2] = suomi ? "T�m� on ollut hauskaa, mutta teloitus on teloitus..." : "This has been fun, but execution is an execution...";
        finished_playthroughs[3] = suomi ? "Kunnes j�lleen kohtaamme." : "Until we meet again.";

    }
}
