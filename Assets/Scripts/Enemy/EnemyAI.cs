using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum EnemyState
    {
        Roaming
    }

    [SerializeField] float roamingFlipTime;

    EnemyPathfinding enemyPathfinding;
    EnemyState state;

    void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = EnemyState.Roaming;   
    }

    void Start()
    {
        StartCoroutine(Roaming());
    }

    IEnumerator Roaming()
    {
        while (state == EnemyState.Roaming)
        {
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            enemyPathfinding.SetMoveDirection(randomDirection);
            yield return new WaitForSeconds(roamingFlipTime);
        }
    }
}
