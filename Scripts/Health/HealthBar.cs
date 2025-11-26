using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    MainController MC;
    public List<GameObject> hearts;
    public GameObject heart;
    public GameObject heart_slot;
    public bool dead;
    public int HP_gap = 15;
    private int slots = 15;
    private int max_health = 2;
    private int current_health;
    public List<string> warning_barks;
    public List<string> low_health_barks;
    public List<string> high_damage_barks;
    //Bark stoppers
    [HideInInspector] public bool warning_given = false;
    [HideInInspector] public bool low_health = false;

    private void Awake()
    {
        MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
    }

    private void Update()
    {
        if(gameObject.CompareTag("PlayerHealth"))
        {
            if (MC.game_state != MainController.State.in_battle && low_health) low_health = false;
            if (MC.game_state != MainController.State.re_arming && warning_given) warning_given = false;
        }
    }

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
        if (gameObject.CompareTag("PlayerHealth") && !dead) {
            //Damage animations
            if(GiveCurrentHealth() >= GiveMaxHealth() - GiveMaxHealth()/3)
            {
                Camera.main.GetComponent<Test>().PlayAnimation("Damage 1");
            }
            else if(GiveCurrentHealth() <= GiveMaxHealth()/2 && GiveCurrentHealth() > GiveMaxHealth()/3)
            {
                Camera.main.GetComponent<Test>().PlayAnimation("Damage 2");
            }
            else if(GiveCurrentHealth() <= GiveMaxHealth() / 3)
            {
                Camera.main.GetComponent<Test>().PlayAnimation("Damage 3");
            }

            LowHealthReaction();
        } else if(gameObject.CompareTag("PlayerHealth"))
        {
            if (dead)
            {
                Camera.main.GetComponent<Test>().PlayAnimation("dead react");
            }
        }
        if(!dead) HighDamageReaction(damage);
        
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

        if (!FullHealthBar())
        {
            if (MC.game_state == MainController.State.in_battle) {
                transform.parent.GetChild(4).GetComponent<Test>().PlayAnimation("Change health"); 
            } else
            {
                int x = max_health;
                int y = current_health;
                if (x > HP_gap) x = HP_gap;
                if (y > HP_gap) y = HP_gap;
                DestroyHealthBar();
                RecostructHealthBar(x, y, in_view);
            }
            
        }
    }

    public void TrueReconstruct()
    {
        int x = max_health;
        int y = current_health;
        if (x > HP_gap) x = HP_gap;
        if (y > HP_gap) y = HP_gap;
        DestroyHealthBar();
        RecostructHealthBar(x, y, true);
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
        int temp = 0;
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<Heart>())
            {
                if (transform.GetChild(i).GetComponent<Heart>().healthy)
                {
                    temp++;
                }
            }
        }
        return temp;
    }

    public int GiveMaxHealth()
    {
        if(max_health > 15)
        {
            return 15;
        }
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
        int x = current_health;
        if (x > HP_gap) x = HP_gap;
        for (int i = 0; i < x; i++)
            if (transform.GetChild(i).GetComponent<Heart>())
                if(transform.GetChild(i).GetComponent<Heart>().healthy)
                    transform.GetChild(i).GetComponent<Test>().PlayAnimation("Heal");
                
            
        
    }

    public bool FullHealthBar()
    {
        int amount_of_bulbs = 0;
        for(int i = 0; i < transform.childCount; i++)
            if(transform.GetChild(i).GetComponent<Heart>())
                amount_of_bulbs++;
            
        return amount_of_bulbs == HP_gap;
    }

    public int HealthBarSize()
    {
        int amount_of_bulbs = 0;
        for (int i = 0; i < transform.childCount; i++)
            if (transform.GetChild(i).GetComponent<Heart>())
                amount_of_bulbs++;
            
        return amount_of_bulbs;
    }


    //Barking

    private void Bark(string message)
    {
        GameObject bark_holder = GameObject.Find("BarkHolder");
        GameObject new_bark = Instantiate(bark_holder.GetComponent<BarkController>().bark_template, bark_holder.transform);
        new_bark.GetComponent<Bark>().SetTrueBark(message);
        new_bark.GetComponent<Bark>().TheBark();
    }

    public void GiveAwarning()
    {
        if(GiveCurrentHealth() <= 0 && !warning_given)
        {
            warning_given = true;
            int index = Random.Range(0, warning_barks.Count);
            Bark(warning_barks[index]);
        }
    }

    public void LowHealthReaction()
    {
        if(GiveCurrentHealth() <= GiveMaxHealth() / 3 && !low_health && GiveCurrentHealth() > 0)
        {
            low_health = true;
            int index = Random.Range(0, low_health_barks.Count);
            Bark(low_health_barks[index]);
        } else if(GiveCurrentHealth() <= 0)
        {
            GameObject.Find("Death Barks(Clone)").GetComponent<DeathBark>().Bark();
        }
    }

    public void HighDamageReaction(int amount)
    {
        if(amount >= 5)
        {
            int index = Random.Range(0, high_damage_barks.Count);
            Bark(high_damage_barks[index]);
        }
    }

}
