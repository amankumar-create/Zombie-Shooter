using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    Enemies enemies;
    public bool isDead = false;
    private void Start()
    {
        enemies = FindObjectOfType<Enemies>();
    }
    public void  TakeDamage(float damage)
    {
        hitPoints -= damage;
        BroadcastMessage("OnDamageTaken");
        if (hitPoints <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if (isDead) return;
        isDead = true;
       // Debug.Log(enemies);
        enemies.ReduceEnemiesCount();
        CapsuleCollider enemyColloider = GetComponent<CapsuleCollider>();
        enemyColloider.height = .3f;
        enemyColloider.center = enemyColloider.center - new Vector3(0, .85f, 0);
        GetComponent<Animator>().SetTrigger("Die");
       
        if (enemies.GetEnemiesCount() == 0)
        {
            FindObjectOfType<GameOverHandler>().DisplayGameOverCanvas("You Survived");
        }
    }
}
