using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Collections;

using NUnit.Framework.Internal.Commands;

public class BlackholeManager : MonoBehaviour
{
    public static BlackholeManager instance;

    public GameObject MainGameCanvas;
    [SerializeField] private GameObject _upgradeCanvas;
    [SerializeField] private TextMeshProUGUI _blackholeCountText;
    [SerializeField] private TextMeshProUGUI _blackholePerSecondText;
    [SerializeField] private GameObject _blackholeObj;
    public GameObject CookieTextPopup;
    [SerializeField] private GameObject _backgroundObj;

    [Space]
    public BlackholeUpgrade[] Upgrades;
    [SerializeField] private GameObject _upgradeUIToSpawn;
    [SerializeField] private Transform _upgradeUIParent;
    public GameObject BlackholePerSecondObjToSpawn;

    public double CurrentBlackholeCount { get; set; }
    public double CurrentBlackholePerSecond { get; set; }

    // Upgrade related
    public double BlackholePerClickUpgrade { get; set; }  // เพิ่มค่าที่ได้ต่อคลิก

    private InitializeUpgrades _initializeUpgrades;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        UpdateBlackholeUI();
        UpdateBlackHolePerSecondUI();

        _upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);

        _initializeUpgrades = GetComponent<InitializeUpgrades>();
        _initializeUpgrades.Initialized(Upgrades, _upgradeUIToSpawn, _upgradeUIParent);

    }



    #region On Blackhole Clicked

    public void OnBlackholeClicked()
    {
        IncreaseBlackhole();

        // ค่อยๆ ขยายขนาดของ BlackholeObj โดยเพิ่มขนาดทีละ 0.05 ในทุกแกน เป็นเวลา 0.5 วินาที
        _blackholeObj.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.5f);
        _backgroundObj.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(BackgroundScaleback);
    }

    private void BlackholeScaleBack()
    {
        _blackholeObj.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
    }

    private void BackgroundScaleback()
    {
        _backgroundObj.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
    }


    public void IncreaseBlackhole()
    {
        // เมื่อคลิกจะเพิ่มคะแนนโดยคำนวณจาก 1 + อัปเกรดที่ได้
        CurrentBlackholeCount += 1 + BlackholePerClickUpgrade;
        UpdateBlackholeUI();
    }

    #endregion

    #region Upgrade System

    // ฟังก์ชันอัปเกรดค่า Click
    public void UpgradeClick()
    {
        // คำนวณค่าใช้จ่าย (ตัวอย่าง: ค่าใช้จ่าย = (1 + อัปเกรดที่มีอยู่) * 10)
        double upgradeCost = (1 + BlackholePerClickUpgrade) * 10;
        if (CurrentBlackholeCount >= upgradeCost)
        {
            CurrentBlackholeCount -= upgradeCost;
            BlackholePerClickUpgrade++;
            UpdateBlackholeUI();
        }
    }

    #endregion

    #region UI Updates

    private void UpdateBlackholeUI()
    {
        _blackholeCountText.text = CurrentBlackholeCount.ToString();
    }

    private void UpdateBlackHolePerSecondUI()
    {
        _blackholePerSecondText.text = CurrentBlackholePerSecond.ToString() + " P/S";
    }

    #endregion

    #region Button Presses
    
    public void OnUpgradeButtonPress()
    {
        MainGameCanvas.SetActive(false);
        _upgradeCanvas.SetActive(true);
    }

    public void OnResumeButtonPress()
    {
        _upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);
    }

    #endregion

    #region Simple Increases
    public void SimpleBlackholeIncrease(double amount)
    {
        CurrentBlackholePerSecond += amount;
        UpdateBlackholeUI();
    }

    public void SimpleBlackholePerSecondIncrease(double amount)
    {
        CurrentBlackholePerSecond += amount;
        UpdateBlackHolePerSecondUI();
    }

    #endregion

    #region Events

    public void OnUpgradeButtonClick(BlackholeUpgrade upgrade, UpgradeButtonReferences buttonRef)
    {
        if (CurrentBlackholeCount >= upgrade.CurrentUpgradeCost)
        {
            upgrade.ApplyUpgrade();

            CurrentBlackholeCount -= upgrade.CurrentUpgradeCost;
            UpdateBlackholeUI();

            upgrade.CurrentUpgradeCost = Mathf.Round((float)(upgrade.CurrentUpgradeCost * (1 + upgrade.CostIncreaseMultiplierPerPurchase)));

            buttonRef.UpgradeCostText = "Cost: " + upgrade.CurrentUpgradeCost;
        }
    }

    #endregion
}