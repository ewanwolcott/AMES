using UnityEngine;

public class EnemyFlight : MonoBehaviour
{
    [SerializeField]GameObject player;
    EnemyFollow enemyFollow;
    [SerializeField] float speed = 5f;
    private void Awake()
    {
        enemyFollow = GetComponent<EnemyFollow>();
    }
    void FixedUpdate()
    {
        if (enemyFollow.distanceToPlayer <= 10 && transform.position.y != player.transform.position.y + 1.19f)
        {
            Vector2 currentpos = (Vector2)transform.position;
            transform.position = Vector2.Lerp(currentpos, new Vector2(currentpos.x, player.transform.position.y + 1.19f), Time.fixedDeltaTime * speed);
        }
    }

}
