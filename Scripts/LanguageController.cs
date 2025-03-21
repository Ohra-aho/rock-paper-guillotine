using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageController : MonoBehaviour
{
    public bool suomi;

    public string[] first_greeting = { "No päivää.", "Siitä onkin hetki kun tänne on viimeksi lähetetty joku.", "Pakko sanoa, sinun kohdallasi pidän tätä vähän ylilyöntinä,", "mutta enhän minä päätöksiä tee.", "Irrota ratas niin voimme aloittaa." };
    public string[] instructions = { "Nyt on aikasi käydä viimeiseen taisteluun.", "Kiinnitä aseesi rattaaseen ja aseta ratas taas paikalleen.", "No niin. Vedä vivusta kun olet valmis." };

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
        first_greeting[0] = suomi ? "No päivää." : "Good day to you.";
        first_greeting[1] = suomi ? "Siitä onkin hetki kun tänne on viimeksi lähetetty joku." : "It has been a long time, since someone was sent here.";
        first_greeting[2] = suomi ? "Pakko sanoa, sinun kohdallasi pidän tätä vähän ylilyöntinä," : "I have to say, this is a little bit too harsh for you";
        first_greeting[3] = suomi ? "mutta enhän minä päätöksiä tee." : "but I don't make decisions.";
        first_greeting[4] = suomi ? "Irrota ratas niin voimme aloittaa." : "Detach the gear and we can begin.";

        instructions[0] = suomi ? "Nyt on aikasi käydä viimeiseen taisteluun." : "Now it's time fo your last battle.";
        instructions[1] = suomi ? "Kiinnitä aseesi rattaaseen ja aseta ratas taas paikalleen." : "Attach your weapons to the gear and put it back in it's place.";
        instructions[2] = suomi ? "No niin. Vedä vivusta, kun olet valmis." : "That's that. Pull the lever, when you are ready.";
    }
}
