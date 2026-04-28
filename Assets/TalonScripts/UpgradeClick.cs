using UnityEngine;

public class UpgradeClick : MonoBehaviour
{
    public GameObject upgradeUi;
    public Animator playerAnimator;
    [SerializeField] Interact playerInteract;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] PlayerMovement playerMovement;

    public PlayerUpgrades player;
    public void upgrade()
    {
        playerAnimator.enabled = true;
        playerInteract.isInteracted = false;
        Time.timeScale = 1f;
        upgradeUi.SetActive(false);
        playerHealth.health = playerHealth.maxHealth;
        playerMovement.canMove = true;
    }

    public void boostStrength()
    {
        player.strengthLevel++;
    }

    public void boostSpeed()
    {
        player.speedLevel++;
    }

    public void boostHealth()
    {
        player.healthLevel++;
    }   
}
