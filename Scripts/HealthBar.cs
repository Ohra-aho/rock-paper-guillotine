using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public List<GameObject> hearts;
    public GameObject heart;

    //public RectTransform healthBarRectTransform;

    public void TakeDamage(int damage)
    {
        Debug.Log("Damage: "+damage);
        
        for(int i = 0; i < damage; i++)
        {
            for(int j = 0; j < transform.childCount; j++)
            {
                if(transform.GetChild(j).GetComponent<Heart>().healthy)
                {
                    transform.GetChild(j).GetComponent<Heart>().damage();
                    break;
                }
            }
        }

    }

    public void HealDamage(int damage)
    {
        for (int i = 0; i < damage; i++)
        {
            for (int j = transform.childCount - 1; j >= 0; j--)
            {
                if (!transform.GetChild(j).GetComponent<Heart>().healthy)
                {
                    transform.GetChild(j).GetComponent<Heart>().heal();
                    break;
                }
            }
        }
    }

    public void HealToFull()
    {
        for (int j = transform.childCount - 1; j >= 0; j--)
        {
            if (!transform.GetChild(j).GetComponent<Heart>().healthy)
            {
                transform.GetChild(j).GetComponent<Heart>().heal();
            }
        }
    }

    public void InstaKill()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Heart>().healthy)
            {
                transform.GetChild(i).GetComponent<Heart>().damage();
            }
        }
    }

    public bool CheckIfDead()
    {
        bool temp = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Heart>().healthy)
            {
                temp = false;
                break;
            }
        }
        return temp;
    }

    public void DisplayHealthBar(int maxHealth)
    {
        DestroyHealthBar();
        for (int i = 0; i < maxHealth; i++)
        {
            Instantiate(heart, this.transform);
        }
    }

    public void DestroyHealthBar()
    {
        int x = transform.childCount;
        if(x > 0)
        {
            for (int i = 0; i < x; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    public void IncreaseHealthBar(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(heart, this.transform);
        }
    }

    public void DecreaseHealthBar(int amount)
    {
        int x = transform.childCount-1;
        if (x > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                Destroy(transform.GetChild(x-i).gameObject);
            }
        }
    }

    public int GiveCurrentHealth()
    {
        int amount = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Heart>().healthy)
            {
                amount++;
            }
        }
        return amount;
    }

    public int GiveMaxHealth()
    {
        return transform.childCount;
    }
}
