using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (bossEnemies[0] == null && bossEnemies[1] == null && bossEnemies[2] == null && bossEnemies[3] == null)
        {
            collider2d.isTrigger = true;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("End scen");
        }
    }
}
