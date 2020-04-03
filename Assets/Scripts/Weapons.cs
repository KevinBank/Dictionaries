using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    private Dictionary<string, int> weapon = new Dictionary<string, int>();
    [SerializeField] private Text weaponTextUI;
    [SerializeField] private Text ammoTextUI;
    private string currentweapon;

    private void Awake()
    {
        currentweapon = "Rocket Launcher";
        weaponTextUI.text = currentweapon;
        weapon["Rocket Launcher"] = 4;
        weapon["Smg"] = 35;
        weapon["Throwing knife"] = 5;
        ammoTextUI.text = weapon[currentweapon].ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Switchweapon("Rocket Launcher");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Switchweapon("Smg");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Switchweapon("Throwing knife");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (weapon[currentweapon] <= 0)
            {
                weapon[currentweapon] = 0;
                Debug.Log("Ammo is foetsie" + weapon[currentweapon]);
            }
            else
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        weapon[currentweapon] -= 1;
        updateText();
    }

    void Switchweapon(string tempString)
    {
        currentweapon = tempString;
        updateText();
    }

    void updateText()
    {
        weaponTextUI.text = currentweapon;
        ammoTextUI.text = weapon[currentweapon].ToString();
    }
}