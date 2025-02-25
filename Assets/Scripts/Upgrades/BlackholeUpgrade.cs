using UnityEngine;

public abstract class BlackholeUpgrade : ScriptableObject
{
    public float UpgradeAmount = 1f;

    public double OriginalUpgradeCost = 100;
    public double CurrentUpgradeCost = 100;
    public double CostIncreaseMultiplierPerPurchase = 0.05f;

    public string UpgradeButtonText;
    [TextArea(3, 10)]
    public string UpgradeButtonDescription;

    public abstract void ApplyUpgrade();

    private void OnValidate()
    {
        CurrentUpgradeCost = OriginalUpgradeCost;
    }

}
