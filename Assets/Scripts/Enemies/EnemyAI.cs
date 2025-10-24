using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _roamChangeDirFloat = 2f;
    private enum State
    {
        Roaming
    }
    private State _state;
    private EnemyPathFinding _enemyPathFinding;

    private void Awake()
    {
        _enemyPathFinding = GetComponent<EnemyPathFinding>();
        _state = State.Roaming;
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (_state == State.Roaming)
        {
            Vector2 roamPos = GetRoamingPosition();
            _enemyPathFinding.MoveTo(roamPos);
            yield return new WaitForSeconds(_roamChangeDirFloat);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    
}
