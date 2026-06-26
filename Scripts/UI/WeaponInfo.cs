using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponInfo : MonoBehaviour
{
    public Weapon weapon;

	public GameObject reminder;
	public GameObject reminders;

    public List<Sprite> icons;
    private void Update()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.name;
        transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.GiveEffectiveDamage().ToString();
        transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.GiveEffectiveArmor().ToString();
        if (weapon.GetComponent<Stacking>())
        {
            transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(200f, 40f);
            transform.GetChild(1).GetComponent<RectTransform>().localScale = new Vector2(0.75f, 0.75f);
            transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.GetComponent<Stacking>().stacks.ToString();
        }
        else
        {
            transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(144f, 40f);
            transform.GetChild(1).GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
            transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        }
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = weapon.description;

        switch (weapon.type)
        {
            case MainController.Choise.kivi:
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[0];
                break;
            case MainController.Choise.paperi:
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[1];
                break;
            case MainController.Choise.sakset:
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[2];
                break;
            case MainController.Choise.useless:
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[3];
                break;
            case MainController.Choise.voittamaton:
                transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icons[4];
                break;
        }

		DisplayReminders();
    }

	public void DisplayReminders()
	{
		for(int i = reminders.transform.childCount-1; i >= 0; i--) {
			Destroy(reminders.transform.GetChild(i).gameObject);
		}
		if(weapon.transform.childCount > 0)
		{
			for(int i = 0; i < weapon.transform.childCount; i++)
			{
				if(weapon.transform.GetChild(i).GetComponent<Buff>().reminder != null && weapon.transform.GetChild(i).GetComponent<Buff>().reminder != "")
				{
					GameObject new_reminder = Instantiate(reminder, reminders.transform);
					new_reminder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.transform.GetChild(i).GetComponent<Buff>().reminder;
					if(weapon.transform.GetChild(i).GetComponent<Buff>().temporary && weapon.transform.GetChild(i).GetComponent<Buff>().timer < 100)
					{
						new_reminder.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Turns: " + weapon.transform.GetChild(i).GetComponent<Buff>().timer;
					}
				}
			}
		}
	}
}
