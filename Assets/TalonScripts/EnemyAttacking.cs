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
    Collider2D player;
    EnemyFollow enemyFollow;

    Animator animator;

    public float enemyAttackCooldown = 1f;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponent<Animator>();
        enemyFollow = GetComponent<EnemyFollow>();
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
            enemyFollow.isAttacking = true;

            Debug.Log("Enemy hit " + hits[0].name);

            timer = enemyAttackCooldown;

            animator.SetTrigger("IsAttacking");
            player = hits[0];
        }
    }
    public void Attack()
    {
        enemyFollow.isAttacking = false;
        Collider2D[] hits2 = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayer);
        if (hits2.Length > 0)
        { 
            playerHealth.TakeDamage(damage);
            if (playerHealth.health > 0)
            {
                hits2[0].GetComponent<PlayerMovement>().Knockback(transform, knockbackForce, stunTime);
            }
        }
    }



    private void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
            return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(enemyAttackPoint.position, enemyAttackRange);
    }
}
