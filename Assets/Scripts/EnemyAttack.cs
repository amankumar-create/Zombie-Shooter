using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] int damage = 5;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
     

    public void AttackHitEvent()
    {
        if (!target) return;
        target.TakeDamage(damage);
        target.GetComponent<ShowDamage>().ShowDamageImpact();
    }
}
