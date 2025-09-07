using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public List<GameObject> hearts;
    public GameObject heart;
    public GameObject heart_slot;
    public bool dead;
    public int HP_gap = 15;
    private int slots = 15;
    private int max_health = 2;
    private int current_health;


    public void TakeDamage(int damage)
    {
        current_health -= damage;
        if (current_health < 0) current_health = 0;
        for(int i = 0; i < damage; i++)
        {
            for(int j = transform.childCount-1; j >= 0; j--)
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
        dead = CheckIfDead();
    }

    public void HealDamage(int damage)
    {
        current_health += damage;
        if (current_health > max_health) current_health = max_health;
        for (int i = 0; i < damage; i++)
        {
            for (int j = 0; j < transform.childCount; j++)
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
        dead = CheckIfDead();
    }

    public void HealToFull()
    {
        current_health = max_health;
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
        current_health = 0;
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
        bool found = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Heart>())
            {
                if (transform.GetChild(i).GetComponent<Heart>().healthy)
                {
                    found = false;
                    break;
                }
            }
        }
        return found;
    }

    public void DisplayHealthBar(int? maxHealth)
    {
        max_health = maxHealth ?? max_health;
        current_health = max_health;
        DestroyHealthBar();
        RecostructHealthBar(max_health, max_health, false);
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

    public void RecostructHealthBar(int max, int current, bool in_view)
    {
        int temp_current = current;
        if (temp_current < 0) temp_current = 0;
        for (int i = 0; i < temp_current; i++)
        {
            GameObject new_heart = Instantiate(heart, transform);
            if(in_view) new_heart.GetComponent<Heart>().heal();
        }

        for (int i = temp_current; i < max; i++)
        {
            GameObject new_heart = Instantiate(heart, transform);
            new_heart.GetComponent<Heart>().healthy = false;
        }

        AddHeartSlots();
    }

    private void AddHeartSlots()
    {
        int x = max_health;
        if (x > HP_gap) x = HP_gap;

        int children = slots - x;
        for(int i = 0; i < children; i++)
        {
            Instantiate(heart_slot, transform);
        }
    }

    public void IncreaseHealthBar(int amount, bool in_view)
    {
        max_health += amount;
        current_health += amount;
        int damage_taken = max_health - current_health;
        int x = max_health;
        int y = current_health;
        if (x > HP_gap) x = HP_gap;
        if (y > HP_gap) y = HP_gap;

        if (!FullHealthBar())
        {
            DestroyHealthBar();
            RecostructHealthBar(x, y, in_view);
        }
    }

    public void DecreaseHealthBar(int amount, bool in_view)
    {
        max_health -= amount;
        current_health -= amount;
        int x = max_health;
        int y = current_health;
        if (x > HP_gap) x = HP_gap;
        if (y > HP_gap) y = HP_gap;

        DestroyHealthBar();
        RecostructHealthBar(x, y, in_view);
    }


    public int GiveCurrentHealth()
    {
        return current_health;
    }

    public int GiveMaxHealth()
    {
        return max_health;
    }

    public void SetMaxHealth(int amount)
    {
        max_health = amount;
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
        current_health = amount;
        for (int i = 0; i < transform.childCount; i++)
        {
            if(i < amount)
            {
                if(transform.GetChild(i).GetComponent<Heart>())
                {
                    transform.GetChild(i).GetComponent<Heart>().UtilFull();
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

    public void PowerHealthBarDown()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<Heart>())
            {
                if(transform.GetChild(i).GetComponent<Heart>().healthy)
                {
                    transform.GetChild(i).GetComponent<Test>().PlayAnimation("PowerDown");
                }
            }
        }
    }

    public void PowerHealthBarUp()
    {

        for (int i = 0; i < current_health; i++)
        {
            if (transform.GetChild(i).GetComponent<Heart>())
            {
                if(transform.GetChild(i).GetComponent<Heart>().healthy)
                {
                    transform.GetChild(i).GetComponent<Test>().PlayAnimation("Heal");
                }
            }
        }
    }

    public bool FullHealthBar()
    {
        int amount_of_bulbs = 0;
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<Heart>())
            {
                amount_of_bulbs++;
            }
        }
        return amount_of_bulbs == HP_gap;
    }

    public int HealthBarSize()
    {
        int amount_of_bulbs = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Heart>())
            {
                amount_of_bulbs++;
            }
        }
        return amount_of_bulbs;
    }
}
