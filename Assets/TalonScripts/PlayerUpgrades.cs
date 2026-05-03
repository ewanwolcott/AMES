using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrades : MonoBehaviour
{
    public int strengthLevel = 0;
    public int speedLevel = 0;
    public int healthLevel = 0;

    int heal = 0;
    
    public bool canDeflect = false;

    PlayerCombat playerCombat;
    PlayerMovement playerMovement;
    PlayerHealth playerHealth;
    HealthDisplay healthDisplay;
    Animator animator;

    public RuntimeAnimatorController[] animators;

    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
        healthDisplay = GetComponent<HealthDisplay>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (strengthLevel == 2)
        {
            playerCombat.amountHit = 3;
        }
        else if(strengthLevel == 3)
        {
            playerCombat.amountHit = 2;
            playerCombat.attackDamage = 2;
        }
        if (speedLevel == 2)
        {
            playerMovement.movementSpeed = 5f;
        }
        else if(speedLevel == 3)
        {
            playerMovement.movementSpeed = 6f;
            playerMovement.jumpHeight = 11f;
        }
        if (healthLevel == 1)
        {
            canDeflect = true;
            playerHealth.maxHealth = 6;
            healthDisplay.maxHealth = 6;
            if (heal == 0)
            {
                playerHealth.health = playerHealth.maxHealth;
                heal++;
            }
            healthDisplay.hearts[5].enabled = true;
        }
        if (healthLevel == 2)
            {
                playerHealth.maxHealth = 7;
                healthDisplay.maxHealth = 7;
                if (heal == 1)
                {                     
                    playerHealth.health = playerHealth.maxHealth;
                    heal++;
                }

            healthDisplay.hearts[6].enabled = true;
        }
        else if(healthLevel == 3)
            {
                playerHealth.maxHealth = 8;
                healthDisplay.maxHealth = 8;
                if (heal == 2)
                {
                    playerHealth.health = playerHealth.maxHealth;
                    heal++;
                }
            healthDisplay.hearts[7].enabled = true;
            }
        if (strengthLevel > 0 && speedLevel == 0 && healthLevel == 0)
        {
            animator.runtimeAnimatorController = animators[0];
        }
        else if (strengthLevel == 0 && speedLevel > 0 && healthLevel == 0)
        {
            animator.runtimeAnimatorController = animators[1];
        }
        else if (strengthLevel == 0 && speedLevel == 0 && healthLevel > 0)
        {
            animator.runtimeAnimatorController = animators[2];
        }
         else if (strengthLevel > 0 && speedLevel > 0 && healthLevel == 0)
        {
            animator.runtimeAnimatorController = animators[3];
        }
         else if (strengthLevel > 0 && speedLevel == 0 && healthLevel > 0)
        {
            animator.runtimeAnimatorController = animators[4];
        }
         else if (strengthLevel == 0 && speedLevel > 0 && healthLevel > 0)
        {
            animator.runtimeAnimatorController = animators[5];
         }
         else if (strengthLevel > 0 && speedLevel > 0 && healthLevel > 0)
        {
            animator.runtimeAnimatorController = animators[6];
        }
    }
}
