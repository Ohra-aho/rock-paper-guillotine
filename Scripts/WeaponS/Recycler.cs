using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycler : MonoBehaviour
{
    int previous_index = -1;
    public List<GameObject> scraps;

    private void Awake()
    {
        GetComponent<BuffController>().buff_requirement = (Weapon w) => { return w.name != "Scrap"; };
        GetComponent<BuffController>().onDestruction = true;
        GetComponent<BuffController>().special = GainScrap;
    }

    public void GainScrap(Weapon w)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        int index = Random.Range(0, scraps.Count);
        while(index == previous_index)
        {
            index = Random.Range(0, scraps.Count);
        }
        previous_index = index;
        player.GetComponent<PlayerInventory>().AddItem(scraps[index]);
    }
}
