using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    BoxCollider2D coll;
    Animator animator;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
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
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsDead", true);
            rb.gravityScale = 0;
            coll.enabled = false;
        }
    }

}
