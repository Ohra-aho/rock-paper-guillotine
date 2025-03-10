using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] GameObject WeaponPref;
    // Start is called before the first frame update
    void Start()
    {
        displayWeapons();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateHeight();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateStartAndEndPoint();
        transform.GetChild(0).GetComponent<NonUIScroll>().DetermineInitialLocation();
        transform.parent.GetComponent<Test>().PlayAnimation("OpenDrawer");
    }

    private void displayWeapons()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        List<GameObject> items = player.GetComponent<PlayerInventory>().items;

        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].GetComponent<Weapon>())
            {
                GameObject temp = Instantiate(WeaponPref, transform.GetChild(0).GetChild(1)/*.GetChild(i)*/);
                temp.GetComponent<ClaimedWeapon>().weapon = items[i];
                temp.GetComponent<ClaimedWeapon>().DispalyWeapon();
            }
        }
    }

    public void addWeapon(GameObject weapon)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerInventory>().items.Add(weapon);
        
        clearInventory();
        displayWeapons();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateHeight();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateStartAndEndPoint();
    }

    public void removeWeapon(int weapon)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerInventory>().items.RemoveAt(weapon);
        clearInventory();
        displayWeapons();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateHeight();
        transform.GetChild(0).GetComponent<NonUIScroll>().CalculateStartAndEndPoint();
    }

    private void clearInventory()
    {
        GameObject items = transform.GetChild(0).GetChild(1).gameObject;

        // Collect children to destroy
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < items.transform.childCount; i++)
        {
            children.Add(items.transform.GetChild(i));
        }

        // Destroy them
        foreach (Transform child in children)
        {
            DestroyImmediate(child.gameObject);

        }   
    }
}
