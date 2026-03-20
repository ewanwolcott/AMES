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
            playerMovement.movementSpeed = 5f;
        }
        else if(speedLevel == 3)
        {
            playerMovement.movementSpeed = 6f;
            playerMovement.jumpHeight = 11f;
        }
    }
}
