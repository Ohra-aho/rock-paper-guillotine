using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBark : MonoBehaviour
{
    public GameObject bark;
    int index;

    public List<string> barks_0; 
    public List<string> barks_1;
    public List<string> barks_2;

    int round = 0;

    private void Awake()
    {
         index = Random.Range(0, barks_0.Count);
    }

    public void Bark()
    {
        GameObject new_bark = Instantiate(bark, GameObject.Find("BarkHolder").transform);
        switch(round)
        {
            case <= 5:
                new_bark.GetComponent<Bark>().bark = barks_0[index];
                break;
            case < 18:
                new_bark.GetComponent<Bark>().bark = barks_1[index];
                break;
            case >= 18:
                new_bark.GetComponent<Bark>().bark = barks_2[index];
                break;
        }

        new_bark.GetComponent<Bark>().immediate = true;
        new_bark.GetComponent<Bark>().Inisiate();
    }

    public void IncreaseRounds()
    {
        round++;
    }
}
