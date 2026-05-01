using UnityEngine;

public class EnemyFlight : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float stunDuration = 0.5f;

    public float knockbackDuration = 0.5f;

    [HideInInspector] public bool isKnockedback = false;

    [SerializeField] GameObject player;

    Animator animator;

    public float distanceToPLayer = 5f;
    [HideInInspector] public float distanceToPlayer;

    bool hasLineofSight = false;
    public bool isAttacking = false;

    [SerializeField] LayerMask lineOfSightMask;

    Rigidbody2D rb2d;
    SpriteRenderer sprt;

    EnemyHealth enemyHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprt = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerHealth>().health <= 0)
        {
            isAttacking = false;
        }
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (hasLineofSight && !isKnockedback)
        {

            Vector2 direction = (player.transform.position - transform.position).normalized;
            if (distanceToPlayer <= distanceToPLayer && !animator.GetBool("IsDead") && !isAttacking && player.GetComponent<PlayerHealth>().health > 0)
            {
                rb2d.linearVelocity = direction * moveSpeed;
                animator.SetBool("IsWalking", true);
            }
            else
            {
                rb2d.linearVelocityX = 0;
                animator.SetBool("IsWalking", false);
            }
        }
        if (player.transform.position.x < transform.position.x && enemyHealth.currentHealth >= 0)
        {
            sprt.flipX = false;
        }
        else if (player.transform.position.x > transform.position.x && enemyHealth.currentHealth >= 0)
        {
            sprt.flipX = true;
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position, distanceToPLayer, lineOfSightMask);
        if (ray.collider != null)
        {
            hasLineofSight = ray.collider.CompareTag("Player");
            //Debug.Log(ray.collider.gameObject.name);
            if (hasLineofSight && distanceToPlayer <= distanceToPLayer)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            if (!hasLineofSight || distanceToPlayer > distanceToPLayer)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }

}
