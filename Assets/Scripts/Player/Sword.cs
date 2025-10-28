using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpwanPoint;
    [SerializeField] private Transform weaponCollider;
    [SerializeField] private float swordAttackCD = 0.5f;
    private PlayerControls _player;
    private Animator _animator;
    private PlayerController _playerController;
    private ActiveWeapon _activeWeapon;
    private GameObject _slashAnim;
    private bool _attackButtonDown, _isAttacking = false;
    private void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
        _activeWeapon = GetComponentInParent<ActiveWeapon>();
        _animator =  GetComponent<Animator>();
        _player = new PlayerControls();
    }

    private void OnEnable()
    {
        _player.Enable();
    }

    void Start()
    {
        _player.Combat.Attack.started += _ => StartAttacking();
        _player.Combat.Attack.canceled += _ => StopAttacking();
    }

    private void Update()
    {
        MouseFollowOffset();
        Attack();
    }

    private void StartAttacking()
    {
        _attackButtonDown = true;
    }

    private void StopAttacking()
    {
        _attackButtonDown = false;
    }
    private void MouseFollowOffset()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(_playerController.transform.position);
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        if (mousePos.x < playerScreenPoint.x)
        {
            _activeWeapon.transform.localRotation = Quaternion.Euler(0, -180, angle);
            weaponCollider.transform.localRotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            _activeWeapon.transform.localRotation = Quaternion.Euler(0, 0, angle);
            weaponCollider.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Attack()
    {
        if (_attackButtonDown && !_isAttacking)
        {
            _isAttacking = true;
            _animator.SetTrigger("Attack");
            weaponCollider.gameObject.SetActive(true);
            _slashAnim = Instantiate(slashAnimPrefab, slashAnimSpwanPoint.position, Quaternion.identity);
            _slashAnim.transform.parent = this.transform.parent;
            StartCoroutine(AttackCDRoutine());
        }
    }

    private IEnumerator AttackCDRoutine()
    {
        yield return new WaitForSeconds(swordAttackCD);
        _isAttacking = false;
    }
    public void DoneAttackingEvent()
    {
        weaponCollider.gameObject.SetActive(false);
    }
    public void swingUpAnim()
    {
        _slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);
        if (_playerController.FacingLeft)
        {
            _slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void swingDownAnim()
    {
        _slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (_playerController.FacingLeft)
        {
            _slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
