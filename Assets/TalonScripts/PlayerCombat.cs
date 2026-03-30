using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{

    public float attackCooldown = 1f;
    float timer;

    public float knockbackForce = 5f;

    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;

    public int lifeStealAmount = 1;
    int timesHit = 0;
    public int amountHit = 5;
    PlayerHealth playerHealth;
    PlayerUpgrades playerUpgrades;
    Animator animator;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerUpgrades = GetComponent<PlayerUpgrades>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1 && timer <= 0)
        {
            animator.SetTrigger("isAttacking");
            
        }
    }
    public void DamageEnemy()
    {

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Enemy"));

        if (enemies.Length > 0)
        {
            if (playerUpgrades.strengthLevel > 0 && playerHealth.health < playerHealth.maxHealth)
            {
                timesHit++;
                if (timesHit >= amountHit)
                {
                    playerHealth.TakeDamage(-lifeStealAmount);
                    timesHit = 0;
                }
            }
            enemies[0].GetComponent<EnemyKnockback>().Knockback(transform, knockbackForce);
            enemies[0].GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            Debug.Log("Hit " + enemies[0].name);
        }
    }
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
