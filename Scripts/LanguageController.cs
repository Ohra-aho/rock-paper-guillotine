using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageController : MonoBehaviour
{
    public bool suomi;

    public string[] first_greeting = { "No p�iv��.", "Siit� onkin hetki kun t�nne on viimeksi l�hetetty joku.", "Pakko sanoa, sinun kohdallasi pid�n t�t� v�h�n ylily�ntin�,", "mutta enh�n min� p��t�ksi� tee.", "Irrota ratas niin voimme aloittaa." };
    public string[] instructions = { "Nyt on aikasi k�yd� viimeiseen taisteluun.", "Kiinnit� aseesi rattaaseen ja aseta ratas taas paikalleen.", "No niin. Ved� vivusta kun olet valmis." };

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
        first_greeting[0] = suomi ? "No p�iv��." : "Good day to you.";
        first_greeting[1] = suomi ? "Siit� onkin hetki kun t�nne on viimeksi l�hetetty joku." : "It has been a long time, since someone was sent here.";
        first_greeting[2] = suomi ? "Pakko sanoa, sinun kohdallasi pid�n t�t� v�h�n ylily�ntin�," : "I have to say, this is a little bit too harsh for you";
        first_greeting[3] = suomi ? "mutta enh�n min� p��t�ksi� tee." : "but I don't make decisions.";
        first_greeting[4] = suomi ? "Irrota ratas niin voimme aloittaa." : "Detach the gear and we can begin.";

        instructions[0] = suomi ? "Nyt on aikasi k�yd� viimeiseen taisteluun." : "Now it's time fo your last battle.";
        instructions[1] = suomi ? "Kiinnit� aseesi rattaaseen ja aseta ratas taas paikalleen." : "Attach your weapons to the gear and put it back in it's place.";
        instructions[2] = suomi ? "No niin. Ved� vivusta, kun olet valmis." : "That's that. Pull the lever, when you are ready.";
    }
}
