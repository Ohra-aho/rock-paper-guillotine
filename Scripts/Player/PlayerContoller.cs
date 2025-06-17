using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerContoller : MonoBehaviour
{
    public MainController MC;
    private EnemyController currentEnemy;
    public HealthBar HB;

    //[HideInInspector] public int maxHealth = 1;
    private int maxHealth = 2;
    [HideInInspector] public int damage = 0;
    [HideInInspector] public int armor = 0;


    //Weapons
    public List<GameObject> weapons;

    public GameObject chosenWeapon;

    public int unlocked_wheel = 0;
    public List<GameObject> PlayerWheels;
    public GameObject weaponDetector;
    public GameObject TrueWeaponHolder;
    public GameObject TrueInventory;
    public GameObject WheelHolder;
    public GameObject choise_panel;

    public bool defeat = false;


    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(choise_panel, transform);
        }
        InstanciateRealWeapons();
        LoadPlayerData();
    }

    private void Update()
    {
        if (HB.dead && !defeat)
        {
            MC.Loose();
            HB.dead = false;
        }
    }

    public void DisplayChoises()
    {
        for(int i = 0; i < 6; i++)
        {
            if(PlayerWheels[unlocked_wheel].transform.childCount-1 > i)
            {
                if (PlayerWheels[unlocked_wheel].transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
                {
                    transform.GetChild(i).GetComponent<CHoisePanel>().weapon =
                        PlayerWheels[unlocked_wheel].transform.GetChild(i).GetChild(0)
                            .GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>();

                    transform.GetChild(i).GetComponent<CHoisePanel>().weapon_name =
                        PlayerWheels[unlocked_wheel].transform.GetChild(i).GetChild(0)
                            .GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>().name;

                    transform.GetChild(i).GetComponent<CHoisePanel>().index = i;
                }
            }
            transform.GetChild(i).GetComponent<CHoisePanel>().DisplayName();
            
        }
    }

    public void MakeAChoise(int choise)
    {
        MC = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController>();
        currentEnemy = GameObject.FindGameObjectWithTag("EnemyHolder").GetComponent<EnemyController>();
        if(PlayerWheels[unlocked_wheel].transform.GetChild(choise).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
        {
            PlayerWheels[unlocked_wheel].GetComponent<Test>().UnPauseAnimation();
            PlayerWheels[unlocked_wheel].GetComponent<Test>().PlayAudio(0);
            PlayerWheels[unlocked_wheel].GetComponent<Test>().PlayAudio(1);

            Weapon weapon = PlayerWheels[unlocked_wheel].transform.GetChild(choise)
                .GetChild(0).GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>();

            MC.playerChoise = weapon;
            chosenWeapon = PlayerWheels[unlocked_wheel].transform.GetChild(choise)
                .GetChild(0).GetComponent<WeaponSprite>().weapon;

            weaponDetector.GetComponent<WeaponDetector>().detectionCount = 0;
            weaponDetector.GetComponent<WeaponDetector>().weaponToDetect = choise+1;

            ChoisePhase();

            MC.enemyChoise = currentEnemy.EnemyChoise(weapon.type);

            MC.Resolve();
        }
    }

    public void DisplayWeapons()
    {
        //InstanciateRealWeapons();
        for (int i = 0; i < PlayerWheels[unlocked_wheel].transform.childCount-1; i++)
        {
            PlayerWheels[unlocked_wheel].transform.GetChild(i).GetChild(0)
                        .GetComponent<WeaponSprite>().weapon = TrueWeaponHolder.transform.GetChild(TrueWeaponHolder.transform.childCount - 1-i).gameObject;

            EquipWeapon(
                PlayerWheels[unlocked_wheel].transform.GetChild(i).GetChild(0)
                        .GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>()
                );
        
            PlayerWheels[unlocked_wheel].transform.GetChild(i).GetChild(0)
                .GetComponent<WeaponSprite>().displaySprite();
        }
        DisplayChoises();
    }

    public void InstanciateRealWeapons()
    {
        GetComponent<PlayerInventory>().AddAllWeapons();
        TrueInventory.GetComponent<WeaponController>().LoadPlayerWeapons();

        for (int i = 0; i < GetComponent<PlayerInventory>().items.Count; i++)
        {
            GameObject weapon = Instantiate(GetComponent<PlayerInventory>().items[i], TrueInventory.transform);
            weapon.GetComponent<Weapon>().player = true;
            if (weapon.GetComponent<BuffController>())
            {
                weapon.GetComponent<BuffController>().Inisiate();
            }
        }
        GetComponent<PlayerInventory>().items.Clear();
        for (int i = 0; i < TrueInventory.transform.childCount; i++)
        {
            GetComponent<PlayerInventory>().items.Add(TrueInventory.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < weapons.Count; i++)
        {
            Instantiate(weapons[i], TrueInventory.transform);
        }
    }

    public void ClearTrueWeaponHolder()
    {
        for(int i = TrueWeaponHolder.transform.childCount; i > 0; i--)
        {
            Destroy(TrueWeaponHolder.transform.GetChild(0).gameObject);
        }
    }

    public List<Weapon> GetWeapons()
    {
        List<Weapon> temp = new List<Weapon>();

        GameObject wheel = transform.parent
            .GetChild(0).GetChild(0).gameObject;

        for(int i = 0; i < wheel.transform.childCount-1; i++)
        {
            if(wheel.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
            {
                temp.Add(
                    wheel.transform.GetChild(i).GetChild(0)
                        .GetComponent<WeaponSprite>().weapon.GetComponent<Weapon>()
                );
            } 
        }
        return temp;
    }

    public void ChangeWheel()
    {
        DisableAllWheels();
        PlayerWheels[unlocked_wheel].SetActive(true);
        PlayerWheels[unlocked_wheel].transform.SetAsFirstSibling();
        GameObject.Find("PlayerWeaponDetector").GetComponent<WeaponDetector>().weaponWheel = PlayerWheels[unlocked_wheel];
        maxHealth = unlocked_wheel + 1;
        HB.IncreaseHealthBar(1);
        HB.HealToFull();
    }

    private void DisableAllWheels()
    {
        for(int i = 0; i < PlayerWheels.Count; i++)
        {
            UnequipAllWeaponsFromGear(PlayerWheels[i]);
            PlayerWheels[i].SetActive(false);
        }
    }

    private void UnequipAllWeaponsFromGear(GameObject gear)
    {
        for(int i = 0; i < gear.transform.childCount; i++)
        {
            if (gear.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>())
            {
                if(gear.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().weapon != null)
                {
                    gear.transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>().Unequip();
                }
            }
        }
    }

    //Combat functions

    public void DealDamage()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("EnemyHolder");
        bool dead = enemy.GetComponent<EnemyController>().dead;
        if (dead) MC.Win();
    }

    public void TakeDamage()
    {
        bool dead = HB.GetComponent<HealthBar>().CheckIfDead();

        if (dead) MC.Loose();
    }

    public void Draw()
    {

    }

    public void RecoverAllHealth()
    {
        HB.HealToFull();
    }

    public void Die()
    {
        HB.InstaKill();
    }

    //Equipping
    public void EquipWeapon(Weapon weapon)
    {
        weapon.equip.Invoke();
        weapon.player = true;
    }

    public void UnequipWeapon(Weapon weapon)
    {
        weapon.unEquip.Invoke();
        weapon.player = false;
    }


    public int GiveCurrentHealth()
    {
        return HB.GetComponent<HealthBar>().GiveCurrentHealth();
    }

    // Rock, Paper, scissors

    public void ChoisePhase()
    {
        //Does things when choise is made
        chosenWeapon.GetComponent<Weapon>().choisePhase.Invoke();
    }

    public void ResultPhase()
    {
       if(chosenWeapon != null) chosenWeapon.GetComponent<Weapon>().resultPhase.Invoke();
    }

    public void EndPhase()
    {
        if (chosenWeapon != null) chosenWeapon.GetComponent<Weapon>().endPhase.Invoke();
        for(int i = 0; i < TrueInventory.transform.childCount; i++)
        {
            GameObject weapon = TrueInventory.transform.GetChild(i).gameObject;
            if (weapon.transform.childCount > 0)
            {
                for(int j = 0; j < weapon.transform.childCount; j++)
                {
                    if(weapon.transform.GetChild(j).GetComponent<Buff>().timer > 0)
                    {
                        weapon.transform.GetChild(j).GetComponent<Buff>().TickDown();
                    }
                }
            }
        }
    }


    //Save functions

    public void SavePlayerData()
    {
        PlayerData data = new PlayerData(this);
        SaveSystem.SavePlayerData(data);
    }

    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayerData();

        if (data != null)
        {
            //Set health
            unlocked_wheel = data.gear;
            maxHealth = data.max_health;
            HB.SetMaxHealth(data.max_health);
            HB.SetCurrentHealth(data.current_health);

            //Set correct wheel
            PlayerWheels[0].SetActive(false);
            PlayerWheels[unlocked_wheel].SetActive(true);
            PlayerWheels[unlocked_wheel].transform.SetAsFirstSibling();
            GameObject.Find("PlayerWeaponDetector").GetComponent<WeaponDetector>().weaponWheel = PlayerWheels[unlocked_wheel];

            //Get equippend wapons from real inventory
            for(int i = 0; i < data.equippend_weapons.Length; i++)
            {
                if(data.equippend_weapons[i] != null)
                {
                    GameObject weapon = FindWeaponFromIntentory(data.equippend_weapons[i]);
                    
                    if (weapon != null)
                    {
                        WeaponSprite ws = PlayerWheels[unlocked_wheel].transform.GetChild(i).GetChild(0).GetComponent<WeaponSprite>();
                        DropDetector dd = PlayerWheels[unlocked_wheel].transform.GetChild(i).GetChild(1).GetComponent<DropDetector>();
                        dd.DisplayLoadedWeapon(weapon);

                        ws.weapon.GetComponent<Weapon>().player = true;
                        if (ws.weapon.GetComponent<BuffController>())
                        {
                            ws.weapon.GetComponent<BuffController>().Inisiate();
                        }

                        if (!ws.weapon.GetComponent<HealthIncrease>()) ws.weapon.GetComponent<Weapon>().equip.Invoke();
                        ws.weapon.GetComponent<Weapon>().player = true;


                        RemoveWeaponByName(data.equippend_weapons[i]);
                    }
                }
            }

            LoadBuffData();
        }
        else
        {
            HB.DisplayHealthBar(maxHealth);
            ChangeWheel();
        }
    }

    private void LoadBuffData()
    {
        for(int i = 0; i < TrueInventory.transform.childCount; i++)
        {
            Weapon weapon = TrueInventory.transform.GetChild(i).GetComponent<Weapon>();
            if(weapon.buff_data.Length > 0)
            {
                for(int j = 0; j < weapon.buff_data.Length; j++)
                {
                    Buff target_buff = FindBuffById(weapon.buff_data[j].id, weapon.gameObject);
                    target_buff.used = weapon.buff_data[j].used;
                    target_buff.timer = weapon.buff_data[j].timer;
                }
            }
        }
    }

    private Buff FindBuffById(string id, GameObject target_weapon)
    {
        for(int i = 0; i < target_weapon.transform.childCount; i++)
        {
            Buff buff = target_weapon.transform.GetChild(i).GetComponent<Buff>();
            if(buff.id == id)
            {
                return buff;
            }
        }
        Debug.Log("Correct buff not found");
        return null;
    }

    public GameObject FindWeaponFromIntentory(string name)
    {
        for(int i = 0; i < TrueInventory.transform.childCount; i++)
        {
            if(TrueInventory.transform.GetChild(i).GetComponent<Weapon>().name == name)
            {
                return TrueInventory.transform.GetChild(i).gameObject;
            }
        }
        return null;
    }

    public void RemoveWeaponByName(string name)
    {
        for (int i = 0; i < GetComponent<PlayerInventory>().items.Count; i++)
        {
            if (GetComponent<PlayerInventory>().items[i].GetComponent<Weapon>().name == name)
            {
                GetComponent<PlayerInventory>().items.RemoveAt(i);
                break;
            }
        }
    }
}
