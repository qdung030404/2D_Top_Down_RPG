using System;
using System.Collections;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private float _restoreDefaultMatTime = 0.2f;
    
    private Material _defaultMat;
    private SpriteRenderer _spriteRenderer;
    private EnemyHP _enemyHP;

    private void Awake()
    {
        _enemyHP = GetComponent<EnemyHP>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultMat = _spriteRenderer.material;
    }

    public IEnumerator FlashRoutine()
    {
        _spriteRenderer.material = _material;
        yield return new WaitForSeconds(_restoreDefaultMatTime);
        _spriteRenderer.material = _defaultMat;
        _enemyHP.Death();
    }
}
