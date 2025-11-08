using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementMenu : MonoBehaviour
{
    public GameObject achievement_instructions;

    string[][] achievements =
    {
        new string[] { "Tough", "Win an encounter with 10 or more max HP" },
        new string[] { "Collector", "Own 13 or more weapons." },
        new string[] { "Slaughterer", "Win a fight while owning a weapon with 7 or more damage." },
        new string[] { "Slow", "Take damage on the first turn 3 times in a row." },
        new string[] { "Experimentor", "Use 13 different weapons during." },
        new string[] { "Madman", "Win a fight with at least 2 'useless' weapons equipped." },
        new string[] { "Traditionalist", "Win a fight with the original rock, paper or sciccors after the first boss." },
        new string[] { "Risk taker", "Win a fight with no weapons left equipped." },
        new string[] { "Neurotic", "Own 4 rocks, 4 sicssors and 4 papers."},
        new string[] { "Plotter", "Win an fight with only effect damage dealing weapons equipped." },
        new string[] { "Survivor", "Win 3 fights with 1 HP." },
        new string[] { "Relentless", "Win a fight with a draw." },
        new string[] { "Unyielding", "Heal 3 times during a one fight." },
        new string[] { "Picky", "After the first boss, own 7 weapons you have never brought to a fight." },
        new string[] { "Hoarder", "Collect total of 20 points." },
    };

    private void Awake()
    {
        MakeInstructionList();
    }

    public void MakeInstructionList()
    {
        for(int i = 0; i < achievements.Length; i++)
        {
            GameObject new_instructions = Instantiate(achievement_instructions, transform.GetChild(1).GetChild(0));
            new_instructions.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = achievements[i][0];
            new_instructions.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = achievements[i][1];
        }
        transform.GetChild(1).GetComponent<ScrollView>().AdjustScrollSize();
    }
}
