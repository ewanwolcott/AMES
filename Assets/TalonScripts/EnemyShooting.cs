using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    [SerializeField] PlayerHealth player;

    public float shootCooldown = 2f;

    EnemyFollow enemyFollow;
    Animator animator;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        enemyFollow = GetComponent<EnemyFollow>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > shootCooldown && enemyFollow.distanceToPlayer >= 5 && enemyFollow.distanceToPlayer <= 15 && player.health >= 0)
        {
            timer = 0;
            animator.SetTrigger("IsShooting");
        }
    }
    public void shoot()
    {         
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
