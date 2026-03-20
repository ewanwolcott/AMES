using UnityEngine;

public class Upgrader : MonoBehaviour
{
    [SerializeField] PlayerUpgrades playerUpgrades;
    public bool strengthUpgrade;
    public bool speedUpgrade;
    public bool healthUpgrade;
    public void Upgrade()
    {
        if (strengthUpgrade)
        {
            playerUpgrades.strengthLevel++;
        }
        else if (healthUpgrade)
        {
            playerUpgrades.healthLevel++;
        }
        else if (speedUpgrade)
        {
            playerUpgrades.speedLevel++;
        }
    }
}
