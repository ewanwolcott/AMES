using UnityEngine;
using System.Collections;


public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    BoxCollider2D coll;
    Animator animator;
    Rigidbody2D rb;
    EnemyAttacking enemyAttacking;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        enemyAttacking = GetComponent<EnemyAttacking>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
       currentHealth -= amount;
        animator.SetTrigger("IsHit");
        if (currentHealth <= 0)
        {
            spriteRenderer.color = Color.red; // Change color to red when dead
            StartCoroutine(TurnRedOnDeath(0.1f)); // Call the method to change color back to white immediately
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsDead", true);
            enemyAttacking.enabled = false;
            rb.gravityScale = 0;
            coll.enabled = false;
        }
    }
    IEnumerator TurnRedOnDeath(float knockbackTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        Debug.Log("Turning red on death");
        spriteRenderer.color = Color.white; // Change color back to white after knockback
    }

}
