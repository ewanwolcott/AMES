using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float stunDuration = 0.5f;

    public float knockbackDuration = 0.5f;

    [HideInInspector] public bool isKnockedback = false;

    [SerializeField] GameObject player;
    
    public float viewRadius = 5f;
    float distanceToPlayer;

    bool hasLineofSight = false;

    [SerializeField] LayerMask lineOfSightMask;

    Rigidbody2D rb2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (hasLineofSight && !isKnockedback)
        {

            Vector2 direction = (player.transform.position - transform.position).normalized;
            if(distanceToPlayer <= viewRadius)
            {
                rb2d.linearVelocityX = direction.x * moveSpeed;
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
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position, viewRadius, lineOfSightMask);
        if (ray.collider != null)
        {
            hasLineofSight = ray.collider.CompareTag("Player");
            //Debug.Log(ray.collider.gameObject.name);
            if (hasLineofSight && distanceToPlayer <= viewRadius)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            if (!hasLineofSight || distanceToPlayer > viewRadius)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }
}
