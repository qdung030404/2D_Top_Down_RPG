using System;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
            EnemyHP enemyHp = other.gameObject.GetComponent<EnemyHP>();
            enemyHp?.TakeDamage(damage);
    }
}