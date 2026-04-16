using UnityEngine;

public class EnemyFollow : MonoBehaviour
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (hasLineofSight && !isKnockedback)
        {

            Vector2 direction = (player.transform.position - transform.position).normalized;
            if(distanceToPlayer <= distanceToPLayer && !animator.GetBool("IsDead") && !isAttacking)
            {
                rb2d.linearVelocityX = direction.x * moveSpeed;
                animator.SetBool("IsWalking", true);
            }
            else
            {
                rb2d.linearVelocityX = 0;
                animator.SetBool("IsWalking", false);
            }
        }
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
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
