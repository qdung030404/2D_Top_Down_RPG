using System;
using System.Collections;
using UnityEngine;

public class knockback : MonoBehaviour
{
    public bool gettingKnockback {get; private set;}
    [SerializeField] private float knockbackTime = 0.2f;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void GetKnockback(Transform playerDamage, float thurst)
    {
        gettingKnockback = true;
        Vector2 difference = (transform.position - playerDamage.position).normalized * thurst *  _rb.mass;
        _rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(knockRoutine());
    }

    private IEnumerator knockRoutine()
    {
        yield return new WaitForSeconds(knockbackTime);
        _rb.linearVelocity = Vector2.zero;
        gettingKnockback = false;
        
    }
}
