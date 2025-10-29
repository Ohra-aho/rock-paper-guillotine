using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neurotic : MonoBehaviour
{
    public List<GameObject> tier_1_rocks;
    public List<GameObject> tier_1_papers;
    public List<GameObject> tier_1_scissors;

    public List<GameObject> tier_2_rocks;
    public List<GameObject> tier_2_papers;
    public List<GameObject> tier_2_scissors;

    public List<GameObject> tier_3_rocks;
    public List<GameObject> tier_3_papers;
    public List<GameObject> tier_3_scissors;

    public GameObject rock_heal;
    public GameObject paper_heal;
    public GameObject scissors_heal;


    public void Chosen()
    {
        if (GetComponent<RLReward>().CheckIfCanBePicked())
        {
            GameObject.Find("EventSystem").GetComponent<RLController>().chosen_buffs.Add(this.gameObject);
        }
    }

    public GameObject GiveRandomRock(int tier)
    {
        switch (tier)
        {
            case 1:
                int i = Random.Range(0, tier_1_rocks.Count);
                return tier_1_rocks[i];
            case 2:
                int j = Random.Range(0, tier_2_rocks.Count);
                return tier_2_rocks[j];
            case 3:
                int h = Random.Range(0, tier_3_rocks.Count);
                return tier_3_rocks[h];
        }
        return tier_1_rocks[0];
    }

    public GameObject GiveRandomPaper(int tier)
    {
        switch (tier)
        {
            case 1:
                int i = Random.Range(0, tier_1_papers.Count);
                return tier_1_papers[i];
            case 2:
                int j = Random.Range(0, tier_2_papers.Count);
                return tier_2_papers[j];
            case 3:
                int h = Random.Range(0, tier_3_papers.Count);
                return tier_3_papers[h];
        }
        return tier_1_rocks[0];
    }

    public GameObject GiveRandomScissors(int tier)
    {
        switch (tier)
        {
            case 1:
                int i = Random.Range(0, tier_1_scissors.Count);
                return tier_1_scissors[i];
            case 2:
                int j = Random.Range(0, tier_2_scissors.Count);
                return tier_2_scissors[j];
            case 3:
                int h = Random.Range(0, tier_3_scissors.Count);
                return tier_3_scissors[h];
        }
        return tier_1_rocks[0];
    }

    /*
     tier 1

    kranaatti
    leka
    luu
    muuri
    teroituskivi
    järkäle
    desinfiointiaine
    laava
    noppa
    ruuti
    adrenaline
    ammunition
    holy symbol
    ice cube
    victory streak
    piikkipallo

    kilpi
    kirja
    paperihaarniska
    santapaperi
    sidetarpeet
    tappolista
    sanomalehti
    lippu
    nenäliina
    paperikori
    paperilennokki
    seteli
    viitta
    kartonki

    hampaat
    keihäs
    kynä
    lasisirpale
    miekka
    pora
    pyssy
    viikate
    heittoveitsi
    koukku
    shotgun
    hitsipilli


    Tier 2

    hiidenkivi
    savimöykky
    alasin
    philosopher stone
    silver

    bunkkeri
    voodoonukke
    pyhä teksti
    rauhansopimus
    panssarilasi
    panssari
    pääsukoodi
    tilikirja
    airbag

    fireball
    kaksiteräinen
    liekinheitin
    turmio
    giljotiini
    hilpari
    kirves
    suurmiekkä
    veritankki
    pickaxe
    giant scissors


    tier 3

    timantti
    vuori
    meteorisade
    tähti
    
    käyttöohje
    syöjätär
    sponge
    
    terämyrsky
    veriterä
    neula

     */
}
