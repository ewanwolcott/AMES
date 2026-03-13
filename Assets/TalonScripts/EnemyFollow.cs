using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField] GameObject player;

    [SerializeField] LayerMask lineOfSightMask;

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
        if(hasLineofSight)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb2d.linearVelocityX = direction.x * moveSpeed;
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position, lineOfSightMask);
        if (ray.collider != null)
        {
            hasLineofSight = ray.collider.CompareTag("Player");
            if (hasLineofSight)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }
}
