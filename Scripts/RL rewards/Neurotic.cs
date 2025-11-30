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


    private List<GameObject> true_tier_1_rocks = new List<GameObject>();
    private List<GameObject> true_tier_1_papers = new List<GameObject>();
    private List<GameObject> true_tier_1_scissors = new List<GameObject>();

    private List<GameObject> true_tier_2_rocks = new List<GameObject>();
    private List<GameObject> true_tier_2_papers = new List<GameObject>();
    private List<GameObject> true_tier_2_scissors = new List<GameObject>();

    private List<GameObject> true_tier_3_rocks = new List<GameObject>();
    private List<GameObject> true_tier_3_papers = new List<GameObject>();
    private List<GameObject> true_tier_3_scissors = new List<GameObject>();

    GameObject RI;
    private void Awake()
    {
        RI = GameObject.FindGameObjectWithTag("RI");
    }

    public GameObject GiveRandomRock(int tier)
    {
        switch (tier)
        {
            case 1:
                int i = Random.Range(0, true_tier_1_rocks.Count);
                return true_tier_1_rocks[i];
            case 2:
                int j = Random.Range(0, true_tier_2_rocks.Count);
                return true_tier_2_rocks[j];
            case 3:
                int h = Random.Range(0, true_tier_3_rocks.Count);
                return true_tier_3_rocks[h];
        }
        return tier_1_rocks[0];
    }

    public GameObject GiveRandomPaper(int tier)
    {
        switch (tier)
        {
            case 1:
                int i = Random.Range(0, true_tier_1_papers.Count);
                return true_tier_1_papers[i];
            case 2:
                int j = Random.Range(0, true_tier_2_papers.Count);
                return true_tier_2_papers[j];
            case 3:
                int h = Random.Range(0, true_tier_3_papers.Count);
                return true_tier_3_papers[h];
        }
        return tier_1_rocks[0];
    }

    public GameObject GiveRandomScissors(int tier)
    {
        switch (tier)
        {
            case 1:
                int i = Random.Range(0, true_tier_1_scissors.Count);
                return true_tier_1_scissors[i];
            case 2:
                int j = Random.Range(0, true_tier_2_scissors.Count);
                return true_tier_2_scissors[j];
            case 3:
                int h = Random.Range(0, true_tier_3_scissors.Count);
                return true_tier_3_scissors[h];
        }
        return tier_1_rocks[0];
    }


    public void MakeTrueRewardLists()
    {
        true_tier_1_rocks.Clear();
        true_tier_1_papers.Clear();
        true_tier_1_scissors.Clear();

        true_tier_2_rocks.Clear();
        true_tier_2_papers.Clear();
        true_tier_2_scissors.Clear();

        true_tier_3_rocks.Clear();
        true_tier_3_papers.Clear();
        true_tier_3_scissors.Clear();

        AddPossibleWeapons(tier_1_rocks, true_tier_1_rocks);
        AddPossibleWeapons(tier_1_papers, true_tier_1_papers);
        AddPossibleWeapons(tier_1_scissors, true_tier_1_scissors);

        AddPossibleWeapons(tier_2_rocks, true_tier_2_rocks);
        AddPossibleWeapons(tier_2_papers, true_tier_2_papers);
        AddPossibleWeapons(tier_2_scissors, true_tier_2_scissors);

        AddPossibleWeapons(tier_3_rocks, true_tier_3_rocks);
        AddPossibleWeapons(tier_3_papers, true_tier_3_papers);
        AddPossibleWeapons(tier_3_scissors, true_tier_3_scissors);
    }

    private void AddPossibleWeapons(List<GameObject> target_list, List<GameObject> list_to_add)
    {
        for (int i = 0; i < target_list.Count; i++)
        {
            bool found = FindWeaponByName(target_list[i].GetComponent<Weapon>().name);
            if (!found)
            {
                list_to_add.Add(target_list[i]);
            }
        }
    }

    private bool FindWeaponByName(string name)
    {
        for (int j = 0; j < RI.transform.childCount; j++)
        {
            if (RI.transform.GetChild(j).GetComponent<Weapon>().name == name)
            {
                return true;
            }
        }
        return false;
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
