using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementMenu : MonoBehaviour
{
    public GameObject achievement_instructions;

    string[][] achievements =
    {
        new string[] { "Tough", "Win an encounter with 10 or more max hp" },
        new string[] { "Collector", "Own 12 or more weapons." },
        new string[] { "Slaughterer", "Deal 5 or more damage during a single round" },
        new string[] { "Slow", "Take damage on the first turn 4 times during a single game." },
        new string[] { "Experimentor", "Use 13 different weapons during a single game." },
        new string[] { "Madman", "Win a fight with at least 2 \"useless\" weapons equipped." },
        new string[] { "Martyr", "Give up after defeating at least 5 enemies." },
        new string[] { "Risk taker", "Win a fight with no weapons left equipped." },
        new string[] { "Neurotic", "Own 4 rocks, 4 sicssors and 4 papers."},
        new string[] { "Plotter", "Win 4 fights with only effect damage dealing weapons equipped in a single game." },
        new string[] { "Survivor", "Win 3 fights with 1 HP during a single game." },
        new string[] { "Relentless", "Deal damage 5 times in a row." },
        new string[] { "Unyielding", "Heal 3 times during a one fight." },
        new string[] { "Picky", "After the first boss, own 7 weapons you have never brought to a fight." },
        new string[] { "Hoarder", "Win a fight with at least 10 points on your equipped weapons." },
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
