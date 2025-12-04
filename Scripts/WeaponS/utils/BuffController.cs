using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuffController : MonoBehaviour
{
    public MainController.Choise? type_change = null;

    private bool buff_on = false;
    [SerializeField] public GameObject buff;
    GameObject real_inventory;
    GameObject other_inventory;
    [HideInInspector] public int damage_bonus = 0;
    [HideInInspector] public int armor_bonus = 0;
    [HideInInspector] public int effect_damage_bonus = 0;
    [HideInInspector] public bool set_a_to_zero = false;
    [HideInInspector] public bool set_d_to_zero = false;
    public bool always_on = true;

    //[HideInInspector] public UnityEvent special;
    public delegate void Special(Weapon weapon);
    public Special special;
    public Special special_removal;
    public delegate bool Requirement(Weapon weapon);
    public Requirement buff_requirement;

    //To where put special
    [HideInInspector] public bool choisePhase;
    [HideInInspector] public bool resultPhase;
    [HideInInspector] public bool endPhase;
    [HideInInspector] public bool victory;
    [HideInInspector] public bool special_apply;

    [HideInInspector] public bool takeDamage;
    [HideInInspector] public bool takeNoDamage;
    [HideInInspector] public bool dealDamage;
    [HideInInspector] public bool deal_effect_damage;
    [HideInInspector] public bool draw;
    [HideInInspector] public bool win;
    [HideInInspector] public bool lose;
    [HideInInspector] public bool heal;

    [HideInInspector] public bool equip;
    [HideInInspector] public bool unEquip;

    [HideInInspector] public bool constant;
    [HideInInspector] public bool onDestruction;
    [HideInInspector] public bool awake;

    //Other
    [HideInInspector] public bool temporary;
    [HideInInspector] public int timer; //used for temporary buffs

    [HideInInspector] public bool penetrating;
    [HideInInspector] public bool draw_winner;

    [HideInInspector] public int health_buff;

    //Debuffs
    [HideInInspector] public bool destructive;



    private void Awake()
    {
        Inisiate();
    }

    public void Inisiate() 
    {
        if (GetComponent<Weapon>().player)
        {
            real_inventory = GameObject.FindGameObjectWithTag("RI");
            other_inventory = GameObject.FindGameObjectWithTag("RIE");
            if (!special_apply)
            {
                GetComponent<Weapon>().equip.AddListener(Equip);
                GetComponent<Weapon>().unEquip.AddListener(Unequip);
            }
        }
        else
        {
            real_inventory = GameObject.FindGameObjectWithTag("RIE");
            other_inventory = GameObject.FindGameObjectWithTag("RI");
        }
    }

    public void Equip()
    {
        buff_on = true;
        AddBuffs();
    }

    public void Unequip()
    {
        buff_on = false;
        AddBuffs();
    }

    public void AddBuffs()
    {
        if (buff_on)
        {
            for (int i = 0; i < real_inventory.transform.childCount; i++)
            {
                Transform weapon = real_inventory.transform.GetChild(i);
                if (buff_requirement(weapon.GetComponent<Weapon>()))
                {
                    AddBuff(weapon);
                }
            }
        }
        else
        {
            RemoveBuffs();
        }
    }

    private void AddBuff(Transform weapon)
    {
        if (!IfOwnBuffExists(weapon))
        {
            if (set_a_to_zero) armor_bonus = -weapon.GetComponent<Weapon>().armor;
            if (set_d_to_zero) damage_bonus = -weapon.GetComponent<Weapon>().damage;

            Buff new_buff = Instantiate(buff, weapon).GetComponent<Buff>();
            new_buff.id = GetComponent<Weapon>().name;
            new_buff.damage_buff = damage_bonus;
            new_buff.armor_buff = armor_bonus;
            new_buff.effect_damage_buff = effect_damage_bonus;
            new_buff.choisePhase = choisePhase;
            new_buff.resultPhase = resultPhase;
            new_buff.endPhase = endPhase;
            new_buff.victory = victory;
            new_buff.takeDamage = takeDamage;
            new_buff.takeNoDamage = takeNoDamage;
            new_buff.dealDamage = dealDamage;
            new_buff.draw = draw;
            new_buff.heal = heal;
            new_buff.constant = constant;
            new_buff.onDestruction = onDestruction;
            new_buff.awake = awake;
            new_buff.win = win;
            new_buff.lose = lose;
            new_buff.timer = timer;
            new_buff.temporary = temporary;
            new_buff.type_change = type_change;
            new_buff.draw_winner = draw_winner;
            new_buff.penetrating = penetrating;
            new_buff.destructive = destructive;
            new_buff.health_buff = health_buff;
            new_buff.deal_effect_damage = deal_effect_damage;
            if (special != null) new_buff.GetComponent<Buff>().special = special;
            if (special_removal != null) new_buff.GetComponent<Buff>().special_removal = special_removal;
            new_buff.GetComponent<Buff>().AddBuff();
        } else
        {
            Buff buff = FindBuffByName(GetComponent<Weapon>().name, weapon);
            if(timer != 0) buff.timer = timer;
        }
    }

    public void RemoveBuffs()
    {
        if (!buff_on)
        {
            for (int i = 0; i < real_inventory.transform.childCount; i++)
            {
                Transform weapon = real_inventory.transform.GetChild(i);
                List<GameObject> own_buffs = FindOwnBuff(weapon);
                for(int j = own_buffs.Count-1; j >= 0; j--)
                {
                    own_buffs[j].GetComponent<Buff>().RemoveBuff();
                    Destroy(own_buffs[j]);
                }
            }
        }
        for (int i = 0; i < other_inventory.transform.childCount; i++)
        {
            Transform weapon = other_inventory.transform.GetChild(i);
            List<GameObject> own_buffs = FindOwnBuff(weapon);
            for (int j = own_buffs.Count - 1; j >= 0; j--)
            {
                own_buffs[j].GetComponent<Buff>().RemoveBuff();
                Destroy(own_buffs[j]);
            }
        }
    }

    public void AddBuffToOneWeapon(Transform weapon)
    {
        if (buff_requirement(weapon.GetComponent<Weapon>()))
        {
            AddBuff(weapon);
        }
    }

    private bool IfOwnBuffExists(Transform weapon)
    {
        bool found = false;
        for (int i = 0; i < weapon.childCount; i++)
        {
            if (weapon.GetChild(i).GetComponent<Buff>().id == GetComponent<Weapon>().name)
            {
                found = true;
            }
        }
        return found;
    }

    private Buff? FindBuffByName(string name, Transform weapon)
    {
        for (int i = 0; i < weapon.childCount; i++)
        {
            if (weapon.GetChild(i).GetComponent<Buff>().id == name)
            {
                return weapon.GetChild(i).GetComponent<Buff>();
            }
        }
        return null;
    }

    public List<GameObject> FindOwnBuff(Transform weapon)
    {
        List<GameObject> temp = new List<GameObject>();
        for (int i = 0; i < weapon.childCount; i++)
        {
            if (weapon.GetChild(i).GetComponent<Buff>().id == GetComponent<Weapon>().name)
            {
                temp.Add(weapon.GetChild(i).gameObject);
            }
        }
        return temp;
        //return null;
    }

    private void OnDestroy()
    {
        RemoveBuffs();
    }
}
