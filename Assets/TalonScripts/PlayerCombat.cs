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
    [SerializeField] AudioClip[] attackSound;


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
            if (transform.position.y <= -5f)
            {
                AudioController.instance.playSound(attackSound[0], transform, 1f);
            }
            if (transform.position.y > -5f)
            {
                AudioController.instance.playSound(attackSound[1], transform, 1f);
            }
            animator.SetTrigger("isAttacking");
            timer = attackCooldown;
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
            enemies[0].GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            if (enemies[0].GetComponent<EnemyHealth>().currentHealth > 0)
            {
                enemies[0].GetComponent<EnemyKnockback>().Knockback(transform, knockbackForce);
            }
            Debug.Log("Hit " + enemies[0].name);
        }
        Collider2D[] bullet = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Bullet"));

        if (bullet.Length > 0 && playerUpgrades.canDeflect)
        {
            Debug.Log("Hit " + bullet[0].name);
            bullet[0].GetComponent<Rigidbody2D>().linearVelocity = -bullet[0].GetComponent<Rigidbody2D>().linearVelocity * 2;
            bullet[0].GetComponent<EnemyBullet>().deflected = 1;
        }
    }
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
