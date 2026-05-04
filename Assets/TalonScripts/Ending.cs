using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] GameObject[] bossEnemies;
    Collider2D collider2d;

    private void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (bossEnemies.Length == 0)
        {
            collider2d.isTrigger = true;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player has reached the end of the game!");
        }
    }
}
