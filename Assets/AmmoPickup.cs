using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoCount = 10;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().PickupAmmo(ammoType, ammoCount);
            Destroy(transform.gameObject);
        }
    }
}
