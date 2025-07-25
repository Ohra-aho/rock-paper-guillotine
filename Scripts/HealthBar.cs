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
            GameObject new_heart = Instantiate(heart, this.transform);
            new_heart.GetComponent<Heart>().heal();
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
        int children = 15 - GiveMaxHealth();
        for(int i = 0; i < 15 - GiveMaxHealth(); i++)
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
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
    }

    public void IncreaseHealthBar(int amount)
    {
        ClearHeartSlots();
        //if (this.transform.childCount < 15)
        //{
            for (int i = 0; i < amount; i++)
            {
                GameObject new_heart = Instantiate(heart, this.transform);
                new_heart.GetComponent<Heart>().heal();
            }
        //}
        AddHeartSlots();
    }

    public void DecreaseHealthBar(int amount)
    {
        ClearHeartSlots();
        int x = GiveMaxHealth()-1;
        //if (x > 0)
        //{
            for (int i = 0; i < amount; i++)
            {
                Destroy(transform.GetChild(x-i).gameObject);
            }
        //}
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
            if(transform.GetChild(i).GetComponent<Heart>())
            {
                amount++;
            }
        }
        return amount;
    }

    public void SetMaxHealth(int amount)
    {
        DestroyHealthBar();
        for(int i = 0; i < amount; i++)
        {
            GameObject new_heart = Instantiate(heart, transform);
            new_heart.GetComponent<Heart>().UtilEmpty();
        }
        AddHeartSlots();
    }

    public void SetCurrentHealth(int amount)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(i < amount)
            {
                if(transform.GetChild(i).GetComponent<Heart>())
                {
                    transform.GetChild(i).GetComponent<Heart>().heal();
                }
            } else
            {
                if (transform.GetChild(i).GetComponent<Heart>())
                {
                    transform.GetChild(i).GetComponent<Heart>().UtilEmpty();
                }
            }
        }
    }
}
