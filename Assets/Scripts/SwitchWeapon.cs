using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SwitchWeapon : MonoBehaviour
{
    [SerializeField]int currentWeapon = 0;
    void Start()
    {
        SetWeaponActive();
       
    }

    void Update()
    {
        int previousWeapon = currentWeapon;
        ProcessKeyInput();
        ProcessScrollWheel();
        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
            currentWeapon = (currentWeapon + 1);
            
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentWeapon = (currentWeapon - 1);
            
        }
        currentWeapon = (currentWeapon+transform.childCount) % transform.childCount;
           
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            ++weaponIndex;
        }
    }
}
