using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int startingHP = 2;
    private int currentHP;
    private void Start()
    {
        currentHP = startingHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Death();
    }

    private void Death()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
