using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButtonReferences : MonoBehaviour
{
    public Button UpgradeButton;
    public TextMeshProUGUI UpgradeButtonText;
    public TextMeshProUGUI UpgradeDescriptionText;
    public TextMeshProUGUI UpgradeCilkText;

    public object UpgradeCostText { get; internal set; }
}
