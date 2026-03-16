using System.Collections;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{

    Rigidbody2D rb2d;

    EnemyFollow enemyFollow;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyFollow = GetComponent<EnemyFollow>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Knockback(Transform playerTransform, float knockbackForce)
    {
        enemyFollow.isKnockedback = true;
        spriteRenderer.color = Color.red; // Change color to red when knocked back
        StartCoroutine(DisableFollowTemporarily(enemyFollow.knockbackDuration, enemyFollow.stunDuration));
        Vector2 knockbackDirection = (transform.position - playerTransform.position).normalized;
        rb2d.linearVelocityX = knockbackDirection.x * knockbackForce;
        Debug.Log($"Knockback applied with force: {knockbackDirection.x * knockbackForce}");
    }

    IEnumerator DisableFollowTemporarily(float knockbackTime, float stunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        spriteRenderer.color = Color.white; // Change color back to white after knockback
        rb2d.linearVelocityX = Vector2.zero.x;

        yield return new WaitForSeconds(stunTime);
        enemyFollow.isKnockedback = false;
    }
}
