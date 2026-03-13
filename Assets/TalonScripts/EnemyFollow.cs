using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField] GameObject player;

    [SerializeField] LayerMask lineOfSightMask;
    
    float viewRadius = 5f;
    float distanceToPlayer;

    bool hasLineofSight = false;

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
        if (hasLineofSight)
        {

            Vector2 direction = (player.transform.position - transform.position).normalized;
            if(distanceToPlayer <= viewRadius)
            {
                rb2d.linearVelocityX = direction.x * moveSpeed;
            }
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            hasLineofSight = ray.collider.CompareTag("Player");
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
