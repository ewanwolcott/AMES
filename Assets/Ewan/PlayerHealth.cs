using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    float flashDuration = 0.25f;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;
    
    public Transform respawnPoint;

    void Start()
    {
        health = maxHealth;   
    }

    private void Update()
    {
        if(playerSr.color != Color.white)
        {
            flashDuration -= Time.deltaTime;
            if (flashDuration <= 0)
            {
                playerSr.color = Color.white;
                flashDuration = 0.25f;
            }
        }
    }

    public void TakeDamage (int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            //playerSr.enabled = false;
            //playerMovement.enabled = false;
            transform.position = respawnPoint.position;
        }
    }
}