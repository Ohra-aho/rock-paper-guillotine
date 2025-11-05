using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueRandom : MonoBehaviour
{
    public int range_start;
    public int range_end;

    int previous_index = -1; //-1 means, no previous index

    public int GiveRandomIndex()
    {
        int repeat_chance = Random.Range(1, 3);

        int index = Random.Range(range_start, range_end + 1);
        if(repeat_chance != 1)
        {
            while (index == previous_index)
            {
                index = Random.Range(range_start, range_end + 1);
            }
        }

        return index;
    }
}
