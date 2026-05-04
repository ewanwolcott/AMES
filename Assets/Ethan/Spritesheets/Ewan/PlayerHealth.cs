using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    float flashDuration = 0.25f;
    float regenTimer = 15f;

    bool firstScreenFade = false;

    SpriteRenderer playerSr;
    PlayerMovement playerMovement;
    [SerializeField] Image img;
    [SerializeField] ScreenFader _screenFader;
    PlayerUpgrades playerUpgrades;

    public Transform respawnPoint;

    private void Awake()
    {
        playerSr = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
        playerUpgrades = GetComponent<PlayerUpgrades>();
    }
    void Start()
    {
        health = maxHealth;   
    }

    private void Update()
    {
        if (playerUpgrades.healthLevel == 3)
        {
            regenTimer -= Time.deltaTime;
            if (regenTimer <= 0 && health < maxHealth && health > 0)
            {
                TakeDamage(-1);
                regenTimer = 15f;
            }
        }
        if (playerSr.color != Color.white)
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
        Debug.Log("Player took " + amount + " damage. Current health: " + health);
        if (health <= 0)
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _screenFader.FadeIn(ScreenFader.FadeType.Shutters);
        GetComponent<PlayerMovement>().canMove = true;
        GetComponent<PlayerCombat>().enabled = true;
    }
}