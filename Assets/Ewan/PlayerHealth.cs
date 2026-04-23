using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    float flashDuration = 0.25f;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;
    [SerializeField] Image img;
    [SerializeField] ScreenFader _screenFader;

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

        if (health <= 0 && img.material.GetFloat("_FadeAmount") == 1)
        {
            transform.position = respawnPoint.position;
            GetComponent<Animator>().SetTrigger("Respawn");
            return;
        }
    }

    public void TakeDamage (int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            playerSr.color = Color.red;
            die();
        }
    }
    public void die()
    {
        
        GetComponent<Animator>().SetTrigger("isDead");
        GetComponent<PlayerMovement>().canMove = false;
        GetComponent<PlayerCombat>().enabled = false;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }


    public void respawn()
    {
        _screenFader.FadeOut(ScreenFader.FadeType.Shutters);
        StartCoroutine(FadeInAfterDelay(2f));
        

    }
    IEnumerator FadeInAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        health = maxHealth;
        _screenFader.FadeIn(ScreenFader.FadeType.Shutters);
        GetComponent<PlayerMovement>().canMove = true;
        GetComponent<PlayerCombat>().enabled = true;
    }
}