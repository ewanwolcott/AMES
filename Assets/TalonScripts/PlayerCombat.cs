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
    public float attackDamage = 1f;

    public bool hasStrengthUpgrade = false;

    public int lifeStealAmount = 1;

    PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
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
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Enemy"));

            if(enemies.Length > 0)
            {
                if (hasStrengthUpgrade && playerHealth.health < playerHealth.maxHealth)
                {
                    playerHealth.TakeDamage(-lifeStealAmount);
                }
                enemies[0].GetComponent<EnemyKnockback>().Knockback(transform, knockbackForce);
                enemies[0].GetComponent <EnemyHealth>().TakeDamage((int)attackDamage);  
                Debug.Log("Hit " + enemies[0].name);
            }

            timer = attackCooldown;
        }
    }
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
