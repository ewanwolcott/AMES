using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    public int strengthLevel = 0;
    public int speedLevel = 0;
    public int healthLevel = 0;

    PlayerCombat playerCombat;
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(speedLevel == 2)
        {
            playerMovement.movementSpeed = playerMovement.movementSpeed + 1f;
        }
        else if(speedLevel == 3)
        {
            playerMovement.movementSpeed = playerMovement.movementSpeed + 1f;
            playerMovement.jumpHeight = playerMovement.jumpHeight + 2f;
        }
    }
}
