using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot{
        public AmmoType ammoType;
        public int ammoCount = 20;
    }

    public int GetAmmoCount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoCount;
    }
    public void ReduceAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoCount--;
    }
    public void PickupAmmo(AmmoType ammoType,  int count)
    {
        AmmoSlot slot = GetAmmoSlot(ammoType);
        slot.ammoCount += count;
    }
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot ammoSlot in ammoSlots)
        {
            if (ammoSlot.ammoType == ammoType) return ammoSlot;
        }
        return ammoSlots[0];
    }
    
}
