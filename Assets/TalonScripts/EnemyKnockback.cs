using System.Collections;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{

    Rigidbody2D rb2d;

    EnemyFollow enemyFollow;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyFollow = GetComponent<EnemyFollow>();
    }
    public void Knockback(Transform playerTransform, float knockbackForce)
    {
        enemyFollow.isKnockedback = true;
        StartCoroutine(DisableFollowTemporarily(enemyFollow.stunDuration));
        Vector2 knockbackDirection = (transform.position - playerTransform.position).normalized;
        rb2d.linearVelocityX = knockbackDirection.x * knockbackForce;
        Debug.Log($"Knockback applied with force: {knockbackDirection.x * knockbackForce}");
    }

    IEnumerator DisableFollowTemporarily(float waitTime)
    {
        yield return new WaitForSeconds(0.5f);
        rb2d.linearVelocityX = 0f;
        enemyFollow.isKnockedback = false;
    }
}
