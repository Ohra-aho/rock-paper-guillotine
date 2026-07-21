using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayThroughData
{
    public string[] enemies;
	public string tier;

    public bool used;

    public PlayThroughData(Encounter encounter)
    {
		if(encounter != null)
		{
			if(encounter.enemies.Count > 0)
			{
				enemies = ExtractEnemies(encounter);
				tier = encounter.gameObject.name;
			}	
		} else
		{
			enemies = new string[0];
			tier = "";
		}
		
    }

	private string[] ExtractEnemies(Encounter encounter)
	{
		List<string> temp = new List<string>();
		for(int i = 0; i < encounter.enemies.Count; i++)
		{
			temp.Add(encounter.enemies[i].name);
		}
		return temp.ToArray();;
	}
}
