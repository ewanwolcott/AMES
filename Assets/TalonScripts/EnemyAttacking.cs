using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    public Transform enemyAttackPoint;
    public PlayerHealth playerHealth;
    public LayerMask playerLayer;
    public float enemyAttackRange;
    public float knockbackForce;
    public float stunTime;
    public int damage = 1;

    public float enemyAttackCooldown = 1f;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        Collider2D[] hits = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayer);

        if (hits.Length > 0 && timer <= 0)
        {
            Debug.Log("Enemy hit " + hits[0].name);

            playerHealth.TakeDamage(damage);

            hits[0].GetComponent<PlayerMovement>().Knockback(transform, knockbackForce, stunTime);
            timer = enemyAttackCooldown;
        }
    }
    //public void Attack()
    //{
    //    Collider2D[] hits = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayer);

    //    if(hits.Length > 0)
    //    {
    //        Debug.Log("Enemy hit " + hits[0].name);
    //    }
    //}



    private void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
            return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(enemyAttackPoint.position, enemyAttackRange);
    }
}
