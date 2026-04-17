using Unity.VisualScripting;
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
            die();
        }
    }
    public void die()
    {
        playerMovement.enabled = false;
        GetComponent<Animator>().SetTrigger("isDead");
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }


    public void respawn()
    {
        health = maxHealth;
        transform.position = respawnPoint.position;
        playerMovement.enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}