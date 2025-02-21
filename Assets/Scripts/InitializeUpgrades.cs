using UnityEngine;

public class InitializeUpgrades : MonoBehaviour
{
    public void Initialized(BlackholeUpgrade[] upgrades, GameObject UIToSpawn, Transform spawnParent)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            int currentIndex = i;

            GameObject go = Instantiate(UIToSpawn, spawnParent);

            // ตรวจสอบว่ามี UpgradeButtonReferences หรือไม่
            UpgradeButtonReferences buttonRef = go.GetComponent<UpgradeButtonReferences>();
            if (buttonRef == null)
            {
                Debug.LogError("UpgradeButtonReferences ไม่พบใน GameObject ที่ถูกสร้าง!");
                return;
            }

            // Reset cost
            upgrades[currentIndex].CurrentUpgradeCost = upgrades[currentIndex].OriginalUpgradeCost;

            // Set text
            buttonRef.UpgradeButtonText.text = upgrades[currentIndex].UpgradeButtonText;
            buttonRef.UpgradeDescriptionText.text = string.Format("{0} {1}",
                upgrades[currentIndex].UpgradeButtonDescription,
                upgrades[currentIndex].UpgradeAmount);

            buttonRef.UpgradeCostText = "Click: " + upgrades[currentIndex].CurrentUpgradeCost;

            // ตรวจสอบว่า BlackholeManager.instance มีค่าหรือไม่
            if (BlackholeManager.instance == null)
            {
                Debug.LogError("BlackholeManager.instance เป็น null!");
            }
            else
            {
                // Set onClick
                buttonRef.UpgradeButton.onClick.AddListener(delegate
                {
                    BlackholeManager.instance.OnUpgradeButtonClick(upgrades[currentIndex], buttonRef);
                });
            }
        }
    }
}
