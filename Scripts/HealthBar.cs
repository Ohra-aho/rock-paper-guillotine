using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public List<GameObject> hearts;
    public GameObject heart;
    public GameObject heart_slot;
    public bool dead;


    public void TakeDamage(int damage)
    {
        for(int i = 0; i < damage; i++)
        {
            for(int j = 0; j < transform.childCount; j++)
            {
                if (transform.GetChild(j).GetComponent<Heart>())
                {
                    if (transform.GetChild(j).GetComponent<Heart>().healthy)
                    {
                        transform.GetChild(j).GetComponent<Heart>().damage();
                        break;
                    }
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
                if (transform.GetChild(j).GetComponent<Heart>())
                {
                    if (!transform.GetChild(j).GetComponent<Heart>().healthy)
                    {
                        transform.GetChild(j).GetComponent<Heart>().heal();
                        break;
                    }
                }
            }
        }
    }

    public void HealToFull()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            if (transform.GetChild(i).GetComponent<Heart>())
            {
                if (!transform.GetChild(i).GetComponent<Heart>().healthy)
                {
                    transform.GetChild(i).GetComponent<Heart>().heal();
                }
            }
        }
    }

    public void InstaKill()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Heart>())
            {
                if (transform.GetChild(i).GetComponent<Heart>().healthy)
                {
                    transform.GetChild(i).GetComponent<Heart>().damage();
                }
            }
        }
    }

    public bool CheckIfDead()
    {
        bool temp = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<Heart>())
            {
                if (transform.GetChild(i).GetComponent<Heart>().healthy)
                {
                    temp = false;
                    break;
                }
            }
        }
        dead = temp;
        return temp;
    }

    public void DisplayHealthBar(int maxHealth)
    {
        DestroyHealthBar();
        if (maxHealth > 15) maxHealth = 15;
        for (int i = 0; i < maxHealth; i++)
        {
            Instantiate(heart, this.transform);
        }
        AddHeartSlots();
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

    private void AddHeartSlots()
    {
        int children = 15 - transform.childCount;
        for (int i = 0; i < children; i++)
        {
            Instantiate(heart_slot, transform);
        }
    }

    public void ClearHeartSlots()
    {
        int x = transform.childCount-1;
        if (x > 0)
        {
            for (int i = x; i > 0; i--)
            {
                if(!transform.GetChild(i).GetComponent<Heart>())
                {
                    DestroyImmediate(transform.GetChild(i).gameObject);
                }
            }
        }
    }

    public void IncreaseHealthBar(int amount)
    {
        ClearHeartSlots();
        if (this.transform.childCount < 15)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(heart, this.transform);
            }
        }
        AddHeartSlots();
    }

    public void DecreaseHealthBar(int amount)
    {
        ClearHeartSlots();
        int x = transform.childCount-1;
        if (x > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                DestroyImmediate(transform.GetChild(x-i).gameObject);
            }
        }
        AddHeartSlots();
    }

    public int GiveCurrentHealth()
    {
        int amount = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Heart>())
            {
                if (transform.GetChild(i).GetComponent<Heart>().healthy)
                {
                    amount++;
                }
            }
        }
        return amount;
    }

    public int GiveMaxHealth()
    {
        int amount = 0;
        for(int i = 0; i < transform.childCount; i++)
        {
            if(!transform.GetChild(i).GetComponent<Heart>())
            {
                amount++;
            }
        }
        return amount;
    }
}
