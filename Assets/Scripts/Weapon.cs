using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCam;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float fireDelay = .1f;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoCountText;
    [SerializeField] GameObject enemyHitEffect, objectHitEffect;

    bool canShoot = true;
    ParticleSystem muzzleFlashVFX;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
        ammoCountText.text = ammoSlot.GetAmmoCount(ammoType).ToString();

    }

    IEnumerator Shoot()
    {
        if (ammoSlot.GetAmmoCount(ammoType) > 0 && canShoot)
        {
            canShoot = false;
            PlayShootSound();
            PlayShootAnimation();
            PlayMuzzleFlashVFX();
            ProcessRaycast();
            ammoSlot.ReduceAmmo(ammoType);
            yield return new WaitForSeconds(fireDelay);
            canShoot = true;
        }

    }

    private void PlayShootSound()
    {
        GetComponent<AudioSource>().Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCam.transform.position, FPCam.transform.forward, out hit, range))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            CreateHitEffect(hit, target);
            if (target)
            {
                target.TakeDamage(damage);

            }
        }
        
    }
    void CreateHitEffect(RaycastHit hit, EnemyHealth target)
    {
        GameObject hitEffect = objectHitEffect;
        if (target) hitEffect = enemyHitEffect;
        GameObject hitVfx =  Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitVfx, 1f);
    }

    private void PlayMuzzleFlashVFX()
    {
        muzzleFlashVFX = GetComponentInChildren<ParticleSystem>();
        muzzleFlashVFX.Play();
    }
    void PlayShootAnimation()
    {
        GetComponentInChildren<Animator>().SetTrigger("shoot");
    }
}
