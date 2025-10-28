using System;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int startingHP = 2;
    private int currentHP;
    private knockback _knockback;
    private Flash _flash;
    private void Awake()
    {
        _flash =  GetComponent<Flash>();
        _knockback = GetComponent<knockback>();
    }

    private void Start()
    {
        
        currentHP = startingHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        _knockback.GetKnockback(PlayerController.Instance.transform, 15f);
        StartCoroutine(_flash.FlashRoutine());
    }

    public void Death()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
