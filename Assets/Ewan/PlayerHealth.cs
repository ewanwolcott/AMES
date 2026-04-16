using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;
    
    public Transform respawnPoint;

    void Start()
    {
        health = maxHealth;   
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