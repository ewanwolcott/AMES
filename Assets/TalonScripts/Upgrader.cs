using UnityEngine;

public class Upgrader : MonoBehaviour
{
    //[SerializeField] PlayerUpgrades playerUpgrades;
    //public bool strengthUpgrade;
    //public bool speedUpgrade;
    //public bool healthUpgrade;

    public GameObject upgradeUi;

    public Animator playerAnimator;
    public void Upgrade()
    {
        //if (strengthUpgrade)
        //{
        //    playerUpgrades.strengthLevel++;
        //}
        //else if (healthUpgrade)
        //{
        //    playerUpgrades.healthLevel++;
        //}
        //else if (speedUpgrade)
        //{
        //    playerUpgrades.speedLevel++;
        //}
        Time.timeScale = 0f;
        playerAnimator.enabled = false;
        upgradeUi.SetActive(true);
    }
}
