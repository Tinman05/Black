using UnityEngine;

public abstract class BlackholeUpgrade : ScriptableObject
{
    public float UpgradeAmount = 1f;

    public double OriginalUpgradeClick = 100;
    public double CurrentUpgradeClick = 100;
    public double ClickIncreaseMultiplierPerPurchase = 0.05f;

    public string UpgradeButtonText;
    [TextArea(3, 10)]
    public string UpgradeButtonDescription;

    public abstract void ApplyUpgrade();

    private void OnValidate()
    {
        CurrentUpgradeClick = OriginalUpgradeClick;
    }

}
