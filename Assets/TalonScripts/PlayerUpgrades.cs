using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    public int strengthLevel = 0;
    public int speedLevel = 0;
    public int healthLevel = 0;

    PlayerCombat playerCombat;
    PlayerMovement playerMovement;
    PlayerHealth playerHealth;

    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
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
        if (healthLevel == 2)
            {
                playerHealth.maxHealth = 6;
            }
        else if(healthLevel == 3)
            {
                playerHealth.maxHealth = 7;
            }
    }
}
