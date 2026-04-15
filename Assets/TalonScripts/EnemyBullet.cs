using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    public float force;
    float destroyTime = 3.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

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
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }
        else if (rb.linearVelocityX > 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
                Destroy(gameObject);
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Destroy(gameObject);
            }
        }
    }
}
