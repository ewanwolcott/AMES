using UnityEngine;

public class UpgradeClick : MonoBehaviour
{
    public GameObject upgradeUi;
    public Animator playerAnimator;
    [SerializeField] Interact playerInteract;

    public PlayerUpgrades player;
    public void upgrade()
    {
        playerAnimator.enabled = true;
        playerInteract.isInteracted = false;
        Time.timeScale = 1f;
        upgradeUi.SetActive(false);
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
