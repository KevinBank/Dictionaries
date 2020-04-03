using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class WeaponsEnum : MonoBehaviour
{
    enum WeaponEnum {RocketLauncher,Smg,ThrowingKnife }
    private Dictionary<WeaponEnum, int> weapon = new Dictionary<WeaponEnum, int>();
    [SerializeField] private Text weaponTextUI;
    [SerializeField] private Text ammoTextUI;
    private WeaponEnum currentweapon;

    private void Awake()
    {
        currentweapon = WeaponEnum.RocketLauncher;
        weaponTextUI.text = System.Enum.GetName(typeof(WeaponEnum), currentweapon);
        weapon[WeaponEnum.RocketLauncher] = 4;
        weapon[WeaponEnum.Smg] = 35;
        weapon[WeaponEnum.ThrowingKnife] = 5;
        ammoTextUI.text = weapon[currentweapon].ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Switchweapon(WeaponEnum.RocketLauncher);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Switchweapon(WeaponEnum.Smg);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Switchweapon(WeaponEnum.ThrowingKnife);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (weapon[currentweapon] <= 0)
            {
                weapon[currentweapon] = 0;
                Debug.Log("Magazine Empty" + weapon[currentweapon]);
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

    void Switchweapon(WeaponEnum weapon)
    {
        currentweapon = weapon;
        updateText();
    }

    void updateText()
    {
        weaponTextUI.text = System.Enum.GetName(typeof(WeaponEnum), currentweapon);
        ammoTextUI.text = weapon[currentweapon].ToString();
    }
}