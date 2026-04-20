using UnityEngine;
using System.Collections;

public class LavaDamage : MonoBehaviour
{
    [SerializeField] private float bounceForce = 15f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(TurnRedOnDeath(0.1f));
        }
        IEnumerator TurnRedOnDeath(float knockbackTime)
        {
            yield return new WaitForSeconds(knockbackTime);
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
