using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrative : MonoBehaviour
{
    public List<GameObject> before_first_encounter;
    public List<GameObject> boss_introduxtions_1;
    public List<GameObject> boss_introduxtions_2;
    public List<GameObject> boss_introduxtions_3;
    public List<GameObject> boss_introduxtions_4;

    public List<GameObject> boss_victories_1;
    public List<GameObject> boss_victories_2;
    public List<GameObject> boss_victories_3;

    public List<GameObject> end;

    public List<GameObject> exe_boss_victories;
    public List<GameObject> exe_boss_intros;

    public GameObject death;


	public GameObject GiveRandomBossIntro(int tier)
	{
		switch(tier)
		{
			case 1: return boss_introduxtions_1[Random.Range(0, boss_introduxtions_1.Count)];
			case 2: return boss_introduxtions_2[Random.Range(0, boss_introduxtions_2.Count)];
			case 3: return boss_introduxtions_3[Random.Range(0, boss_introduxtions_3.Count)];
			case 4: return boss_introduxtions_4[Random.Range(0, boss_introduxtions_4.Count)];
			default: return boss_introduxtions_1[Random.Range(0, boss_introduxtions_1.Count)];
		}
	}

	public GameObject GiveRandomBossVictory(int tier)
	{
		switch(tier)
		{
			case 1: return boss_victories_1[Random.Range(0, boss_victories_1.Count)];
			case 2: return boss_victories_2[Random.Range(0, boss_victories_2.Count)];
			case 3: return boss_victories_3[Random.Range(0, boss_victories_3.Count)];
			case 4: return end[Random.Range(0, end.Count)];
			default: return boss_victories_1[Random.Range(0, boss_victories_1.Count)];
		}
	}
}
