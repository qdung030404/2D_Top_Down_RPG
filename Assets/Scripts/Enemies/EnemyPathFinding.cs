using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    
    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private knockback _knockback;
    private void Awake()
    {
        _knockback = GetComponent<knockback>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (_knockback.gettingKnockback){return;}
        _rb.MovePosition(_rb.position + _moveDirection * (_moveSpeed * Time.fixedDeltaTime));
    }
    public void MoveTo(Vector2 roamPos)
    {
        _moveDirection = roamPos;
    }



}
