using System;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerControls _player;
    private Animator _animator;

    private void Awake()
    {
        _animator =  GetComponent<Animator>();
        _player = new PlayerControls();
    }

    private void OnEnable()
    {
        _player.Enable();
    }

    void Start()
    {
        _player.Combat.Attack.started += _ => Attack();
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
