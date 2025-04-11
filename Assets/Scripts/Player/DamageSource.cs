using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float pushForce;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyDamage enemyDamage = other.gameObject.GetComponent<EnemyDamage>();
        enemyDamage?.Hit(damage);

        PushBack pushBack = other.gameObject.GetComponent<PushBack>();
        pushBack?.Push((other.transform.position - transform.position).normalized, pushForce);
    }   
}
