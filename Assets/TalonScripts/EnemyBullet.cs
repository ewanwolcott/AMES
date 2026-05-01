using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    SpriteRenderer sprt;
    public float force;
    float destroyTime = 3.5f;
    Animator animator;

    public float deflected = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprt = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, 0f).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0)
        {
            Destroy(gameObject);
        }
        if (rb.linearVelocityX < 0)
        {
            sprt.flipX = false;
        }
        else if (rb.linearVelocityX > 0)
        {
            sprt.flipX = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy") && deflected == 1)
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
            Destroy(gameObject);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
